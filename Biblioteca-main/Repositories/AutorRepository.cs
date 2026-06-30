using System.Data;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Repositories;

public class AutorRepository : IAutorRepository
{
    readonly BibliotecaContext _context;
    public AutorRepository(BibliotecaContext context)
    {
        _context = context;
    }
    public async Task<List<Autor>> BuscarTodosAutoresAsync()
    {
        return await _context.Autores.ToListAsync(); 
    }
    
    public async Task<bool> CriarAutorAsync(Autor Autor)
    {
        await _context.Autores.AddAsync(Autor);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Autor?> BuscarAutorAsync(int id)
    {
        return await _context.Autores
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> PossuiLivrosVinculadosAsync(int autorId)
    {
    return await _context.Livros.AnyAsync(l => l.Autor.Id == autorId);
    }
   
    public async Task<bool> ExcluirAutorAsync(int id)
    {
    var autor = await _context.Autores.FirstOrDefaultAsync(x => x.Id == id);
    if (autor == null) return false;
    _context.Autores.Remove(autor);
    await _context.SaveChangesAsync();
    return true;
    }
    
}

public interface IAutorRepository 
{
    Task<List<Autor>> BuscarTodosAutoresAsync();
    Task<bool> CriarAutorAsync(Autor Autor);
    //Task<bool> AtualizarAutorAsync(Autor autor);
    Task<bool> PossuiLivrosVinculadosAsync(int autorId);
    Task<bool> ExcluirAutorAsync(int id); 
}

    
