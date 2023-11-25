using AdminSite.Domain.Enum;

namespace AdminSite.Domain.Entidades;

public class Receita : EntidadeBase
{
    public string Titulo { get; set; }
    public int CategoriaId { get; set; }
    public virtual Categoria Categoria { get; set; }
    public string ModoPreparo { get; set; }
    public int TempoPreparo { get; set; }
    public virtual ICollection<Ingrediente> Ingredientes { get; set; }
    public long UsuarioId { get; set; }
}
