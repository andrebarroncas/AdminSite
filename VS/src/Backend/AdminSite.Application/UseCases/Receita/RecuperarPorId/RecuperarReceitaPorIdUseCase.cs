using AutoMapper;
using AdminSite.Application.Servicos.UsuarioLogado;
using AdminSite.Comunicacao.Respostas;
using AdminSite.Domain.Repositorios.Conexao;
using AdminSite.Domain.Repositorios.Receita;
using AdminSite.Exceptions;
using AdminSite.Exceptions.ExceptionsBase;

namespace AdminSite.Application.UseCases.Receita.RecuperarPorId;
public class RecuperarReceitaPorIdUseCase : IRecuperarReceitaPorIdUseCase
{
    private readonly IConexaoReadOnlyRepositorio _conexoesRepositorio;
    private readonly IReceitaReadOnlyRepositorio _repositorio;
    private readonly IUsuarioLogado _usuarioLogado;
    private readonly IMapper _mapper;

    public RecuperarReceitaPorIdUseCase(
        IReceitaReadOnlyRepositorio repositorio,
        IUsuarioLogado usuarioLogado,
        IMapper mapper,
        IConexaoReadOnlyRepositorio conexoesRepositorio)
    {
        _mapper = mapper;
        _repositorio = repositorio;
        _usuarioLogado = usuarioLogado;
        _conexoesRepositorio = conexoesRepositorio;
    }
    
    public async Task<RespostaReceitaJson> Executar(long id)
    {
        var usuarioLogado = await _usuarioLogado.RecuperarUsuario();

        var receita = await _repositorio.RecuperarPorId(id);

        await Validar(usuarioLogado, receita);

        return _mapper.Map<RespostaReceitaJson>(receita);
    }

    public async Task Validar(Domain.Entidades.Usuario usuarioLogado, Domain.Entidades.Receita receita)
    {
        var usuariosConectados = await _conexoesRepositorio.RecuperarDoUsuario(usuarioLogado.Id);

        if (receita is null || (receita.UsuarioId != usuarioLogado.Id && !usuariosConectados.Any(c => c.Id == receita.UsuarioId)))
        {
            throw new ErrosDeValidacaoException(new List<string> { ResourceMensagensDeErro.RECEITA_NAO_ENCONTRADA});
        }
    }
}
