using AdminSite.Comunicacao.Respostas;

namespace AdminSite.Application.UseCases.Conexao.QRCodeLido;
public interface IQRCodeLidoUseCase
{
    Task<(RespostaUsuarioConexaoJson usuarioParaSeConectar, string idUsuarioQueGerouQRCode)> Executar(string codigoConexao);
}
