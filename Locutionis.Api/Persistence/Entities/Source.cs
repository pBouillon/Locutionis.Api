using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locutionis.Api.Persistence.Entities;

/// <summary>
/// The source to be cited for a <see cref="Source"/> if the user wants to learn more
/// about it
/// </summary>
internal sealed class Source
{
    public Guid Id { get; set; }
    public string DisplayName { get; set; } = null!;
    public Uri Url { get; set; } = null!;

    public Guid FigureOfSpeechId { get; set; }
    public FigureOfSpeech FigureOfSpeech { get; set; } = null!;
}

internal sealed class SourceConfiguration : IEntityTypeConfiguration<Source>
{
    public void Configure(EntityTypeBuilder<Source> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.DisplayName).IsRequired();

        builder.Property(e => e.Url)
            .IsRequired()
            .HasConversion<string>();
    }
}
