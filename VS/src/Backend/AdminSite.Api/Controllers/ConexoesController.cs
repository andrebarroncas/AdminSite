using AdminSite.Api.Binder;
using AdminSite.Api.Filtros.UsuarioLogado;
using AdminSite.Application.UseCases.Conexao.Recuperar;
using AdminSite.Application.UseCases.Conexao.Remover;
using AdminSite.Comunicacao.Respostas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AdminSite.Api.Controllers;

[ServiceFilter(typeof(UsuarioAutenticadoAttribute))]
public class ConexoesController : AdminSiteController
{
    [HttpGet]
    [ProducesResponseType(typeof(RespostaConexoesDoUsuarioJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> RecuperarConexoes([FromServices] IRecuperarTodasConexoesUseCase useCase)
    {
        var resultado = await useCase.Executar();

        if (resultado.Usuarios.Any())
        {
            return Ok(resultado);
        }

        return NoContent();
    }

    [HttpDelete]
    [Route("{id:hashids}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Deletar(
        [FromServices] IRemoverConexaoUseCase useCase,
        [FromRoute][ModelBinder(typeof(HashidsModelBinder))] long id)
    {
        await useCase.Executar(id);

        return NoContent();
    }
}