﻿namespace AdminSite.Domain.Entidades;
public class Conexao : EntidadeBase
{
    public long UsuarioId { get; set; }
    public long ConectadoComUsuarioId { get; set; }
    public virtual Usuario ConectadoComUsuario { get; set; }
}
