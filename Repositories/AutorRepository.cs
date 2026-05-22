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
}

public interface IAutorRepository 
{
    Task<List<Autor>> BuscarTodosAutoresAsync();
    Task<bool> CriarAutorAsync(Autor Autor);
}

    
