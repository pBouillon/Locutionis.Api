namespace Locutionis.Api.Feature.FiguresOfSpeech;

internal static class FiguresOfSpeechEndpoints
{
    internal static RouteGroupBuilder MapFiguresOfSpeechEndpoints(this RouteGroupBuilder api)
    {
        api.MapGet(string.Empty, GetFiguresOfSpeech.Endpoint)
            .WithTags("Figure of speech")
            .WithSummary("Retrieve all figures of speech")
            .WithOpenApi()
            .CacheOutput();

        api.MapGet("/{name}", GetFiguresOfSpeechByName.Endpoint)
            .WithTags("Figure of speech")
            .WithSummary("Retrieve a specific figure of speech by its name")
            .WithOpenApi()
            .CacheOutput(x => x.SetVaryByQuery("name"));

        return api;
    }
}
