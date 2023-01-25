using Locutionis.Api.Persistence.Entities;

using Microsoft.EntityFrameworkCore;

using System.Reflection;

namespace Locutionis.Api.Persistence;

internal sealed class ApplicationDbContext : DbContext
{
    public DbSet<FigureOfSpeech> FiguresOfSpeech { get; set; } = default!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}
