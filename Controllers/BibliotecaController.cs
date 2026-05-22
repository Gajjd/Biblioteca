using System.Security.Cryptography.X509Certificates;
using Biblioteca.Models;
using Biblioteca.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Biblioteca.Controllers;

public class BibliotecaController : Controller
{
    readonly ILivroRepository _livroRepository;
    readonly IAutorRepository _autorRepository;
    public BibliotecaController(ILivroRepository livroRepository, IAutorRepository autorRepository)
    {
        _livroRepository = livroRepository;
        _autorRepository = autorRepository;
    }

    [HttpPost]
    public async Task<IActionResult> CriarLivroAsync(CriarLivroViewModel livroViewModel)
    {
        Livro livro = new()
        {
            Titulo = livroViewModel.Titulo,
            Genero = livroViewModel.Genero,
            QtdPaginas = livroViewModel.QtdPaginas,
            Resumo = livroViewModel.Resumo,
            DataPublicacao = livroViewModel.DataPublicacao
        };
        await _livroRepository.CriarLivroAsync(livro, livroViewModel.AutorId);
        return RedirectToAction("CriarLivro");
    }
    public async Task<IActionResult> CriarLivroAsync()
    {
        ViewBag.Autores = new SelectList(
            await _autorRepository.BuscarTodosAutoresAsync(),
            "Id",
            "Nome"
        );
        return View();
    }
    public IActionResult CriarAutor()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CriarAutorAsync(Autor autor)
    {
        await _autorRepository.CriarAutorAsync(autor);
        return RedirectToAction();
    }

    public async Task<IActionResult> LivroAsync()
    {
        return View(await _livroRepository.BuscarTodosLivrosAsync());
    }

    public async Task<IActionResult> AutorAsync()
    {
        return View(await _autorRepository.BuscarTodosAutoresAsync());
    }


    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Catalogo()
    {
        var livros = await _livroRepository.BuscarTodosLivrosAsync();
        return View(livros);
    }
    // Precisa buscar um livro específico pelo Id 
        public async Task<IActionResult> LivroDetalhe(int Id)
    {
        var livros = await _livroRepository.BuscarLivro(Id);
        return View(livros);
    }

        public async Task<IActionResult> AutorDetalhe()
    {
        var autor = await _autorRepository.BuscarTodosAutoresAsync();
        return View(autor);
    }

}