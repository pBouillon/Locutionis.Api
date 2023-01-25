using Locutionis.Api.Persistence.Entities;

namespace Locutionis.Api.Persistence;

internal static class ApplicationDbContextExtensions
{
    private static readonly IEnumerable<FigureOfSpeech> _figuresOfSpeech = new[]
    {
        // Alitération
        new FigureOfSpeech
        {
            Name = "Alitération",
            Description = """
            L'alitération est la répétition d'une ou de plusieurs consonnes ou 
            plus généralement d'un même son consonne.
            """,
            Goal = """
            Le sens de la répétition du son se trouve dans le contexte dans lequel 
            il est utilisé. Par exemple, pour décrire un éboulement, un son [r] 
            répété rappellera les roulements des rochers qui tombent.
            """,
            Sources = new List<Source>
            {
                new()
                {
                    DisplayName = "Wikipedia",
                    Url = new UriBuilder("https://fr.wikipedia.org/wiki/Alit%C3%A9ration").Uri,
                }
            },
            Usages = new List<Usage>
            {
                new()
                {
                    Example = "Pour qui sont ces serpents qui sifflent sur vos têtes ?",
                    Source = "Racine, Andromaque, acte V, scène 5",
                },
                new()
                {
                    Example = """
                    (...) l'onde de choc fractura le fémur d'enceinte et le vent sabla 
                    cru le village à travers les jointures béantes du granit. Sous mon 
                    casque, le son atroce du roc poncé perce, mes dents vibrent - je plie 
                    contre Pietro, des aiguilles de quartz crissent sur son masque de contre. 
                    """,
                    Source = "La horde du contrevent, Alain Damasio"
                }
            }
        },
    }
    .Select(Sanitized);

    private static FigureOfSpeech Sanitized(FigureOfSpeech raw)
        => new()
        {
            Name = raw.Name,

            Description = raw.Description
                .Trim()
                .Replace(Environment.NewLine, string.Empty),

            Goal = raw.Goal
                .Trim()
                .Replace(Environment.NewLine, string.Empty),

            Sources = raw.Sources,
          
            Usages = raw.Usages.Select(Sanitized).ToList(),
        };

    private static Usage Sanitized(Usage raw)
        => new()
        {
            Example = raw.Example
                .Trim()
                .Replace(Environment.NewLine, string.Empty),

            Source = raw.Source
                .Trim()
                .Replace(Environment.NewLine, string.Empty),
        };

    public static void Seed(this ApplicationDbContext context)
    {
        context.Database.EnsureCreated();

        context.FiguresOfSpeech.AddRange(_figuresOfSpeech);
        context.SaveChanges();
    }
}
