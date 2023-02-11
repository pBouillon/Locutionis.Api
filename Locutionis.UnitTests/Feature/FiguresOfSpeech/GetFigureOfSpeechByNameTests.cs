using FluentAssertions.Execution;

using Locutionis.Api.Feature.FiguresOfSpeech;
using Locutionis.Api.Persistence;
using Locutionis.Api.Persistence.Entities;
using Locutionis.UnitTests.Commons.FluentAssertions.EquivalencyStep;
using Locutionis.UnitTests.Commons.Persistence;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging.Abstractions;

using static Locutionis.Api.Feature.FiguresOfSpeech.GetFiguresOfSpeechByName;

namespace Locutionis.UnitTests.Feature.FiguresOfSpeech;

public class GetFigureOfSpeechByNameTests
{
    private readonly ApplicationDbContext _context = InMemoryContextFactory.Create();
    private readonly IFixture _fixture = new Fixture();

    public GetFigureOfSpeechByNameTests()
    {
        _fixture.Behaviors.OfType<ThrowingRecursionBehavior>()
            .ToList()
            .ForEach(behavior => _fixture.Behaviors.Remove(behavior));
        
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
    }

    [Trait("Feature", "GetFiguresOfSpeechByName")]
    [Fact(DisplayName = "Retrieving an unknown figure of speech should return a NotFound result")]
    public async Task RetrieveAnUnknownFigureOfSpeech()
    {
        // Arrange
        var unknownName = _fixture.Create<string>();

        // Act
        var logger = new NullLogger<GetFiguresOfSpeechByName>();
        var retrieved = await Endpoint(unknownName, _context, logger);

        // Assert
        retrieved.Result.Should().BeOfType<NotFound>();
    }

    [Trait("Feature", "GetFiguresOfSpeechByName")]
    [Fact(DisplayName = "Retrieving a figure of speech should return its details")]
    public async Task RetrieveAFigureOfSpeech()
    {
        // Arrange
        var figuresOfSpeech = _fixture.CreateMany<FigureOfSpeech>();

        _context.AddRange(figuresOfSpeech);
        _context.SaveChanges();

        var expected = figuresOfSpeech.First();

        // Act
        var logger = new NullLogger<GetFiguresOfSpeechByName>();
        var retrieved = await Endpoint(expected.Name, _context, logger);

        // Assert
        retrieved.Result.Should().BeOfType<Ok<FigureOfSpeechDetails>>()
            .And.As<Ok<FigureOfSpeechDetails>>().Value.Should().NotBeNull()
            .And.BeEquivalentTo(expected, options => options
                .ExcludingMissingMembers()
                .Using(new UriStringEquivalencyStep()));
    }
}
