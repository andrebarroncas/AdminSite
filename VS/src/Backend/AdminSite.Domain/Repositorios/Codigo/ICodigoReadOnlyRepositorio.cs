namespace AdminSite.Domain.Repositorios.Codigo;
public interface ICodigoReadOnlyRepositorio
{
    Task<Entidades.Codigos> RecuperarEntidadeCodigo(string codigo);
}
