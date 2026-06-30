namespace Biblioteca.Models;

public class Autor
{
    public int Id { get; set; } 
    public string? Nome { get; set; }
    public string? Nacionalidade { get; set; }
    public string? Nascimento { get; set; }
    public string? Morte { get; set; }
    public string? Imagem { get; set; }
    public string? Biografia { get; set; }
    public List<string> Obras { get; set; } = new();
}
