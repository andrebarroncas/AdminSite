using AdminSite.Domain.Entidades;
using AdminSite.Domain.Repositorios.Codigo;
using Microsoft.EntityFrameworkCore;

namespace AdminSite.Infrastructure.AcessoRepositorio.Repositorio;
public class CodigoRepositorio : ICodigoWriteOnlyRepositorio, ICodigoReadOnlyRepositorio
{
    private readonly AdminSiteContext _contexto;

    public CodigoRepositorio(AdminSiteContext contexto)
    {
        _contexto = contexto;
    }

    public async Task Deletar(long usuarioId)
    {
        var codigos = await _contexto.Codigos.Where(c => c.UsuarioId == usuarioId).ToListAsync();

        if (codigos.Any())
        {
            _contexto.Codigos.RemoveRange(codigos);
        }
    }

    public async Task<Codigos> RecuperarEntidadeCodigo(string codigo)
    {
        return await _contexto.Codigos.AsNoTracking()
            .FirstOrDefaultAsync(c => c.Codigo == codigo);
    }

    public async Task Registrar(Codigos codigo)
    {
        var codigoBancoDeDados = await _contexto.Codigos.FirstOrDefaultAsync(c => c.UsuarioId == codigo.UsuarioId);
        if (codigoBancoDeDados is not null)
        {
            codigoBancoDeDados.Codigo = codigo.Codigo;
            _contexto.Codigos.Update(codigoBancoDeDados);
        }
        else
        {
            await _contexto.Codigos.AddAsync(codigo);
        }
    }
}
