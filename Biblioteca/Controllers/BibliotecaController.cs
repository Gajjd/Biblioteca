using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers;

public class BibliotecaController : Controller
{
    private readonly Dictionary<string, LivroDetalheViewModel> _livrosDetalhes = new()
    
    {
        ["harry-potter"] = new LivroDetalheViewModel
        {
            Id = "harry-potter",
            Titulo = "Harry Potter e a Pedra Filosofal",
            Imagem = "harry.jpg",
            QtdPaginas = 223,
            DataPublicacao = 1997,
            Genero = "Fantasia, aventura",
            Autor = "J. K. Rowling",
            Resumo = "Harry Potter e a Pedra Filosofal conta a história de Harry, um menino que descobre aos 11 anos que é um bruxo e é convidado a estudar na Escola de Magia e Bruxaria de Hogwarts. Lá, ele faz amigos, aprende magia e começa a entender seu passado. Ao longo da história, Harry enfrenta desafios e descobre a existência da misteriosa Pedra Filosofal, que está sendo ameaçada por forças do mal ligadas ao bruxo Lord Voldemort.",
            AutorId = "jk-rowling"
        },
        ["harry-potter-e-o-prisioneiro-de-azkaban"] = new LivroDetalheViewModel
        {
            Id = "harry-potter-e-o-prisioneiro-de-azkaban",
            Titulo = "Harry Potter e o Prisioneiro de Azkaban",
            Imagem = "harry2.jpg",
            QtdPaginas = 317,
            DataPublicacao = 1999,
            Genero = "Fantasia, aventura",
            Autor = "J. K. Rowling",
            Resumo = "Harry retorna a Hogwarts enquanto o perigoso Sirius Black escapa de Azkaban. Entre aulas, novos professores e mistérios sobre seus pais, Harry descobre revelações importantes sobre seu passado e aprende que nem tudo é o que parece.",
            AutorId = "jk-rowling"
        },
        ["harry-potter-e-as-reliquias-da-morte"] = new LivroDetalheViewModel
        {
            Id = "harry-potter-e-as-reliquias-da-morte",
            Titulo = "Harry Potter e as Relíquias da Morte",
            Imagem = "harry3.jpg",
            QtdPaginas = 607,
            DataPublicacao = 2007,
            Genero = "Fantasia, aventura",
            Autor = "J. K. Rowling",
            Resumo = "No desfecho da saga, Harry, Rony e Hermione deixam Hogwarts para encontrar e destruir as Horcruxes de Voldemort. A jornada revela os segredos das Relíquias da Morte e culmina na batalha final entre o bem e o mal no mundo bruxo.",
            AutorId = "jk-rowling"
        },
        ["alice"] = new LivroDetalheViewModel
        {
            Id = "alice",
            Titulo = "Alice no País das Maravilhas",
            Imagem = "alice.jpg",
            QtdPaginas = 150,
            DataPublicacao = 1865,
            Genero = "Fantasia, literatura infantil, nonsense",
            Autor = "Lewis Carroll",
            Resumo = "Alice no País das Maravilhas conta a história de Alice, uma menina que cai em uma toca de coelho e vai parar em um mundo mágico e estranho. Nesse lugar, ela encontra personagens curiosos, como o Coelho Branco, o Chapeleiro Maluco e a Rainha de Copas. A história é cheia de situações absurdas e criativas, explorando a imaginação e a lógica de forma divertida.",
            AutorId = "lewis-carroll"
        },
        ["alice-atraves-do-espelho"] = new LivroDetalheViewModel
        {
            Id = "alice-atraves-do-espelho",
            Titulo = "Alice Através do Espelho",
            Imagem = "alice2.jpg",
            QtdPaginas = 192,
            DataPublicacao = 1871,
            Genero = "Fantasia, literatura infantil, nonsense",
            Autor = "Lewis Carroll",
            Resumo = "Nesta continuação, Alice atravessa um espelho e entra em um mundo inspirado em um tabuleiro de xadrez. Ela encontra personagens excêntricos, como Tweedledum e Tweedledee, e vive aventuras cheias de jogos de linguagem, lógica e imaginação.",
            AutorId = "lewis-carroll"
        },
        ["a-caca-ao-snark"] = new LivroDetalheViewModel
        {
            Id = "a-caca-ao-snark",
            Titulo = "A Caça ao Snark",
            Imagem = "alice3.jpg",
            QtdPaginas = 96,
            DataPublicacao = 1876,
            Genero = "Poema narrativo, nonsense",
            Autor = "Lewis Carroll",
            Resumo = "A Caça ao Snark é um poema narrativo em que uma tripulação embarca em busca de uma criatura misteriosa. A obra mistura humor, absurdo e crítica social, sendo um dos textos mais famosos de Carroll fora do universo de Alice.",
            AutorId = "lewis-carroll"
        },
        ["em-busca-de-sentido"] = new LivroDetalheViewModel
        {
            Id = "em-busca-de-sentido",
            Titulo = "Em Busca de Sentido",
            Imagem = "busca.jpg",
            QtdPaginas = 200,
            DataPublicacao = 1946,
            Genero = "Psicologia, filosofia, autobiografia",
            Autor = "Viktor E. Frankl",
            Resumo = "Em Busca de Sentido relata as experiências de Viktor E. Frankl nos campos de concentração durante o Holocausto. No livro, ele mostra como, mesmo em situações extremas de sofrimento, é possível encontrar um sentido para a vida. A obra também apresenta a logoterapia, uma abordagem psicológica que defende que a principal motivação do ser humano é a busca por propósito.",
            AutorId = "viktor-frankl"
        },
        ["a-presenca-ignorada-de-deus"] = new LivroDetalheViewModel
        {
            Id = "a-presenca-ignorada-de-deus",
            Titulo = "A Presença Ignorada de Deus",
            Imagem = "busca2.jpg",
            QtdPaginas = 144,
            DataPublicacao = 1948,
            Genero = "Psicologia, espiritualidade, filosofia",
            Autor = "Viktor E. Frankl",
            Resumo = "Frankl explora a dimensão espiritual do ser humano e como ela se relaciona com a saúde mental. O livro propõe que a transcendência e a responsabilidade pessoal ajudam na construção de sentido.",
            AutorId = "viktor-frankl"
        },
        ["psicoterapia-e-sentido-da-vida"] = new LivroDetalheViewModel
        {
            Id = "psicoterapia-e-sentido-da-vida",
            Titulo = "Psicoterapia e Sentido da Vida",
            Imagem = "busca3.jpg",
            QtdPaginas = 176,
            DataPublicacao = 1946,
            Genero = "Psicologia, filosofia",
            Autor = "Viktor E. Frankl",
            Resumo = "Nesta obra, Frankl aprofunda os fundamentos da logoterapia e discute como a busca por sentido pode orientar a vida humana mesmo em momentos de dor, vazio existencial e crise pessoal.",
            AutorId = "viktor-frankl"
        },
        ["1984"] = new LivroDetalheViewModel
        {
            Id = "1984",
            Titulo = "1984",
            Imagem = "1984.jpg",
            QtdPaginas = 335,
            DataPublicacao = 1949,
            Genero = "Ficção distópica, ficção científica",
            Autor = "George Orwell",
            Resumo = "1984 retrata uma sociedade controlada por um governo totalitário, liderado pelo Grande Irmão, que vigia todos os cidadãos o tempo todo. A história acompanha Winston Smith, um homem que começa a questionar esse sistema opressor. O livro aborda temas como vigilância, manipulação da verdade e perda da liberdade individual, sendo uma forte crítica a regimes autoritários.",
            AutorId = "george-orwell"
        },
        ["a-revolucao-dos-bichos"] = new LivroDetalheViewModel
        {
            Id = "a-revolucao-dos-bichos",
            Titulo = "A Revolução dos Bichos",
            Imagem = "george2.jpg",
            QtdPaginas = 152,
            DataPublicacao = 1945,
            Genero = "Sátira política, ficção alegórica",
            Autor = "George Orwell",
            Resumo = "Em uma fazenda, os animais se rebelam contra os humanos para criar uma sociedade mais justa. Com o tempo, novos líderes passam a reproduzir os mesmos abusos do antigo regime, em uma crítica contundente ao autoritarismo.",
            AutorId = "george-orwell"
        },
        ["na-pior-em-paris-e-londres"] = new LivroDetalheViewModel
        {
            Id = "na-pior-em-paris-e-londres",
            Titulo = "Na Pior em Paris e Londres",
            Imagem = "george3.jpg",
            QtdPaginas = 272,
            DataPublicacao = 1933,
            Genero = "Memórias, jornalismo literário",
            Autor = "George Orwell",
            Resumo = "Orwell narra suas experiências de pobreza em Paris e Londres, descrevendo o cotidiano de trabalhadores precários e pessoas em situação de rua. A obra combina relato pessoal e crítica social.",
            AutorId = "george-orwell"
        }
    };

