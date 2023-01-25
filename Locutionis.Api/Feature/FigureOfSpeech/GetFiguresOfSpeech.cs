using Locutionis.Api.Persistence;

using Mapster;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Locutionis.Api.Feature.FigureOfSpeech;

internal sealed class GetFiguresOfSpeech
{
    internal sealed record FigureOfSpeechPreview
    {
        public string Name { get; init; } = null!;
        public string Preview { get; init; } = null!;
    }

    public static async Task<Ok<IEnumerable<FigureOfSpeechPreview>>> Endpoint(
        ApplicationDbContext context, ILogger<GetFiguresOfSpeech> logger)
    {
        var previews = await context.FiguresOfSpeech
            .AsNoTracking()
            .ProjectToType<FigureOfSpeechPreview>()
            .ToListAsync()
            .ConfigureAwait(false);

        logger.LogInformation("{FiguresOfSpeechCount} figures of speech found and returned", previews.Count);

        return TypedResults.Ok(previews.AsEnumerable());
    }
}
