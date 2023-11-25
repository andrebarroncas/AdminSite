using FluentValidation;
using AdminSite.Comunicacao.Requisicoes;

namespace AdminSite.Application.UseCases.Usuario.AlterarSenha
{
    public class AlterarSenhaValidator : AbstractValidator<RequisicaoAlterarSenhaJson>
    {
        public AlterarSenhaValidator()
        {
            RuleFor(c => c.NovaSenha).SetValidator(new SenhaValidator());
        }
    }
}
