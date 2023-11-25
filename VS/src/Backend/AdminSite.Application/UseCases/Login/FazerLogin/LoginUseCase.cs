﻿using AdminSite.Application.Servicos.Criptografia;
using AdminSite.Application.Servicos.Token;
using AdminSite.Comunicacao.Requisicoes;
using AdminSite.Comunicacao.Respostas;
using AdminSite.Domain.Repositorios.Usuario;
using AdminSite.Exceptions.ExceptionsBase;

namespace AdminSite.Application.UseCases.Login.FazerLogin;

public class LoginUseCase : ILoginUseCase
{
    private readonly IUsuarioReadOnlyRepositorio _usuarioReadOnlyRepositorio;
    private readonly EncriptadorDeSenha _encriptadorDeSenha;
    private readonly TokenController _tokenController;
    public LoginUseCase(IUsuarioReadOnlyRepositorio usuarioReadOnlyRepositorio, EncriptadorDeSenha encriptadorDeSenha, TokenController tokenController)
    {
        _usuarioReadOnlyRepositorio = usuarioReadOnlyRepositorio;
        _encriptadorDeSenha = encriptadorDeSenha;
        _tokenController = tokenController;
    }

    public async Task<RespostaLoginJson> Executar(RequisicaoLoginJson request)
    {
        var senhaCriptografada = _encriptadorDeSenha.Criptografar(request.Senha);

        var usuario = await _usuarioReadOnlyRepositorio.RecuperarPorEmailSenha(request.Email, senhaCriptografada);

        if (usuario is null)
        {
            throw new LoginInvalidoException();
        }

        return new RespostaLoginJson
        {
            Nome = usuario.Nome,
            Token = _tokenController.GerarToken(usuario.Email)
        };
    }
}
