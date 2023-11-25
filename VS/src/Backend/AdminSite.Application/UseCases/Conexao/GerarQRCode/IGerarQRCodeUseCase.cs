using System.Drawing;

namespace AdminSite.Application.UseCases.Conexao.GerarQRCode;
public interface IGerarQRCodeUseCase
{
    Task<(byte[] qrCode, string idUsuario)> Executar();
}
