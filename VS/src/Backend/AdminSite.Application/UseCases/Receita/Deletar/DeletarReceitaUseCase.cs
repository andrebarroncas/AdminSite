﻿using AdminSite.Application.Servicos.UsuarioLogado;
using AdminSite.Domain.Repositorios;
using AdminSite.Domain.Repositorios.Receita;
using AdminSite.Exceptions;
using AdminSite.Exceptions.ExceptionsBase;

namespace AdminSite.Application.UseCases.Receita.Deletar;
public class DeletarReceitaUseCase : IDeletarReceitaUseCase
{
    private readonly IReceitaWriteOnlyRepositorio _repositorioWriteOnly;
    private readonly IReceitaReadOnlyRepositorio _repositorioReadOnly;
    private readonly IUsuarioLogado _usuarioLogado;
    private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;

    public DeletarReceitaUseCase(
        IReceitaReadOnlyRepositorio repositorioReadOnly,
        IReceitaWriteOnlyRepositorio repositorioWriteOnly,
        IUsuarioLogado usuarioLogado,
        IUnidadeDeTrabalho unidadeDeTrabalho)
    {
        _unidadeDeTrabalho = unidadeDeTrabalho;
        _usuarioLogado = usuarioLogado;
        _repositorioReadOnly = repositorioReadOnly;
        _repositorioWriteOnly = repositorioWriteOnly;
    }
    
    public async Task Executar(long id)
    {
        var usuarioLogado = await _usuarioLogado.RecuperarUsuario();

        var receita = await _repositorioReadOnly.RecuperarPorId(id);

        Validar(usuarioLogado, receita);

        await _repositorioWriteOnly.Deletar(id);

        await _unidadeDeTrabalho.Commit();
    }

    public static void Validar(Domain.Entidades.Usuario usuarioLogado, Domain.Entidades.Receita receita)
    {
        if (receita is null || receita.UsuarioId != usuarioLogado.Id)
        {
            throw new ErrosDeValidacaoException(new List<string> { ResourceMensagensDeErro.RECEITA_NAO_ENCONTRADA });
        }
    }
}
