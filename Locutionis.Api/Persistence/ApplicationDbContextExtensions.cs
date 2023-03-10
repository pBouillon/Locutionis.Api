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

        // Aphorisme
        new FigureOfSpeech
        {
            Name = "Aphorisme",
            Description = """
            L'aphorisme est une courte phrase qui résume en peu de mots une idée ou un concept en essayant de le 
            faire apparaître sous un angle original en mettant, en général, deux éléments en opposition.
            """,
            Purpose = """
            L'aphorisme est souvent utilisée en philosophie ou en réthorique pour éveiller chez le locuteur 
            questionnements et réflexion
            """,
            Sources = new List<Source>
            {
                new()
                {
                    DisplayName = "Centre National des Ressources Textuelles et Lexicales",
                    Url = new UriBuilder("https://www.cnrtl.fr/definition/aphorisme").Uri,
                },
                new()
                {
                    DisplayName = "Larousse",
                    Url = new UriBuilder("https://www.larousse.fr/dictionnaires/francais/aphorisme/4459").Uri,
                },
                new()
                {
                    DisplayName = "Wikipédia",
                    Url = new UriBuilder("https://fr.wikipedia.org/wiki/Aphorisme").Uri,
                }
            },
            Usages = new List<Usage>
            {
                new()
                {
                    Example = "Je cherchais mon plus lourd fardeau, c'est moi que j'ai trouvé.",
                    Source = "Friedrich Nietzsche",
                },
                new()
                {
                    Example = "La vraie éloquence consiste à dire tout ce qu'il faut, et à ne dire que ce qu'il faut.",
                    Source = "La Rochefoucauld",
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
                    Example = "Le pied de la table a été rongé par les termites.",
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
        },

        // Épanadiplose
        new FigureOfSpeech
        {
            Name = "Épanadiplose",
            Description = """
            L'épanadiplose est une figure de style qui consiste à répéter une même phrase ou une 
            même partie de phrase à la fin d'un vers ou d'une phrase et au début du vers ou de la 
            phrase suivante.
            """,
            Purpose = """
            En utilisant l'épanadiplose, un auteur peut souligner une idée ou une image et la rendre 
            plus mémorable pour le lecteur. Cela peut également renforcer l'impact émotionnel de la 
            scène ou de l'idée, en ajoutant une résonance ou un effet de boucle qui attire l'attention 
            du lecteur.
            """,
            Sources = new List<Source>
            {
                new()
                {
                    DisplayName = "Wikipédia",
                    Url = new UriBuilder("https://fr.wikipedia.org/wiki/Épanadiplose").Uri,
                },
                new()
                {
                    DisplayName = "linternaute",
                    Url = new UriBuilder("https://www.linternaute.fr/dictionnaire/fr/definition/epanadiplose/").Uri,
                },
            },
            Usages = new List<Usage>
            {
                new()
                {
                    Example = "Voyage, voyage ; Plus loin que la nuit et le jour",
                    Source = "Voyage voyage, Desireless"
                },
                new()
                {
                    Example = "Trop grand, impossible à arrêter ; Arrêté, poisseux au départ, chanceux à la sortie",
                    Source = "Demain, c'est loin, IAM"
                },
            },
        },

        // Épanorthose
        new FigureOfSpeech
        {
            Name = "Épanorthose",
            Description = """
            L'épanorthose est une figure de style qui consiste à corriger ses 
            propres propos afin d'accentuer ce qu'il vient d'être affirmé, 
            renforçant ainsi le sentiment exprimé.
            """,
            Purpose = """
            Il s'agit d'une figure de style souvent utilisée pour donner un 
            sentiment de sincérité dans son discours. En se corrigeant, le 
            locuteur donne l'impression de rechercher la précision.
            """,
            Sources = new List<Source>
            {
                new()
                {
                    DisplayName = "Wikipedia",
                    Url = new UriBuilder("https://fr.wikipedia.org/wiki/Épanorthose").Uri,
                },
                new()
                {
                    DisplayName = "Wiktionnaire",
                    Url = new UriBuilder("https://fr.wiktionary.org/wiki/Épanorthose").Uri,
                },
            },
            Usages = new List<Usage>
            {
                new()
                {
                    Example = "J'espère, que dis-je ? Je suis sûr qu'on vous rendra justice.",
                    Source = "Jean-Baptiste Chassignet, Mespris de la vie et consolation contre la mort",
                },
                new()
                {
                    Example = "Votre prudence ou plutôt votre lâcheté nous ont perdu.",
                },
            },
        },

        // Euphémisme
        new FigureOfSpeech
        {
            Name = "Euphémisme",
            Description = """
            L'euphémisme est le fait d'exprimer une idée en atténuant la réalité 
            en employant un mot moins fort.
            """,
            Purpose = """
            Le but de l'euphémisme est d'adoucir des propos qui pourraient être 
            blessants ou choquant. Elle peut également avoir un effet comique en 
            étant utilisée de manière sarcastique.
            """,
            Sources = new List<Source>
            {
                new()
                {
                    DisplayName = "Wikipedia",
                    Url = new UriBuilder("https://fr.wikipedia.org/wiki/Euph%C3%A9misme").Uri,
                },
                new()
                {
                    DisplayName = "Youtube - Le Point Culture",
                    Url = new UriBuilder("https://youtu.be/ByDNEsBNf24?t=207").Uri,
                },
                new()
                {
                    DisplayName = "Office québécois de la langue française",
                    Url = new UriBuilder("http://bdl.oqlf.gouv.qc.ca/bdl/gabarit_bdl.asp?id=3202").Uri,
                },
            },
            Usages = new List<Usage>
            {
                new()
                {
                    Example = "Il a passé l'arme à gauche.",
                },
                new()
                {
                    Example = "La Russie a engagé une opération militaire spéciale en Ukraine.",
                },
            },
        },

        // Homéotéleute
        new FigureOfSpeech
        {
            Name = "Homéotéleute",
            Description = """
            L'homéotéleute est une figure de style qui consiste à utiliser des mots ayant la même 
            syllabe finale dans une série de mots ou de phrases pour créer une cadence et une harmonie 
            musicale dans le discours.
            """,
            Purpose = """
            En utilisant l'homéotéleute, un auteur peut renforcer l'effet poétique de son discours en 
            créant une cadence et une harmonie musicale. Cela peut également ajouter de la mélodie à 
            un texte et renforcer l'emphase sur les idées ou les images décrites.
            """,
            Sources = new List<Source>
            {
                new()
                {
                    DisplayName = "Wikipédia",
                    Url = new UriBuilder("https://fr.wikipedia.org/wiki/Homéotéleute").Uri,
                },
                new()
                {
                    DisplayName = "La langue française",
                    Url = new UriBuilder("https://www.lalanguefrancaise.com/linguistique/homeoteleute-figure-de-style").Uri,
                },
            },
            Usages = new List<Usage>
            {
                new()
                {
                    Example = "Le cheval c'est trop génial !"
                },
                new()
                {
                    Example = "La montagne ça vous gagne !"
                },
                new()
                {
                    Example = "Un mortel, deux mortelles, tous trois également fidèles",
                    Source = "Le Mouton, Marie-Catherine d'Aulnoy"
                },
            },
        },

        // Hypallage
        new FigureOfSpeech
        {
            Name = "Hypallage",
            Description = """
            L'hypallage est une figure de style qui consiste à rattacher deux mots ou expressions 
            ensembles alors que le lecteur s'attend à ce qu'ils soient liés à un troisième.
            """,
            Purpose = """
            L'hypallage est utilisé pour créer un effet de surprise ou pour donner un nouveau sens 
            à un texte. Il peut également être utilisé pour souligner l'importance d'un objet ou 
            pour faire ressortir une particularité.
            """,
            Sources = new List<Source>
            {
                new()
                {
                    DisplayName = "Wikipedia",
                    Url = new UriBuilder("https://fr.wikipedia.org/wiki/Hypallage").Uri,
                },
                new()
                {
                    DisplayName = "La langue française",
                    Url = new UriBuilder("https://www.lalanguefrancaise.com/linguistique/hypallage-definition-exemples").Uri,
                }
            },
            Usages = new List<Usage>
            {
                new()
                {
                    Example = "La chambre est veuve",
                    Source = "Alcools - Hôtels, Guillaume Apollinaire",
                },
                new()
                {
                    Example = "Prennent des albatros, vastes oiseaux des mers, (...)",
                    Source = "L’albatros, Charles Baudelaire",
                },

            },
        },

        // Hyperbole
        new FigureOfSpeech
        {
            Name = "Hyperbole",
            Description = """
            Exagération ou surestimation d'un trait, d'un événement ou d'une situation pour 
            accentuer un point.
            """,
            Purpose = """
            L'hyperbole a pour but de souligner l'importance ou l'effet dramatique d'un point 
            particulier.
            """,
            Sources = new List<Source>
            {
                new()
                {
                    DisplayName = "Wikipedia",
                    Url = new UriBuilder("https://fr.wikipedia.org/wiki/Hyperbole_(rh%C3%A9torique)").Uri
                },
                new()
                {
                    DisplayName = "La culture générale",
                    Url = new UriBuilder("https://www.laculturegenerale.com/hyperbole-definition-exemples/").Uri,
                }
            },
            Usages = new List<Usage>
            {
                new()
                {
                    Example = "Je suis morte de fatigue !",
                },
                new()
                {
                    Example = "C'était vraiment à mourir de rire !",
                },
            },
        },

        // Hyperhypotaxe
        new FigureOfSpeech
        {
            Name = "Hyperhypotaxe",
            Description = """
            On parle d'hyperhypotaxe lorsqu'une phrase est construite avec un 
            nombre excessif de prépositions.
            """,
            Purpose = """
            L'hyperhypotaxe permet souvent de mettre démesurément en avant les 
            détails d'un argumentaire, perdant ainsi la personne qui l'écoute ou 
            l'empêchant de formuler facilement un contre-argument, ces derniers 
            n'en finissant pas.
            """,
            Sources = new List<Source>
            {
                new()
                {
                    DisplayName = "Wikipédia",
                    Url = new UriBuilder("https://fr.wikipedia.org/wiki/Hyperhypotaxe").Uri,
                },
                new()
                {
                    DisplayName = "Wiktionnaire",
                    Url = new UriBuilder("https://fr.wiktionary.org/wiki/hyperhypotaxe").Uri,
                }
            },
            Usages = new List<Usage>
            {
                new()
                {
                    Example = "Martial est fils de noble, puisque son père est quasi-baron, étant donné que sa mère était une fille Angenaux, qui étaient reconnus comme maîtres des terres, et que sa belle-mère avait des accointances avec les De Bellot, à qui appartient le château...",
                }
            },
        },

        // Litote
        new FigureOfSpeech
        {
            Name = "Litote",
            Description = """
            La litote est une figure de style par laquelle on exprime l'inverse 
            de ce que l'on souhaite faire comprendre. Elle peut également être 
            exprimée par une double négation.
            """,
            Purpose = """
            En en laissant entendre moins que ce que l'on veut, on renforce 
            l'idée que l'on souhaite faire passer. Par exemple, dire qu'un 
            repas n'était "pas mauvais" signifie bien généralement qu'il était 
            très bon.
            """,
            Sources = new List<Source>
            {
                new()
                {
                    DisplayName = "Wikipedia",
                    Url = new UriBuilder("https://fr.wikipedia.org/wiki/Litote").Uri,
                },
                new()
                {
                    DisplayName = "Youtube - Le Point Culture",
                    Url = new UriBuilder("https://youtu.be/ByDNEsBNf24?t=207").Uri,
                },
            },
            Usages = new List<Usage>
            {
                new()
                {
                    Example = "Va, je ne te hais point.",
                    Source = "Le Cid, Corneille",
                },
                new()
                {
                    Example = "Pas mauvais ce repas !",
                },
                new()
                {
                    Example = "Vous n'êtes pas sans savoir (...)",
                },
                new()
                {
                    Example = "Ça n'était pas le match du siècle.",
                },
            },
        },

        // Métalepse
        new FigureOfSpeech
        {
            Name = "Métalepse",
            Description = """
            Une métalepse est une figure de style dans laquelle on remplace la 
            cause par la conséquence et inversement.
            """,
            Purpose = """
            La métalepse permet de passer sous silence une idée et de laisser 
            le lecteur se représenter ce qui est réellement entendu.
            """,
            Sources = new List<Source>
            {
                new()
                {
                    DisplayName = "Wikipédia",
                    Url = new UriBuilder("https://fr.wikipedia.org/wiki/Métalepse").Uri,
                },
                new()
                {
                    DisplayName = "Larousse",
                    Url = new UriBuilder("https://www.larousse.fr/dictionnaires/francais/métalepse/50831").Uri,
                },
                new()
                {
                    DisplayName = "Youtube - Le Point Culture",
                    Url = new UriBuilder("https://youtu.be/ByDNEsBNf24?t=1344").Uri,
                },
            },
            Usages = new List<Usage>
            {
                new()
                {
                    Example = "Ce soir, nous dînons en Enfer !",
                    Source = "300",
                },
                new()
                {
                    Example = "Il ne sera pas là ce matin, il a trop bu hier.",
                },
                new()
                {
                    Example = "Comme tu as grandi !",
                },
            },
        },

        // Métaphore
        new FigureOfSpeech
        {
            Name = "Métaphore",
            Description = """
            Une métaphore est similaire à une comparaison à la différence près 
            qu'elle n'utilise pas d'outil de comparaison pour souligner le 
            rapprochement de deux termes. C'est alors au lecteur d'essayer de 
            deviner pourquoi l'auteur les a rapprochés pour créer cette image.
            """,
            Purpose = """
            Le but de la métaphore est d'imager ses propos pour souligner 
            l'intensité ou la connotation de ce qui est imagé en lui donnant 
            le sens d'un autre mot ou expression.
            """,
            Sources = new List<Source>
            {
                new()
                {
                    DisplayName = "linternaute",
                    Url = new UriBuilder("https://www.linternaute.fr/dictionnaire/fr/definition/metaphore/").Uri,
                },
                new()
                {
                    DisplayName = "Wikipedia",
                    Url = new UriBuilder("https://fr.wikipedia.org/wiki/Métaphore").Uri,
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
                    Example = "Il n'est plus que l'ombre de lui-même."
                },
                new()
                {
                    Example = "Tu me casse les pieds."
                },
                new()
                {
                    Example = "Elle est morte dans la fleur de l'âge."
                },
            },
        },

        // Métonymie
        new FigureOfSpeech
        {
            Name = "Métonymie",
            Description = """
            La métonymie consiste en le remplacement d'un terme désignant un 
            tout par un autre en désignant une partie. Le rapport entre les 
            deux est implicite et, s'il n'est pris qu'au premier degré, la 
            phrase devient alors incohérente.
            """,
            Purpose = """
            Utiliser une métonymie permet d'alléger la structure de la phrase 
            comme par exemple dire "Je n'ai plus de batterie" au lieu de "Je 
            n'ai plus d'énergie dans mon téléphone portable". Elle a aussi 
            l'avantage d'englober toute la population désignée et donc peut 
            renforcer un argumentaire. Lors d'un débat, si l'on désigne "les 
            français" au lieu de cibler la tranche de population, on donne 
            alors l'impression que notre discours concerne l'entièreté des 
            habitants de France.
            """,
            Sources = new List<Source>
            {
                new()
                {
                    DisplayName = "linternaute",
                    Url = new UriBuilder("https://www.linternaute.fr/dictionnaire/fr/definition/metonymie/").Uri,
                },
                new()
                {
                    DisplayName = "Wikipedia",
                    Url = new UriBuilder("https://fr.wikipedia.org/wiki/Métonymie").Uri,
                },
                new()
                {
                    DisplayName = "Youtube - Le Point Culture",
                    Url = new UriBuilder("https://youtu.be/ByDNEsBNf24?t=521").Uri,
                },
            },
            Usages = new List<Usage>
            {
                new()
                {
                    Example = "Tu veux boire un verre ?"
                },
                new()
                {
                    Example = "Je n'ai plus de batterie.",
                },
                new()
                {
                    Example = "La France a obtenu une médaille d'or aux Jeux Olympiques.",
                },
            },
        },

        // Oxymore
        new FigureOfSpeech
        {
            Name = "Oxymore",
            Description = """
            L'oxymore est une figure de style qui consiste à associer deux termes ou deux concepts 
            contradictoires pour suggérer une idée paradoxale.
            """,
            Purpose = """
            L'oxymore est utilisée pour créer une tension entre les deux termes opposés et pour explorer 
            les idées complexes ou les contradictions. Elle peut également être utilisée pour renforcer 
            un point, pour surprendre le lecteur ou pour ajouter de l'ironie à un texte.
            """,
            Sources = new List<Source>
            {
                new()
                {
                    DisplayName = "Wikipedia",
                    Url = new UriBuilder("https://fr.wikipedia.org/wiki/Oxymore").Uri
                },
                new()
                {
                    DisplayName = "linternaute",
                    Url = new UriBuilder("https://www.linternaute.fr/dictionnaire/fr/definition/oxymore/").Uri,
                },
            },
            Usages = new List<Usage>
            {
                new()
                {
                    Example = "Elle se hâte avec lenteur",
                    Source = "Le Lièvre et la Tortue, Jean de La Fontaine",
                },
                new()
                {
                    Example = "La clarté sombre des réverbères",
                    Source = "Les Paradis artificiels, Charles Baudelaire",
                },
            },
        },

        // Parataxe
        new FigureOfSpeech
        {
            Name = "Parataxe",
            Description = """
            La parataxe consiste en la juxtaposition de deux mots ou phrases 
            sans mots de liaison. Dans une phrase, cette dernière semblera 
            alors coupé alors que dans le cadre de mots, ces derniers donneront 
            une impression télégraphique.
            """,
            Purpose = """
            Puisque la relation entre les termes n'est pas définie, 
            l'utilisation de la parataxe fait sonner la seconde partie comme la 
            conséquence de la première.
            """,
            Sources = new List<Source>
            {
                new()
                {
                    DisplayName = "Wikipédia",
                    Url = new UriBuilder("https://fr.wikipedia.org/wiki/Parataxe").Uri,
                },
                new()
                {
                    DisplayName = "La culture générale",
                    Url = new UriBuilder("https://www.laculturegenerale.com/parataxe-definition-simple-exemples/").Uri,
                },
            },
            Usages = new List<Usage>
            {
                new()
                {
                    Example = "Vous n'êtes point gentilhomme, vous n'aurez pas ma fille.",
                    Source = "Molière, Le Bourgeois Gentilhomme, Scène XII",
                },
                new()
                {
                    Example = "Il faisait beau. Le Soleil illuminait la pièce. Au dehors, le chant des oiseaux résonnait dans la clairière.",
                },
            },
        },

        // Pléonasme
        new FigureOfSpeech
        {
            Name = "Pléonasme",
            Description = """
            Utilisation de plusieurs mots pour dire la même chose, ce qui rend la phrase inutilement 
            répétitive ou longue. Il ne s'agit pas d'une faute de français mais d'un alourdissement 
            non nécessaire de la phrase.
            """,
            Purpose = """
            Le pléonasme est souvent utilisé pour renforcer ou souligner un point particulier, mais 
            peut également être utilisé pour créer un effet humoristique ou de confusion.
            """,
            Sources = new List<Source>
            {
                new()
                {
                    DisplayName = "La culture générale",
                    Url = new UriBuilder("https://www.laculturegenerale.com/pleonasmes-definition-exemples/").Uri,
                },
                new()
                {
                    DisplayName = "Larousse",
                    Url = new UriBuilder("https://www.larousse.fr/dictionnaires/francais/pl%C3%A9onasme/61617").Uri,
                },
            },
            Usages = new List<Usage>
            {
                new()
                {
                    Example = "Il a fait un mauvais cauchemar",
                },
                new()
                {
                    Example = "Je vais faire de la marche à pieds ce week-end",
                },
            },
        },

        // Prétérition
        new FigureOfSpeech
        {
            Name = "Prétérition",
            Description = """
            La prétérition consiste à parler de quelque chose juste après avoir 
            annoncé que nous n'allions pas le faire.
            """,
            Purpose = """
            L'emploi de la prétérition permet d'aborder des sujets sensibles en 
            déresponsabilisant l'orateur. Elle est également employée lorsque 
            l'auteur souhaite aborder un sujet qu'il se refuse à décrire.
            """,
            Sources = new List<Source>
            {
                new()
                {
                    DisplayName = "Wikipédia",
                    Url = new UriBuilder("https://fr.wikipedia.org/wiki/Prétérition").Uri,
                },
                new()
                {
                    DisplayName = "La culture générale",
                    Url = new UriBuilder("https://www.laculturegenerale.com/preterition-definition-exemples/").Uri,
                },
            },
            Usages = new List<Usage>
            {
                new()
                {
                    Example = "Je n'ai pas besoin de te rappeler que je dois envoyer ce document ce soir.",
                },
                new()
                {
                    Example = "Je ne vous dirais pas que le coût de la vie est trop élevé (...)",
                },
                new()
                {
                    Example = "Madame Y, pour ne pas la citer, (...)",
                },
            },
        },

        // Polyptote
        new FigureOfSpeech
        {
            Name = "Polyptote",
            Description = """
            On parle de polyptote lorsqu'un mot est utilisé sous plusieurs formes dans une même phrase. 
            Il s'agit le plus souvent d'un verbe, conjugué sous différentes formes.
            """,
            Purpose = """
            En choisissant de répéter un même mot sous plusieurs forme, l'auteur peut chercher à insister 
            particulièrement sur celui-ci, ou bien chercher un effect commique.
            """,
            Sources = new List<Source>
            {
                new()
                {
                    DisplayName = "Wikipedia",
                    Url = new UriBuilder("https://fr.wikipedia.org/wiki/Polyptote").Uri,
                },
                new()
                {
                    DisplayName = "La langue française",
                    Url = new UriBuilder("https://www.lalanguefrancaise.com/linguistique/polyptote-figure-de-style").Uri,
                },
            },
            Usages = new List<Usage>
            {
                new()
                {
                    Example = "La flamme de la Résistance ne doit pas s’éteindre et ne s’éteindra pas !",
                    Source = "Appel du 18 juin 1940, Appel du 18 juin 1940."
                },
                new()
                {
                    Example = "Je suis tombé déjà ; je puis tomber encore.",
                    Source = "Les contemplations, Victor Hugo",
                },
                new()
                {
                    Example = "Temps passés Trépassés Les dieux qui me formâtes ; Je ne vis que passant ainsi que vous passâtes",
                    Source = "Alcools - Cortège, Guillaume Apollinaire",
                },
            },
        },

        // Prosopopée
        new FigureOfSpeech
        {
            Name = "Prosopopée",
            Description = """
            La prosopopée est une figure de style qui consiste à faire parler des objets inanimés, 
            des animaux ou des idées comme s'ils étaient des êtres humains dotés de pensée et de 
            parole.
            """,
            Purpose = """
            En utilisant la prosopopée, un auteur peut donner une dimension plus humaine à des objets, 
            animaux ou idées, en les faisant s'exprimer comme s'ils étaient des êtres conscients. 
            Cela peut renforcer l'impact émotionnel de la scène ou de l'idée, ou simplement rendre 
            ces éléments plus mémorables pour le lecteur.
            """,
            Sources = new List<Source>
            {
                new()
                {
                    DisplayName = "Wikipédia",
                    Url = new UriBuilder("https://fr.wikipedia.org/wiki/Prosopopée").Uri,
                },
                new()
                {
                    DisplayName = "La culture générale",
                    Url = new UriBuilder("https://www.laculturegenerale.com/prosopopee-definition-exemples/").Uri,
                },
            },
            Usages = new List<Usage>
            {
                new()
                {
                    Example = "Le vent soupirait en traversant les rues désertes",
                },
                new()
                {
                    Example = "La mer grondait furieusement contre les rochers",
                },
                new()
                {
                    Example = "La pluie pleurait sans relâche sur les toits",
                },
            },
        },

        // Symploque
        new FigureOfSpeech
        {
            Name = "Symploque",
            Description = """
            La symploque est une figure de style consistant à commencer et finir ses phrases par le 
            même mot ou groupe de mots.
            """,
            Purpose = """
            En encerclant chaque phrase des mêmes mots, l'auteur enferme ses propos dans un schéma répétitif. 
            Par son discours, il peut alors donner le sentiment d'être enfermé dans un schéma répétitif et
            alors le dénoncer ou bien au contraire le renforcer. Elle est d'ailleurs très utilisée en politique 
            et en réthorique pour accompagner une situation que l'on veut montrer injuste et indignante.
            """,
            Sources = new List<Source>
            {
                new()
                {
                    DisplayName = "Wikipédia",
                    Url = new UriBuilder("https://fr.wikipedia.org/wiki/Symploque").Uri,
                },
            },
            Usages = new List<Usage>
            {
                new()
                {
                    Example = """
                    Qui est l'auteur de cette loi ? Rullus. Qui a privé du suffrage la plus grande 
                    partie du peuple romain ? Rullus. Qui a présidé les comices ? Rullus.
                    """,
                    Source = "Le Grand Larousse du xxe siècle, Cicéron"
                },
                new()
                {
                    Example = """
                    On nous dit que la gauche n'a aucune chance mais rien n'est écrit. 
                    On nous dit qu'elle ne rassemblera jamais, qu'elle en est incapable, rien n'est écrit. 
                    On nous dit que l'extrême droite est qualifiée d'office pour le second tour, rien n'est écrit. 
                    """,
                    Source = "Déclaration de candidature du 5 décembre 2016, Manuel Valls"
                },
            },
        },
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
