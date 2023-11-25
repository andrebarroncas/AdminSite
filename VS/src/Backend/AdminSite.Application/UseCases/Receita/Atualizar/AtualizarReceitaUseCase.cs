﻿using AutoMapper;
using AdminSite.Application.Servicos.UsuarioLogado;
using AdminSite.Comunicacao.Requisicoes;
using AdminSite.Domain.Repositorios;
using AdminSite.Domain.Repositorios.Receita;
using AdminSite.Exceptions;
using AdminSite.Exceptions.ExceptionsBase;

namespace AdminSite.Application.UseCases.Receita.Atualizar;
public class AtualizarReceitaUseCase : IAtualizarReceitaUseCase
{
    private readonly IReceitaUpdateOnlyRepositorio _repositorio;
    private readonly IUsuarioLogado _usuarioLogado;
    private readonly IMapper _mapper;
    private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;

    public AtualizarReceitaUseCase(IReceitaUpdateOnlyRepositorio repositorio, IUsuarioLogado usuarioLogado, IMapper mapper, IUnidadeDeTrabalho unidadeDeTrabalho)
    {
        _mapper = mapper;
        _repositorio = repositorio;
        _usuarioLogado = usuarioLogado;
        _unidadeDeTrabalho = unidadeDeTrabalho;
    }

    public async Task Executar(long id, RequisicaoReceitaJson requisicao)
    {
        var usuarioLogado = await _usuarioLogado.RecuperarUsuario();

        var receita = await _repositorio.RecuperarPorId(id);

        Validar(usuarioLogado, receita, requisicao);

        _mapper.Map(requisicao, receita);

        _repositorio.Update(receita);

        await _unidadeDeTrabalho.Commit();
    }

    public static void Validar(Domain.Entidades.Usuario usuarioLogado, Domain.Entidades.Receita receita, RequisicaoReceitaJson requisicao)
    {
        if (receita is null || receita.UsuarioId != usuarioLogado.Id)
        {
            throw new ErrosDeValidacaoException(new List<string> { ResourceMensagensDeErro.RECEITA_NAO_ENCONTRADA });
        }

        var validator = new AtualizarReceitaValidator();
        var resultado = validator.Validate(requisicao);

        if (!resultado.IsValid)
        {
            var mensagesDeErro = resultado.Errors.Select(c => c.ErrorMessage).ToList();
            throw new ErrosDeValidacaoException(mensagesDeErro);
        }
    }
}
