using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locutionis.Api.Persistence.Entities;

/// <summary>
/// Represent the usage of a specific <see cref="FigureOfSpeech"/> along with the source from which this example
/// is taken
/// </summary>
internal sealed class Usage
{
    public Guid Id { get; set; }
    public required string Example { get; set; } = null!;
    public string? Source { get; set; }

    public Guid FigureOfSpeechId { get; set; }
    public FigureOfSpeech FigureOfSpeech { get; set; } = null!;
}

internal sealed class UsageConfiguration : IEntityTypeConfiguration<Usage>
{
    public void Configure(EntityTypeBuilder<Usage> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Example).IsRequired();
    }
}
