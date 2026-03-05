namespace Biblioteca.Models;

public class Livro
{
    public int numPaginas {get; set; }
    public string? autor {get; set; }
    public string? titulo {get; set; }
    public string? genero {get; set; }
    public DateOnly dataPublicacao {get; set; }
}