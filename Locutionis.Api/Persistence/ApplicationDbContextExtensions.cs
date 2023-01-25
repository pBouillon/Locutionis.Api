using Locutionis.Api.Persistence.Entities;

namespace Locutionis.Api.Persistence;

internal static class ApplicationDbContextExtensions
{
    private static readonly IEnumerable<FigureOfSpeech> _figuresOfSpeech = new[]
    {
        // Alit�ration
        new FigureOfSpeech
        {
            Name = "Alit�ration",
            Description = """
            L'alit�ration est la r�p�tition d'une ou de plusieurs consonnes ou 
            plus g�n�ralement d'un m�me son consonne.
            """,
            Goal = """
            Le sens de la r�p�tition du son se trouve dans le contexte dans lequel 
            il est utilis�. Par exemple, pour d�crire un �boulement, un son [r] 
            r�p�t� rappellera les roulements des rochers qui tombent.
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
                    Example = "Pour qui sont ces serpents qui sifflent sur vos t�tes ?",
                    Source = "Racine, Andromaque, acte V, sc�ne 5",
                },
                new()
                {
                    Example = """
                    (...) l'onde de choc fractura le f�mur d'enceinte et le vent sabla 
                    cru le village � travers les jointures b�antes du granit. Sous mon 
                    casque, le son atroce du roc ponc� perce, mes dents vibrent - je plie 
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