    private readonly Dictionary<string, AutorDetalheViewModel> _autoresDetalhes = new()
    {
        ["jk-rowling"] = new AutorDetalheViewModel
        {
            Id = "jk-rowling",
            Nome = "J. K. Rowling",
            Nacionalidade = "Britânica",
            Periodo = "1965 - dias atuais",
            Imagem = "jk.jpg",
            Biografia = "J. K. Rowling é uma escritora britânica, nascida em 31 de julho de 1965, na Inglaterra. Ela ficou mundialmente famosa por criar a série de livros Harry Potter, que conta a história de um jovem bruxo e seus amigos na escola de magia. Antes do sucesso, Rowling enfrentou dificuldades financeiras e chegou a viver como mãe solteira. Sua vida mudou quando o primeiro livro da série foi publicado em 1997, tornando-se um enorme sucesso global. Hoje, J. K. Rowling é uma das autoras mais conhecidas do mundo, com milhões de livros vendidos e adaptações para o cinema.",
            Obras = new List<string> { "harry.jpg", "harry2.jpg", "harry3.jpg" }
        },
        ["lewis-carroll"] = new AutorDetalheViewModel
        {
            Id = "lewis-carroll",
            Nome = "Lewis Carroll",
            Nacionalidade = "Britânico",
            Periodo = "1832 - 1898",
            Imagem = "lc.jpg",
            Biografia = "Lewis Carroll foi um escritor, matemático e fotógrafo britânico, nascido em 27 de janeiro de 1832, na Inglaterra. Seu nome verdadeiro era Charles Lutwidge Dodgson. Ele ficou famoso por escrever Alice no País das Maravilhas, uma obra cheia de fantasia e imaginação que encanta leitores até hoje. Carroll também era professor de matemática e tinha grande interesse por lógica.",
            Obras = new List<string> { "alice.jpg", "alice2.jpg", "alice3.jpg" }
        },
        ["george-orwell"] = new AutorDetalheViewModel
        {
            Id = "george-orwell",
            Nome = "George Orwell",
            Nacionalidade = "Britânico",
            Periodo = "1903 - 1950",
            Imagem = "georgeautor.jpg",
            Biografia = "George Orwell foi um escritor e jornalista britânico, nascido em 25 de junho de 1903, na Índia, que na época fazia parte do Império Britânico. Seu nome verdadeiro era Eric Arthur Blair. Ele ficou famoso por suas obras críticas à política e à sociedade, como 1984 e A Revolução dos Bichos. Orwell abordava temas como autoritarismo, censura e desigualdade.",
            Obras = new List<string> { "1984.jpg", "george2.jpg", "george3.jpg" }
        },
        ["viktor-frankl"] = new AutorDetalheViewModel
        {
            Id = "viktor-frankl",
            Nome = "Viktor E. Frankl",
            Nacionalidade = "Austríaco",
            Periodo = "1905 - 1997",
            Imagem = "vf.jpg",
            Biografia = "Viktor E. Frankl foi um médico psiquiatra e escritor austríaco, nascido em 26 de março de 1905, em Viena, Áustria. Ele ficou conhecido por sobreviver aos campos de concentração nazistas durante o Holocausto e por desenvolver a logoterapia, uma abordagem psicológica que busca o sentido da vida como principal motivação humana. Sua obra mais famosa é Em Busca de Sentido.",
            Obras = new List<string> { "busca.jpg", "busca2.jpg", "busca3.jpg" }
        }
    };

