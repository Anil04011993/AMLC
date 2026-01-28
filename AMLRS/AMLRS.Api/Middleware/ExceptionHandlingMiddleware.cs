namespace AMLRS.Api.Middleware
{
    using System.Net;
    using System.Text.Json;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;

    namespace AMLRS.Api.Middleware
    {
        public sealed class ExceptionHandlingMiddleware
        {
            private readonly RequestDelegate _next;
            private readonly ILogger<ExceptionHandlingMiddleware> _logger;

            public ExceptionHandlingMiddleware(
                RequestDelegate next,
                ILogger<ExceptionHandlingMiddleware> logger)
            {
                _next = next;
                _logger = logger;
            }

            public async Task InvokeAsync(HttpContext context)
            {
                try
                {
                    await _next(context);
                }
                catch (OperationCanceledException) when (context.RequestAborted.IsCancellationRequested)
                {
                    // Client disconnected – do not treat as error
                    _logger.LogWarning(
                        "Request cancelled by client. Path={Path}",
                        context.Request.Path);

                    context.Response.StatusCode = StatusCodes.Status499ClientClosedRequest;
                }
                catch (Exception ex)
                {
                    _logger.LogError(
                        ex,
                        "Unhandled exception occurred. Path={Path}, Method={Method}",
                        context.Request.Path,
                        context.Request.Method);

                    await WriteErrorResponseAsync(context);
                }
            }

            private static async Task WriteErrorResponseAsync(HttpContext context)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = new
                {
                    title = "An unexpected error occurred.",
                    status = context.Response.StatusCode,
                    traceId = context.TraceIdentifier
                };

                await context.Response.WriteAsync(
                    JsonSerializer.Serialize(response));
            }
        }
    }

}
