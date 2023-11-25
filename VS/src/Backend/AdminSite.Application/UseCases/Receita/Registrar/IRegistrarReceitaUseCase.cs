using AdminSite.Comunicacao.Requisicoes;
using AdminSite.Comunicacao.Respostas;

namespace AdminSite.Application.UseCases.Receita.Registrar;
public interface IRegistrarReceitaUseCase
{
    Task<RespostaReceitaJson> Executar(RequisicaoReceitaJson requisicao);
}
