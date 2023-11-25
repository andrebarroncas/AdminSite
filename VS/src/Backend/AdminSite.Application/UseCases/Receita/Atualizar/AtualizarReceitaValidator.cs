using FluentValidation;
using AdminSite.Comunicacao.Requisicoes;

namespace AdminSite.Application.UseCases.Receita.Atualizar;
public class AtualizarReceitaValidator : AbstractValidator<RequisicaoReceitaJson>
{
    public AtualizarReceitaValidator()
    {
        RuleFor(x => x).SetValidator(new ReceitaValidator());
    }
}
