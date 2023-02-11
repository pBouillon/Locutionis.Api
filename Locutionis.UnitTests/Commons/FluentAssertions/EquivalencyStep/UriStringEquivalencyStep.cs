using FluentAssertions.Equivalency;

namespace Locutionis.UnitTests.Commons.FluentAssertions.EquivalencyStep;

internal class UriStringEquivalencyStep : EquivalencyStep<Uri>
{
    protected override EquivalencyResult OnHandle(
        Comparands comparands, IEquivalencyValidationContext context,
        IEquivalencyValidator nestedValidator)
    {
        if (comparands.Expectation is not Uri expectation
            || comparands.Subject is not string subject)
        {
            return EquivalencyResult.ContinueWithNext;
        }

        subject.Should().Be(expectation.AbsoluteUri);

        return EquivalencyResult.AssertionCompleted;
    }
}
