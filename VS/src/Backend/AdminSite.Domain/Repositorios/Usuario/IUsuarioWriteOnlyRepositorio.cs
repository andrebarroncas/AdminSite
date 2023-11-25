namespace AdminSite.Domain.Repositorios.Usuario;

public interface IUsuarioWriteOnlyRepositorio
{
    Task Adicionar(Entidades.Usuario usuario);
}
