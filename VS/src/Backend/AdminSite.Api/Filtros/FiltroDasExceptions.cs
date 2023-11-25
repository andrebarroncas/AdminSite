using AdminSite.Comunicacao.Respostas;
using AdminSite.Exceptions;
using AdminSite.Exceptions.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace AdminSite.Api.Filtros;

public class FiltroDasExceptions : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is AdminSiteException)
        {
            TratarAdminSiteException(context);
        }
        else
        {
            LancarErroDesconhecido(context);
        }
    }
    
    private static void TratarAdminSiteException(ExceptionContext context)
    {
        if (context.Exception is ErrosDeValidacaoException)
        {
            TratarErrosDeValidacaoException(context);
        }
        else if (context.Exception is LoginInvalidoException)
        {
            TratarLoginException(context);
        }
    }

    private static void TratarErrosDeValidacaoException(ExceptionContext context)
    {
        var erroDeValidacaoException = context.Exception as ErrosDeValidacaoException;
        
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        context.Result = new ObjectResult(new RespostaErroJson(erroDeValidacaoException.MensagensDeErro));
    }

    private static void TratarLoginException(ExceptionContext context)
    {
        var erroLogin = context.Exception as LoginInvalidoException;
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        context.Result = new ObjectResult(new RespostaErroJson(erroLogin.Message));
    }

    private static void LancarErroDesconhecido(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Result = new ObjectResult(new RespostaErroJson(ResourceMensagensDeErro.ERRO_DESCONHECIDO));
    }
}
