namespace AdminSite.Application.Servicos.UsuarioLogado;

public interface IUsuarioLogado
{
    Task<Domain.Entidades.Usuario> RecuperarUsuario();
}
