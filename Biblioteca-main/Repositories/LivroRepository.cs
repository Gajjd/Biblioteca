using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Repositories;

public class LivroRepository : ILivroRepository
{
    readonly BibliotecaContext _context;

    public LivroRepository(BibliotecaContext context)
    {
        _context = context;
    }


    public async Task<List<Livro>> BuscarTodosLivrosAsync()
    {
        return await _context.Livros
            .Include(x => x.Autor)
            .ToListAsync();
    }


    public async Task<Livro?> BuscarLivroAsync(int id)
    {
        return await _context.Livros
            .Include(x => x.Autor)
            .FirstOrDefaultAsync(x => x.Id == id);
    }


    public async Task<bool> CriarLivroAsync(Livro livro, int AutorId)
    {
        livro.Autor = await _context.Autores
            .FirstOrDefaultAsync(x => x.Id == AutorId);

        await _context.Livros.AddAsync(livro);
        await _context.SaveChangesAsync();

        return true;
    }


    public async Task<bool> AtualizarLivrosAsync(Livro Livro)
    {
        var livroBanco = await _context.Livros
            .Include(x => x.Autor)
            .FirstOrDefaultAsync(x => x.Id == Livro.Id);


        if (livroBanco == null)
            return false;


        livroBanco.Titulo = Livro.Titulo;
        livroBanco.Genero = Livro.Genero;
        livroBanco.QtdPaginas = Livro.QtdPaginas;
        livroBanco.DataPublicacao = Livro.DataPublicacao;
        livroBanco.Autor = Livro.Autor;


        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> ExcluirLivroAsync(int id)
    {
        var livro = await _context.Livros.FirstOrDefaultAsync(x => x.Id == id);

             if (livro == null) return false;
        _context.Livros.Remove(livro);
        await _context.SaveChangesAsync();

        return true;
    }

}


public interface ILivroRepository
{
    Task<List<Livro>> BuscarTodosLivrosAsync();

    Task<Livro?> BuscarLivroAsync(int id);

    Task<bool> CriarLivroAsync(Livro livro, int AutorId);

    Task<bool> AtualizarLivrosAsync(Livro Livro);

    Task<bool> ExcluirLivroAsync(int id);
}