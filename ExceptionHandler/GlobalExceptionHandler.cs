using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> _log) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        _log.LogError(exception, "Unhandled Exception occurred");

        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        var exceptionDetails = new ProblemDetails
        {
            Title = "Unhandled Exception Occurred",
            Status = StatusCodes.Status500InternalServerError,
            Detail = "An unexpected Error occurred, contact HelpDesk"
        };
        await httpContext.Response.WriteAsJsonAsync(exceptionDetails, cancellationToken);

        return true;
    }
}