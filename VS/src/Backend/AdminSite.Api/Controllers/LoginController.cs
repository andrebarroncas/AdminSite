using AdminSite.Application.UseCases.Login.FazerLogin;
using AdminSite.Comunicacao.Requisicoes;
using AdminSite.Comunicacao.Respostas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdminSite.Api.Controllers
{
    public class LoginController : AdminSiteController
    {
        [HttpPost]
        [ProducesResponseType(typeof(RespostaLoginJson), StatusCodes.Status200OK)]
        public async Task<IActionResult> Login(
            [FromServices] ILoginUseCase useCase,
            [FromBody] RequisicaoLoginJson requisicao)
        {
            var resposta = await useCase.Executar(requisicao);

            return Ok(resposta);
        }
    }
}
