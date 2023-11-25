using FluentValidation;
using AdminSite.Comunicacao.Requisicoes;

namespace AdminSite.Application.UseCases.Receita.Registrar;
public class RegistrarReceitaValidator : AbstractValidator<RequisicaoReceitaJson>
{
    public RegistrarReceitaValidator()
    {
        RuleFor(x => x).SetValidator(new ReceitaValidator());
    }
}
