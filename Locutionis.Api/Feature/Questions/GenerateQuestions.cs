using Locutionis.Api.Extensions;

using Locutionis.Api.Persistence;
using Locutionis.Api.Persistence.Entities;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Locutionis.Api.Feature.Questions;

internal sealed class GenerateQuestions
{
    private static readonly int MaximumNumberOfQuestions = 10;

    internal sealed record Question
    {
        /// <summary>
        /// The number of answers to generate, including the solution
        /// </summary>
        internal static int WrongAnswersCount = 3;

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

        var questions = Enumerable.Range(0, count)
            .Select(_ => GenerateQuestionFrom(figuresOfSpeech))
            .Aggregate(
                Enumerable.Empty<Question>(),
                (questions, question) => questions.Append(question));

        logger.LogInformation("{count} questions generated", count);
        return TypedResults.Ok(questions);
    }

    private static Question GenerateQuestionFrom(IList<FigureOfSpeech> figuresOfSpeech)
    {
        var selected = figuresOfSpeech.PickRandomly();
        
        var solution = selected.Name;
        var toGuess = selected.Usages.PickRandomly().Example;

        var answers = figuresOfSpeech
            .Select(x => x.Name)
            .Where(name => name != solution)
            .Take(Question.WrongAnswersCount)
            .Append(solution)
            .Shuffled();
        
        return new Question
        {
            Answers = answers,
            Solution = solution,
            ToGuess = toGuess,
        };
    }
}