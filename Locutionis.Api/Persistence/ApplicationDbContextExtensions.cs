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
        },

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
                    DisplayName = "Youtube - Le Point Culture",
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
        },

        // Catachrèse
        new FigureOfSpeech
        {
            Name = "Catachrèse",
            Description = """
            Une catachrèse est l'utilisation d'un mot pour désigner autre chose 
            que ce qu'il défini initialement. Dans certains cas il s'agit d'une 
            métaphore qui est passé dans la langue courante (ex: les pieds d'une 
            table).
            """,
            Purpose = """
            Une catachrèse est utilisée la plupart du temps pour désigner quelque 
            chose pour lequel la langue n'a pas de mot définissant ce dont on 
            veut parler. C'est par exemple le cas pour le "verre" lorsque l'on 
            propose de "boire un verre": le français n'a pas de mot pour désigner 
            simplement le contenu d'un verre.
            """,
            Sources = new List<Source>
            {
                new()
                {
                    DisplayName = "Wikipedia",
                    Url = new UriBuilder("https://fr.wikipedia.org/wiki/Catachrèse").Uri,
                },
                new()
                {
                    DisplayName = "Larousse",
                    Url = new UriBuilder("https://www.larousse.fr/dictionnaires/francais/catachr%C3%A8se/13695").Uri,
                },
                new()
                {
                    DisplayName = "Wiktionnaire",
                    Url = new UriBuilder("https://fr.wiktionary.org/wiki/catachr%C3%A8see").Uri,
                },
            },
            Usages = new List<Usage>
            {
                new()
                {
                    Example = "J'ai abîmé la plume de mon stylo en appuyant trop fort.",
                },
                new()
                {
                    Example = "Les ailes de cet avion sont sales !",
                },
                new()
                {
                    Example = "Le pied de la table a été rongé par les thermites.",
                },
            }
        },

        // Chleuasme
        new FigureOfSpeech
        {
            Name = "Chleuasme",
            Description = """
            Le chleuasme est le fait de se dévaloriser en faisant preuve de 
            fausse modestie.
            """,
            Purpose = """
            En se critiquant, le locuteur cherche à s'attirer la sympathie de la 
            personne qui l'écoute.
            """,
            Sources = new List<Source>
            {
                new()
                {
                    DisplayName = "Wikipedia",
                    Url = new UriBuilder("https://fr.wikipedia.org/wiki/Chleuasme").Uri,
                },
            },
            Usages = new List<Usage>
            {
                new()
                {
                    Example = "Je ne suis vraiment pas beau ce matin ...",
                },
                new()
                {
                    Example = "Je ne maîtrise pas très bien le sujet mais je peux quand même regarder.",
                },
            },
        },

        // Comparaison
        new FigureOfSpeech
        {
            Name = "Comparaison",
            Description = """
            Une comparaison est la mise en relation de deux éléments différents 
            partageant un point commun. Elle est constituée d'un comparé (l'objet 
            de la comparaison), d'un comparant (le 'thème' utilisé pour imager le 
            comparé) et d'un outil de comparaison (c'est ce qui met en liaison le 
            comparé et le comparant).
            """,
            Purpose = """
            En mettant deux termes sur le même plan littéraire, la comparaison 
            permet de souligner leurs points communs pour imager ses propos.
            """,
            Sources = new List<Source>
            {
                new()
                {
                    DisplayName = "Wikipedia",
                    Url = new UriBuilder("https://fr.wikipedia.org/wiki/Comparaison_(rh%C3%A9torique)").Uri,
                },
                new()
                {
                    DisplayName = "La langue française",
                    Url = new UriBuilder("https://www.lalanguefrancaise.com/linguistique/la-comparaison-figure-de-style").Uri,
                },
                new()
                {
                    DisplayName = "alloprof",
                    Url = new UriBuilder("https://www.alloprof.qc.ca/fr/eleves/bv/francais/la-comparaison-f1369").Uri,
                },
                new()
                {
                    DisplayName = "Youtube - Le Point Culture",
                    Url = new UriBuilder("https://youtu.be/ByDNEsBNf24?t=478").Uri,
                },
            },
            Usages = new List<Usage>
            {
                new()
                {
                    Example = "Et cette terre était proche, et elle lui apparaissait comme un bouclier sur la mer sombre.",
                    Source = "Homère, L'Odyssée, Chapitre 5",
                },
                new()
                {
                    Example = "Sa barbe était d'argent comme un ruisseau d'avril.",
                    Source = "Victor Hugo, Booz endormi",
                },
                new()
                {
                    Example = "Tu es fait comme un rat !",
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
