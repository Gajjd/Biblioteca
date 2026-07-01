using Biblioteca.Models;
using Biblioteca.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Biblioteca.Controllers;

public class BibliotecaController : Controller
{
    readonly ILivroRepository _livroRepository;
    readonly IAutorRepository _autorRepository;

    public BibliotecaController(
        ILivroRepository livroRepository,
        IAutorRepository autorRepository)
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

        await _livroRepository.CriarLivroAsync(
            livro,
            livroViewModel.AutorId
        );

        return RedirectToAction("CriarLivro");
    }


    [HttpPost]
    public async Task<IActionResult> CriarAutorAsync(Autor autor)
    {
        await _autorRepository.CriarAutorAsync(autor);

        return RedirectToAction("Index");
    }


    [HttpPost]
    public async Task<IActionResult> EditarLivro(EditarLivroViewModel livroViewModel)
    {
        var autores = await _autorRepository.BuscarTodosAutoresAsync();

        var autorSelecionado = autores
            .FirstOrDefault(a => a.Id == livroViewModel.AutorId);


        Livro livro = new()
        {
            Id = livroViewModel.Id,
            Titulo = livroViewModel.Titulo,
            Genero = livroViewModel.Genero,
            QtdPaginas = livroViewModel.NumPaginas,
            DataPublicacao = livroViewModel.DataPublicacao,
            Autor = autorSelecionado
        };


        await _livroRepository.AtualizarLivrosAsync(livro);


        return RedirectToAction("Catalogo");
    }


    [HttpPost, ActionName("ExcluirLivro")]
    public async Task<IActionResult> ExcluirLivroConfirmado(int id)
    {
        await _livroRepository.ExcluirLivroAsync(id);
        return RedirectToAction(nameof(Catalogo));
    }


    [HttpGet]
    public async Task<IActionResult> CriarLivroAsync()
    {
        ViewBag.Autores = new SelectList(
            await _autorRepository.BuscarTodosAutoresAsync(),
            "Id",
            "Nome"
        );

        return View();
    }



    [HttpGet]
    public IActionResult CriarAutor()
    {
        return View();
    }


    [HttpGet]
    public async Task<IActionResult> EditarLivro(int id)
    {
        var livros = await _livroRepository.BuscarTodosLivrosAsync();

        var livro = livros.FirstOrDefault(x => x.Id == id);


        if (livro == null)
            return NotFound();



        var viewModel = new EditarLivroViewModel
        {
            Id = livro.Id,
            Titulo = livro.Titulo,
            NumPaginas = livro.QtdPaginas,
            Genero = livro.Genero,
            DataPublicacao = livro.DataPublicacao,
            AutorId = livro.Autor?.Id ?? 0
        };



        ViewBag.Autores = new SelectList(
            await _autorRepository.BuscarTodosAutoresAsync(),
            "Id",
            "Nome",
            viewModel.AutorId
        );



        return View(viewModel);
    }

    [HttpGet]
    public async Task<IActionResult> ExcluirLivro(int id)
    {
        var livro = await _livroRepository.BuscarLivroAsync(id);

        if (livro == null)
            return NotFound();

        var viewModel = new ExcluirLivroViewModel
        {
            Id = livro.Id,
            Titulo = livro.Titulo,
            AutorNome = livro.Autor?.Nome ?? "Sem Autor"
        };

        return View(viewModel);
    }





    public async Task<IActionResult> LivroAsync()
    {
        return View(
            await _livroRepository.BuscarTodosLivrosAsync()
        );
    }




    public async Task<IActionResult> AutorAsync()
    {
        return View(
            await _autorRepository.BuscarTodosAutoresAsync()
        );
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
     public async Task<IActionResult> Autores()
    {
        var Autores = await _autorRepository.BuscarTodosAutoresAsync();

        return View(Autores);
    }




    public async Task<IActionResult> LivroDetalhe(int id)
    {
        var livro = await _livroRepository.BuscarLivroAsync(id);


        if (livro == null)
            return NotFound();


        return View(livro);
    }





    public async Task<IActionResult> AutorDetalhe(int id)
    {
        var autores = await _autorRepository.BuscarTodosAutoresAsync();

        var autor = autores.FirstOrDefault(x => x.Id == id);


        return View(autor);
    }





    [HttpGet]
    public async Task<IActionResult> ExcluirAutor(int id)
    {
        var autores = await _autorRepository.BuscarTodosAutoresAsync
       ();
        var autor = autores.FirstOrDefault(x => x.Id == id);
        if (autor == null) return NotFound();
        // Executa a checagem se há livros vinculados
        bool temLivros = await _autorRepository.PossuiLivrosVinculadosAsync(id);
        var viewModel = new ExcluirAutorViewModel
        {
            Id = autor.Id,
            Nome = autor.Nome,
            PossuiLivrosVinculados = temLivros
        };
        return View(viewModel);
    }

    [HttpPost, ActionName("ExcluirAutor")]
    public async Task<IActionResult> ExcluirAutorConfirmado(int id)
    {
        // Proteção extra: Segurança caso o usuário tente forçar a requisição POST externamente
        bool temLivros = await _autorRepository.PossuiLivrosVinculadosAsync(id);

        if (temLivros)
        {
            // Se houver livros, cancela a operação e joga de volta para a listagem
            return RedirectToAction("Autores");
        }
        await _autorRepository.ExcluirAutorAsync(id);
        return RedirectToAction("Autores");
    }
    [HttpGet]
    public async Task<IActionResult> EditarAutor(int id)
    {
        var autores = await _autorRepository.BuscarTodosAutoresAsync();

        var Autor = autores.FirstOrDefault(x => x.Id == id);


        if (Autor == null)
            return NotFound();



        var viewModel = new EditarAutorViewModel
        {
            Id = Autor.Id,
            Nome = Autor.Nome,
            Nacionalidade = Autor.Nacionalidade,
            Nascimento = Autor.Nascimento,
            Morte = Autor.Morte,
            Biografia = Autor.Biografia,
        };
        return View(viewModel);
    }
    [HttpPost]
    public async Task<IActionResult> EditarAutor(EditarAutorViewModel model)
    {
    if (!ModelState.IsValid)
    {
        return View(model);
    }

    await _autorRepository.AtualizarAutorAsync(model);

    return RedirectToAction("Autores");
    }
}
