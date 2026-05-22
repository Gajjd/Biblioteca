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
        return await _context.Livros.ToListAsync();
    }

    // Nessa parte, precisamos mexer no repository para que ele consiga pegar o Id do livro que vamos ver o detalhe
    public async Task<Livro> BuscarLivro(int Id)
    {
        return await _context.Livros.ToListAsync(Id);
    }
    
    public async Task<bool> CriarLivroAsync(Livro livro, int AutorId)
    {
        livro.Autor = await _context.Autores.FirstOrDefaultAsync(x => x.Id == AutorId);
        await _context.Livros.AddAsync(livro);
        await _context.SaveChangesAsync();
        return true;
    }
}

public interface ILivroRepository 
{
    Task<List<Livro>> BuscarTodosLivrosAsync();
    Task<bool> CriarLivroAsync(Livro livro, int AutorId);
    Task<Livro> BuscarLivro(int Id);
}

    
