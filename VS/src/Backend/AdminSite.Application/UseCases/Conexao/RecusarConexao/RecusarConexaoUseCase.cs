using HashidsNet;
using AdminSite.Application.Servicos.UsuarioLogado;
using AdminSite.Domain.Repositorios;
using AdminSite.Domain.Repositorios.Codigo;

namespace AdminSite.Application.UseCases.Conexao.RecusarConexao;
public class RecusarConexaoUseCase : IRecusarConexaoUseCase
{
    private readonly ICodigoWriteOnlyRepositorio _repositorio;
    private readonly IUsuarioLogado _usuarioLogado;
    private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;
    private readonly IHashids _hashids;

    public RecusarConexaoUseCase(ICodigoWriteOnlyRepositorio repositorio, IUsuarioLogado usuarioLogado, IUnidadeDeTrabalho unidadeDeTrabalho, IHashids hashids)
    {
        _unidadeDeTrabalho = unidadeDeTrabalho;
        _repositorio = repositorio;
        _usuarioLogado = usuarioLogado;
        _hashids = hashids;
    }

    public async Task<string> Executar()
    {
        var usuarioLogado = await _usuarioLogado.RecuperarUsuario();

        await _repositorio.Deletar(usuarioLogado.Id);

        await _unidadeDeTrabalho.Commit();

        return _hashids.EncodeLong(usuarioLogado.Id);
    }
}
