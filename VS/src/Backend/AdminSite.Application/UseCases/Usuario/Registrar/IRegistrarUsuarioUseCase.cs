using AdminSite.Comunicacao.Requisicoes;
using AdminSite.Comunicacao.Respostas;

namespace AdminSite.Application.UseCases.Usuario.Registrar;

public interface IRegistrarUsuarioUseCase
{
    Task<RespostaUsuarioRegistradoJson> Executar(RequisicaoRegistrarUsuarioJson requisicao);
}
