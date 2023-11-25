using System.Runtime.Serialization;

namespace AdminSite.Exceptions.ExceptionsBase;

[Serializable]
public class AdminSiteException : SystemException
{
    public AdminSiteException(string mensagem) : base(mensagem)
    {
    }

    protected AdminSiteException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}