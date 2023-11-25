using AdminSite.Comunicacao.Requisicoes;

namespace AdminSite.Application.UseCases.Usuario.AlterarSenha;

public interface IAlterarSenhaUseCase
{
    Task Executar(RequisicaoAlterarSenhaJson requisicao);
}
