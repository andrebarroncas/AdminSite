﻿using AdminSite.Domain.Entidades;
using AdminSite.Domain.Repositorios.Receita;
using Microsoft.EntityFrameworkCore;

namespace AdminSite.Infrastructure.AcessoRepositorio.Repositorio;

public class ReceitaRepositorio : IReceitaWriteOnlyRepositorio, IReceitaReadOnlyRepositorio, IReceitaUpdateOnlyRepositorio
{
    private readonly AdminSiteContext _contexto;

    public ReceitaRepositorio(AdminSiteContext contexto)
    {
        _contexto = contexto;
    }

    async Task<Receita> IReceitaReadOnlyRepositorio.RecuperarPorId(long receitaId)
    {
        return await _contexto.Receitas.AsNoTracking()
            .Include(r => r.Ingredientes)
            .FirstOrDefaultAsync(r => r.Id == receitaId);
    }

    async Task<Receita> IReceitaUpdateOnlyRepositorio.RecuperarPorId(long receitaId)
    {
        return await _contexto.Receitas
            .Include(r => r.Ingredientes)
            .FirstOrDefaultAsync(r => r.Id == receitaId);
    }

    public async Task<IList<Receita>> RecuperarTodasDoUsuario(long usuarioId)
    {
        return await _contexto.Receitas.AsNoTracking()
            .Include(r => r.Ingredientes)
            .Where(r => r.UsuarioId == usuarioId).ToListAsync();
    }

    public async Task<IList<Receita>> RecuperarTodasDosUsuarios(List<long> usuarioIds)
    {
        return await _contexto.Receitas.AsNoTracking()
            .Include(r => r.Ingredientes)
            .Where(r => usuarioIds.Contains(r.UsuarioId)).ToListAsync();
    }

    public async Task Registrar(Receita receita)
    {
        await _contexto.Receitas.AddAsync(receita);
    }

    public void Update(Receita receita)
    {
        _contexto.Receitas.Update(receita);
    }

    public async Task Deletar(long receitaId)
    {
        var receita = await _contexto.Receitas.FirstOrDefaultAsync(r => r.Id == receitaId);
        
        _contexto.Receitas.Remove(receita);
    }

    public async Task<int> QuantidadeReceitas(long usuarioId)
    {
        return await _contexto.Receitas.CountAsync(r => r.UsuarioId == usuarioId);
    }
}
