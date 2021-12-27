using Server.Domain;

namespace Server;

public class ErrorFilter : IErrorFilter
{
    private static readonly Dictionary<Type, string> Codes = new()
    {
        { typeof(CustomDomainException), "CUSTOM_ERROR_CODE" }
    };

    public IError OnError(IError error)
    {
        if (error.Exception is null) return error;

        var exceptionType = error.Exception.GetType();
        if (Codes.ContainsKey(exceptionType))
        {
            return ErrorBuilder.FromError(error)
                .SetCode(Codes[exceptionType])
                .SetMessage(error.Exception.Message)
                .Build();
        }

        return error;
    }
}