using System.Net;
using HotChocolate.AspNetCore.Serialization;
using HotChocolate.Execution;

namespace Server;

public class CustomHttpResultSerializer : DefaultHttpResultSerializer
{
    public override HttpStatusCode GetStatusCode(IExecutionResult result)
    {
        return result switch
        {
            QueryResult queryResult => GetCustomStatusCode(queryResult),
            DeferredQueryResult => HttpStatusCode.OK,
            BatchQueryResult => HttpStatusCode.OK,
            _ => HttpStatusCode.InternalServerError
        };
    }

    private HttpStatusCode GetCustomStatusCode(QueryResult queryResult)
    {
        if (queryResult.Data is not null)
            return HttpStatusCode.OK;

        var firstError = queryResult.Errors?.FirstOrDefault();
        if (firstError is not null && firstError.Code == "CUSTOM_ERROR_CODE")
            return HttpStatusCode.OK;

        return GetStatusCode(queryResult);
    }
}