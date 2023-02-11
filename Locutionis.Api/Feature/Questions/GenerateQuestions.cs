using Locutionis.Api.Persistence;
using Locutionis.Api.Persistence.Entities;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

using System.Security.Cryptography;

namespace Locutionis.Api.Feature.Questions;

internal sealed class GenerateQuestions
{
    private static readonly int MaximumNumberOfQuestions = 20;

    internal record QuestionIndexes(int FigureOfSpeechIndex, int UsageIndex);

    internal sealed record Question
    {
        /// <summary>
        /// The number of answers to generate, including the solution
        /// </summary>
        internal static int WrongAnswersCount = 5;

        /// <summary>
        /// All potential figures of speech's name that could qualify the <see cref="ToGuess"/>
        /// </summary>
        public required IEnumerable<string> Answers { get; init; }

        /// <summary>
        /// The example to qualify
        /// </summary>
        public required string ToGuess { get; init; }

        /// <summary>
        /// The correct answer among the <see cref="Answers"/> that qualify the <see cref="ToGuess"/>
        /// </summary>
        public required string Solution { get; init; }
    }

    public static async Task<Results<Ok<IEnumerable<Question>>, BadRequest>> Endpoint(
        int count, ApplicationDbContext context, ILogger<GenerateQuestions> logger)
    {
        if (count <= 0 || count > MaximumNumberOfQuestions)
        {
            logger.LogWarning("Invalid number of questions to be generated ({count})", count);
            return TypedResults.BadRequest();
        }

        var figuresOfSpeech = await context.FiguresOfSpeech
            .Include(x => x.Sources)
            .Include(x => x.Usages)
            .AsNoTracking()
            .ToListAsync()
            .ConfigureAwait(false);

        var questions = GenerateQuestionsFrom(figuresOfSpeech, count);

        logger.LogInformation("{count} questions generated", count);
        return TypedResults.Ok(questions);
    }

    private static IEnumerable<Question> GenerateQuestionsFrom(IList<FigureOfSpeech> figuresOfSpeech, int count)
    {
        var usedIndexes = new HashSet<QuestionIndexes>();
        var questions = new List<Question>();

        for (var i = 0; i < count; ++i)
        {
            var indexes = PickUnusedIndexes(figuresOfSpeech, usedIndexes);
            usedIndexes.Add(indexes);

            var question = GenerateQuestionFrom(indexes, figuresOfSpeech);
            questions.Add(question);
        }

        return questions;
    }
    
    private static Question GenerateQuestionFrom(
        QuestionIndexes indexes, IList<FigureOfSpeech> figuresOfSpeech)
    {
        // Extract the indexes
        var (figureOfSpeechIndex, usageIndex) = indexes;

        // Pick the solution and the example to guess
        var selected = figuresOfSpeech[figureOfSpeechIndex];
        var solution = selected.Name;
        var toGuess = selected.Usages[usageIndex].Example;

        // Pick wrong answers to display along with the solution
        var wrongAnswers = figuresOfSpeech
            .Select(x => x.Name)
            .Where(name => name != solution)
            .Take(Question.WrongAnswersCount);

        // Shuffle the wrong answer and the solution
        var answers = wrongAnswers
            .Append(solution)
            .OrderBy(_ => Guid.NewGuid());

        return new Question
        {
            Answers = answers,
            Solution = solution,
            ToGuess = toGuess,
        };
    }
    
    private static QuestionIndexes PickUnusedIndexes(
        IList<FigureOfSpeech> figuresOfSpeech, IEnumerable<QuestionIndexes> usedIndexes)
    {
        QuestionIndexes indexes;

        do
        {
            indexes = GenerateIndexes();
        } while (usedIndexes.Contains(indexes));

        return indexes;

        QuestionIndexes GenerateIndexes()
        {
            var figuresOfSpeechCount = figuresOfSpeech.Count;
            var figureOfSpeechIndex = RandomNumberGenerator.GetInt32(0, figuresOfSpeechCount);

            var selectedFigureOfSpeechUsagesCount = figuresOfSpeech[figureOfSpeechIndex].Usages.Count;
            var usageIndex = RandomNumberGenerator.GetInt32(0, selectedFigureOfSpeechUsagesCount);

            return new QuestionIndexes(figureOfSpeechIndex, usageIndex);
        }
    }
}
