using AdminSite.Comunicacao.Enum;

namespace AdminSite.Comunicacao.Requisicoes;
public class RequisicaoDashboardJson
{
    public string TituloOuIngrediente { get; set; }
    public Categoria? Categoria { get; set; }
}
