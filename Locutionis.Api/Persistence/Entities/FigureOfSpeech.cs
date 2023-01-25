using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locutionis.Api.Persistence.Entities;

internal sealed class FigureOfSpeech
{
    private const int PreviewLength = 100;

    public Guid Id { get; set; }
    public required string Name { get; set; } = null!;
    public required string Description { get; set; } = null!;
    public required string Goal { get; set; } = null!;
    
    public required ICollection<Usage> Usages { get; set; } = new List<Usage>();
    public required ICollection<Source> Sources { get; set; } = new List<Source>();

    public string Preview => $"{Description[..PreviewLength]}...";
}

internal sealed class FigureOfSpeechConfiguration : IEntityTypeConfiguration<FigureOfSpeech>
{
    public void Configure(EntityTypeBuilder<FigureOfSpeech> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name).IsRequired();

        builder.Property(e => e.Description).IsRequired();

        builder.Property(e => e.Goal).IsRequired();

        builder.HasMany(e => e.Usages)
            .WithOne(e => e.FigureOfSpeech)
            .HasForeignKey(e => e.FigureOfSpeechId);

        builder.HasMany(e => e.Sources)
            .WithOne(e => e.FigureOfSpeech)
            .HasForeignKey(e => e.FigureOfSpeechId);
    }
}
