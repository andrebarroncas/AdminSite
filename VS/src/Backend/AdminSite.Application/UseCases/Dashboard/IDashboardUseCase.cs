using AdminSite.Comunicacao.Requisicoes;
using AdminSite.Comunicacao.Respostas;

namespace AdminSite.Application.UseCases.Dashboard;
public interface IDashboardUseCase
{
    Task<RespostaDashboardJson> Executar(RequisicaoDashboardJson requisicao);
}
