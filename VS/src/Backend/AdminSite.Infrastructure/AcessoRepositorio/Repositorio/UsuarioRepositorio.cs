﻿using AdminSite.Domain.Entidades;
using AdminSite.Domain.Repositorios.Usuario;
using Microsoft.EntityFrameworkCore;

namespace AdminSite.Infrastructure.AcessoRepositorio.Repositorio;

public class UsuarioRepositorio : IUsuarioWriteOnlyRepositorio, IUsuarioReadOnlyRepositorio, IUsuarioUpdateOnlyRepositorio
{
    private readonly AdminSiteContext _contexto;

    public UsuarioRepositorio(AdminSiteContext contexto)
    {
        _contexto = contexto;
    }

    public async Task Adicionar(Usuario usuario)
    {
        await _contexto.Usuarios.AddAsync(usuario);
    }

    public async Task<bool> ExisteUsuarioComEmail(string email)
    {
        return await _contexto.Usuarios.AnyAsync(c => c.Email.Equals(email));
    }

    public async Task<Usuario> RecuperarPorEmail(string email)
    {
        return await _contexto.Usuarios.AsNoTracking()
            .FirstOrDefaultAsync(c => c.Email.Equals(email));
    }

    public async Task<Usuario> RecuperarPorEmailSenha(string email, string senha)
    {
        return await _contexto.Usuarios.AsNoTracking()
            .FirstOrDefaultAsync(c => c.Email.Equals(email) && c.Senha.Equals(senha));
    }

    public async Task<Usuario> RecuperarPorId(long id)
    {
        return await _contexto.Usuarios.FirstOrDefaultAsync(c => c.Id == id);
    }

    public void Update(Usuario usuario)
    {
        _contexto.Usuarios.Update(usuario);
    }
}
