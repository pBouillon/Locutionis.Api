namespace Locutionis.Api.Feature.Questions;

internal static class QuestionsEndpoints
{
    internal static RouteGroupBuilder MapQuestionsEndpoints(this RouteGroupBuilder api)
    {
        api.MapGet(string.Empty, GenerateQuestions.Endpoint)
            .WithTags("Question")
            .WithSummary("Generate a set of questions")
            .WithOpenApi()
            .CacheOutput(x => x.NoCache());

        return api;
    }
}
