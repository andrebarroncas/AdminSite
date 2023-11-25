using AdminSite.Api.Filtros.UsuarioLogado;
using AdminSite.Application.UseCases.Dashboard;
using AdminSite.Comunicacao.Requisicoes;
using AdminSite.Comunicacao.Respostas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AdminSite.Api.Controllers
{
    [ServiceFilter(typeof(UsuarioAutenticadoAttribute))]
    public class DashboardController : AdminSiteController
    {
        [HttpPut]
        [ProducesResponseType(typeof(RespostaDashboardJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> RecuperarDashboard(
            [FromServices] IDashboardUseCase useCase,
            [FromBody] RequisicaoDashboardJson request)
        {
            var resultado = await useCase.Executar(request);

            if (resultado.Receitas.Any())
            {
                return Ok(resultado);
            }

            return NoContent();
        }
    }
}