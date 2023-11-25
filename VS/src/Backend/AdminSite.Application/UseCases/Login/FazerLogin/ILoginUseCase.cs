using AdminSite.Comunicacao.Requisicoes;
using AdminSite.Comunicacao.Respostas;

namespace AdminSite.Application.UseCases.Login.FazerLogin;

public interface ILoginUseCase
{
    Task<RespostaLoginJson> Executar(RequisicaoLoginJson request);
}
