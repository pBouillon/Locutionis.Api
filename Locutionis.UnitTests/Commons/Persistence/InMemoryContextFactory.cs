using Locutionis.Api.Persistence;

using Microsoft.EntityFrameworkCore;

namespace Locutionis.UnitTests.Commons.Persistence;

internal static class InMemoryContextFactory
{
    internal static ApplicationDbContext Create()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        var context = new ApplicationDbContext(options);

        context.Database.EnsureCreated();

        return context;
    }
}
