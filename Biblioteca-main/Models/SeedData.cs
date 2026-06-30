using System.Linq;

namespace Biblioteca.Models;

public static class SeedData
{
    public static void Inicializar(BibliotecaContext context)
    {
        if (context.Autores.Any() || context.Livros.Any())
            return;

               // AUTORES
            var machado = new Autor
            {
                Nome = "Machado de Assis",
                Nacionalidade = "Brasileiro",
                Nascimento = "21/06/1839",
                Morte = "29/09/1908",
                Imagem = "machado.jpg",
                Biografia = "Considerado um dos maiores escritores brasileiros.",
                Obras = new List<string>
                {
                    "Dom Casmurro",
                    "Memórias Póstumas de Brás Cubas"
                }
            };

            var rowling = new Autor
            {
                Nome = "J. K. Rowling",
                Nacionalidade = "Britânica",
                Nascimento = "31/07/1965",
                Morte = "",
                Imagem = "rowling.jpg",
                Biografia = "Autora da série Harry Potter.",
                Obras = new List<string>
                {
                    "Harry Potter e a Pedra Filosofal",
                    "Harry Potter e a Câmara Secreta"
                }
            };

            var tolkien = new Autor
            {
                Nome = "J. R. R. Tolkien",
                Nacionalidade = "Britânico",
                Nascimento = "03/01/1892",
                Morte = "02/09/1973",
                Imagem = "tolkien.jpg",
                Biografia = "Criador da Terra-média.",
                Obras = new List<string>
                {
                    "O Hobbit",
                    "O Senhor dos Anéis"
                }
            };

            var orwell = new Autor
            {
                Nome = "George Orwell",
                Nacionalidade = "Britânico",
                Nascimento = "25/06/1903",
                Morte = "21/01/1950",
                Imagem = "orwell.jpg",
                Biografia = "Autor de 1984 e A Revolução dos Bichos.",
                Obras = new List<string>
                {
                    "1984",
                    "A Revolução dos Bichos"
                }
            };

            var saint = new Autor
            {
                Nome = "Antoine de Saint-Exupéry",
                Nacionalidade = "Francês",
                Nascimento = "29/06/1900",
                Morte = "31/07/1944",
                Imagem = "saint.jpg",
                Biografia = "Autor de O Pequeno Príncipe.",
                Obras = new List<string>
                {
                    "O Pequeno Príncipe"
                }
            };

            var martin = new Autor
            {
                Nome = "George R. R. Martin",
                Nacionalidade = "Americano",
                Nascimento = "20/09/1948",
                Morte = "",
                Imagem = "martin.jpg",
                Biografia = "Autor de As Crônicas de Gelo e Fogo.",
                Obras = new List<string>
                {
                    "A Guerra dos Tronos",
                    "A Fúria dos Reis"
                }
            };

            context.Autores.AddRange(
                machado,
                rowling,
                tolkien,
                orwell,
                saint,
                martin
            );

            context.Livros.AddRange(

                new Livro
                {
                    Titulo = "Dom Casmurro",
                    Autor = machado,
                    QtdPaginas = 256,
                    DataPublicacao = 1899,
                    Genero = "Romance",
                    Resumo = "Bentinho relembra sua história com Capitu."
                },

                new Livro
                {
                    Titulo = "Memórias Póstumas de Brás Cubas",
                    Autor = machado,
                    QtdPaginas = 208,
                    DataPublicacao = 1881,
                    Genero = "Romance",
                    Resumo = "Um defunto narra sua própria vida."
                },

                new Livro
                {
                    Titulo = "Harry Potter e a Pedra Filosofal",
                    Autor = rowling,
                    QtdPaginas = 264,
                    DataPublicacao = 1997,
                    Genero = "Fantasia",
                    Resumo = "Harry descobre que é um bruxo."
                },

                new Livro
                {
                    Titulo = "Harry Potter e a Câmara Secreta",
                    Autor = rowling,
                    QtdPaginas = 288,
                    DataPublicacao = 1998,
                    Genero = "Fantasia",
                    Resumo = "Uma antiga câmara é aberta em Hogwarts."
                },

                new Livro
                {
                    Titulo = "O Hobbit",
                    Autor = tolkien,
                    QtdPaginas = 336,
                    DataPublicacao = 1937,
                    Genero = "Fantasia",
                    Resumo = "Bilbo parte em uma aventura."
                },

                new Livro
                {
                    Titulo = "1984",
                    Autor = orwell,
                    QtdPaginas = 328,
                    DataPublicacao = 1949,
                    Genero = "Distopia",
                    Resumo = "Uma sociedade totalmente controlada pelo Estado."
                },

                new Livro
                {
                    Titulo = "A Revolução dos Bichos",
                    Autor = orwell,
                    QtdPaginas = 152,
                    DataPublicacao = 1945,
                    Genero = "Fábula",
                    Resumo = "Animais se revoltam contra os humanos."
                },

                new Livro
                {
                    Titulo = "O Pequeno Príncipe",
                    Autor = saint,
                    QtdPaginas = 96,
                    DataPublicacao = 1943,
                    Genero = "Infantil",
                    Resumo = "Uma história sobre amizade e imaginação."
                },

                new Livro
                {
                    Titulo = "A Guerra dos Tronos",
                    Autor = martin,
                    QtdPaginas = 592,
                    DataPublicacao = 1996,
                    Genero = "Fantasia",
                    Resumo = "Famílias disputam o Trono de Ferro."
                },

                new Livro
                {
                    Titulo = "A Fúria dos Reis",
                    Autor = martin,
                    QtdPaginas = 656,
                    DataPublicacao = 1998,
                    Genero = "Fantasia",
                    Resumo = "A guerra em Westeros continua."
                }

            );

        context.SaveChanges();
    }
}