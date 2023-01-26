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
            Purpose = """
            Le sens de la répétition du son se trouve dans le contexte dans lequel 
            il est utilisé. Par exemple, pour décrire un éboulement, un son [r] 
            répété rappellera les roulements des rochers qui tombent.
            """,
            Sources = new List<Source>
            {
                new()
                {
                    DisplayName = "Wikipedia",
                    Url = new UriBuilder("https://fr.wikipedia.org/wiki/Alitération").Uri,
                },
                new()
                {
                    DisplayName = "La culture générale",
                    Url = new UriBuilder("https://www.laculturegenerale.com/alliteration-definition-exemples/").Uri,
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

        // Antanaclase
        new FigureOfSpeech
        {
            Name = "Antanaclase",
            Description = """
            On parle d'antanaclase lorsque l'on emploie deux fois un même mot mais 
            avec un sens différent: on parle alors de polysémie (plusieurs sens). 
            Si le mot n'est pas répété il est alors question d'antanaclase elliptique.
            """,
            Purpose = """
            Il s'agit d'une figure de style qui se prête très bien aux jeux de mots, elle 
            est donc fréquemment utilisée pour faire de l'humour. En dehors du côté comique, 
            elle permet de souligner le second sens du mot en surprenant le lecteur qui doit 
            s'arrêter un instant pour le saisir après avoir compris le premier.
            """,
            Sources = new List<Source>
            {
                new()
                {
                    DisplayName = "Wikipedia",
                    Url = new UriBuilder("https://fr.wikipedia.org/wiki/Antanaclase").Uri,
                },
                new()
                {
                    DisplayName = "Larousse",
                    Url = new UriBuilder("https://www.larousse.fr/dictionnaires/francais/antanaclase/10911044").Uri,
                },
                new()
                {
                    DisplayName = "La culture générale",
                    Url = new UriBuilder("https://www.laculturegenerale.com/antanaclase-diaphore-definition-exemples/").Uri,
                },
            },
            Usages = new List<Usage>
            {
                new()
                {
                    Example = "Le cœur a ses raisons que la raison ne connaît point.",
                    Source = "Pascal"
                },
                new()
                {
                    Example = "Adieu, monsieur l'homme d'affaires, qui n'avez fait celles de personne.",
                    Source = "Marivaux, Madame Argante I, X, La Mère confidente"
                },
                new()
                {
                    Example = "Les étudiants, c'est comme le linge, quand il fait beau, ça sèche.",
                }
            }
        }

        // Antonomase
        new FigureOfSpeech
        {
            Name = "Antonomase",
            Description = """
            L'antonomase est lorsque l'on utilise un nom commun comme nom propre ou bien l'inverse.
            """,
            Purpose = """
            L'antonomase permet de souligner une aspect de ce que l'on désigne en l'assimilant à 
            autre chose souvent connue pour une caractéristique spécifique.
            """,
            Sources = new List<Source>
            {
                new()
                {
                    DisplayName = "Wikipédia",
                    Url = new UriBuilder("https://fr.wikipedia.org/wiki/Antonomase").Uri,
                },
                new()
                {
                    DisplayName = "Larousse",
                    Url = new UriBuilder("https://www.larousse.fr/dictionnaires/francais/antonomase/4354").Uri,
                },
                new()
                {
                    DisplayName = "Youtube - Point Culture",
                    Url = new UriBuilder("https://www.youtube.com/watch?v=ByDNEsBNf24&t=1278s").Uri,
                },
            },
            Usages = new List<Usage>
            {
                new()
                {
                    Example = "L'Arc de Triomphe a été rénové.",
                },

                new()
                {
                    Example = "Encore un rendez-vous amoureux ? Quel Don Juan !",
                },
            },
        }
    }
    .Select(Sanitized);

    private static FigureOfSpeech Sanitized(FigureOfSpeech raw)
        => new()
        {
            Name = raw.Name,

            Description = raw.Description
                .Trim()
                .Replace("\r\n", string.Empty),

            Purpose = raw.Purpose
                .Trim()
                .Replace("\r\n", string.Empty),

            Sources = raw.Sources,

            Usages = raw.Usages.Select(Sanitized).ToList(),
        };

    private static Usage Sanitized(Usage raw)
        => new()
        {
            Example = raw.Example
                .Trim()
                .Replace("\r\n", string.Empty),

            Source = raw.Source
                ?.Trim()
                .Replace("\r\n", string.Empty),
        };

    public static void Seed(this ApplicationDbContext context)
    {
        context.Database.EnsureCreated();

        context.FiguresOfSpeech.AddRange(_figuresOfSpeech);
        context.SaveChanges();
    }
}
