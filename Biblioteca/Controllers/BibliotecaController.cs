using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers;

public class BibliotecaController : Controller
{
    public IActionResult Index()
    {
        List<Livro> l1 = new List<Livro>()
        {
            new Livro
            {
                titulo = "Harry Potter",
                numPaginas = 150,
                autor = "Fulano",
                genero = "Ficção Científica",
                dataPublicacao = DateOnly.MaxValue   
            },
            new Livro
            {
                titulo = "Alíce no País das Maravilhas",
                numPaginas = 500,
                autor = "Fulana",
                genero = "Fantasia",
                dataPublicacao = DateOnly.MinValue
            }
        };

        return View(l1);
    }
}