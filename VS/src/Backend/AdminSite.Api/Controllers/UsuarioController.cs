using AdminSite.Api.Filtros.UsuarioLogado;
using AdminSite.Application.UseCases.Usuario.AlterarSenha;
using AdminSite.Application.UseCases.Usuario.RecuperarPerfil;
using AdminSite.Application.UseCases.Usuario.Registrar;
using AdminSite.Comunicacao.Requisicoes;
using AdminSite.Comunicacao.Respostas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdminSite.Api.Controllers
{
    public class UsuarioController : AdminSiteController
    {
        [HttpPost]
        [ProducesResponseType(typeof(RespostaUsuarioRegistradoJson), StatusCodes.Status201Created)]
        public async Task<IActionResult> RegistrarUsuario(
            [FromServices] IRegistrarUsuarioUseCase useCase,
            [FromBody] RequisicaoRegistrarUsuarioJson request)
        {
            var resultado = await useCase.Executar(request);

            return Created(string.Empty, resultado);
        }

        [HttpPut]
        [Route("alterar-senha")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ServiceFilter(typeof(UsuarioAutenticadoAttribute))]
        public async Task<IActionResult> AlterarSenha(
            [FromServices] IAlterarSenhaUseCase useCase,
            [FromBody] RequisicaoAlterarSenhaJson request)
        {
            await useCase.Executar(request);

            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(typeof(RespostaPerfilUsuarioJson), StatusCodes.Status200OK)]
        [ServiceFilter(typeof(UsuarioAutenticadoAttribute))]
        public async Task<IActionResult> RecuperarPerfil(
            [FromServices] IRecuperarPerfilUseCase useCase)
        {
            var resultado = await useCase.Executar();

            return Ok(resultado);
        }
    }
}