    private static List<Livro> _livrosCadastrados = new();
    
    public IActionResult CadastroLivroAutor()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CadastroLivroAutor(Livro livro)
    {
        Console.WriteLine($"Livro: {livro.Titulo}");

    _livrosCadastrados.Add(livro);

    return RedirectToAction("Catalogo");
    }
    // public IActionResult CadastroLivroAutor(Livro livro)
    // {
    //     if (!ModelState.IsValid)
    //     {
    //         return View(livro);
    //     }

    //     _livrosCadastrados.Add(livro);

    //     return RedirectToAction("Catalogo");
    // }

    public IActionResult Index()
    {
        return View(ObterLivrosCatalogo());
    }

    public IActionResult Catalogo()
    {
        return View(ObterLivrosCatalogo());
    }


    private List<Livro> ObterLivrosCatalogo()
    {
        return _livrosDetalhes.Values
            .Select((livro, index) => new Livro
            {
                Id = index + 1,
                Slug = livro.Id,
                Titulo = livro.Titulo,
                Imagem = livro.Imagem,
                QtdPaginas = livro.QtdPaginas,
                Autor = livro.Autor,
                Genero = livro.Genero,
                DataPublicacao = livro.DataPublicacao,
                Resumo = livro.Resumo
            })
            .ToList();
    }

    public IActionResult LivroDetalhe(string id)
    {
        if (!_livrosDetalhes.TryGetValue(id, out var livro))
        {
            return NotFound();
        }

        return View(livro);
    }

    public IActionResult AutorDetalhe(string id)
    {
        if (!_autoresDetalhes.TryGetValue(id, out var autor))
        {
            return NotFound();
        }

        return View(autor);
    }
}