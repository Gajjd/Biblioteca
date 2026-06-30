namespace Biblioteca.Models;

public class _livrosDetalhes
{
    public int Id { get; set; }
    public string? Titulo { get; set; }
    public string? Imagem { get; set; }
    public int QtdPaginas { get; set; }
    public int DataPublicacao { get; set; }
    public string? Genero { get; set; }
    public string? Autor { get; set; }
    public string? Resumo { get; set; }
    public Autor? autor { get; set; }
}
