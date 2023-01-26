using Locutionis.Api.Persistence;

using Mapster;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Locutionis.Api.Feature.FigureOfSpeech;

internal sealed class GetFiguresOfSpeechByName
{
    public sealed record Source
    {
        public string DisplayName { get; init; } = null!;
        public string Url { get; init; } = null!;
    }

    public sealed record Usage
    {
        public string Example { get; init; } = null!;
        public string? Source { get; init; }
    }

    public sealed record FigureOfSpeechDetails
    {
        public string Name { get; init; } = null!;
        public string Description { get; init; } = null!;
        public string Purpose { get; init; } = null!;
        public IEnumerable<Source> Sources { get; init; } = Enumerable.Empty<Source>();
        public IEnumerable<Usage> Usages { get; init; } = Enumerable.Empty<Usage>();
    }

    public static async Task<Results<Ok<FigureOfSpeechDetails>, NotFound>> Endpoint(
        string name, ApplicationDbContext context, ILogger<GetFiguresOfSpeechByName> logger)
    {
        logger.LogInformation("'{FigureOfSpeech}' requested", name);

        var figureOfSpeech = await context.FiguresOfSpeech
            .Include(x => x.Sources)
            .Include(x => x.Usages)
            .AsNoTracking()
            .SingleOrDefaultAsync(fos => fos.Name == name)
            .ConfigureAwait(false);

        if (figureOfSpeech is null)
        {
            logger.LogWarning("'{FigureOfSpeech}' does not exists", name);
            return TypedResults.NotFound();
        }

        var details = figureOfSpeech.Adapt<FigureOfSpeechDetails>();

        logger.LogInformation("'{FigureOfSpeech}' found: {@Details}", name, details);

        return TypedResults.Ok(details);
    }
}
