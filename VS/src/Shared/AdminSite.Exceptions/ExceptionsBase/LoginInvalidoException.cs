using System.Runtime.Serialization;

namespace AdminSite.Exceptions.ExceptionsBase;

[Serializable]
public class LoginInvalidoException : AdminSiteException
{
    public LoginInvalidoException() : base(ResourceMensagensDeErro.LOGIN_INVALIDO)
    {
    }

    protected LoginInvalidoException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
