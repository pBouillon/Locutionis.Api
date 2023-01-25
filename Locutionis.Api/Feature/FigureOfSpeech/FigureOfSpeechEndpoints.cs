namespace Locutionis.Api.Feature.FigureOfSpeech;

internal static class FigureOfSpeechEndpoints
{
    internal static RouteGroupBuilder MapFigureOfSpeechEndpoints(this RouteGroupBuilder api)
    {
        api.MapGet(string.Empty, GetFiguresOfSpeech.Endpoint)
            .WithTags("Figure of speech")
            .WithSummary("Retrieve all figures of speech")
            .WithOpenApi()
            .CacheOutput();

        api.MapGet("/{name}", GetFiguresOfSpeechByName.Endpoint)
            .WithTags("Figure of speech")
            .WithSummary("Retrieve a specific figure of speech by its name")
            .WithMetadata()
            .WithOpenApi()
            .CacheOutput(x => x.SetVaryByQuery("name"));

        return api;
    }
}
