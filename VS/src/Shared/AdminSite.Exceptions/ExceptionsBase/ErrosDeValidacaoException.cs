using System.Runtime.Serialization;

namespace AdminSite.Exceptions.ExceptionsBase;

[Serializable]
public class ErrosDeValidacaoException : AdminSiteException
{
    public List<string> MensagensDeErro { get; set; }

    public ErrosDeValidacaoException(List<string> mensagensDeErro) : base(string.Empty)
    {
        MensagensDeErro = mensagensDeErro;
    }

    protected ErrosDeValidacaoException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
