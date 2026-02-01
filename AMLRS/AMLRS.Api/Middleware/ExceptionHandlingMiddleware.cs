namespace AMLRS.Api.Middleware
{
    using global::AMLRS.Application.DTOs;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using System.ComponentModel.DataAnnotations;
    using System.Net;
    using System.Text.Json;

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
                catch (UnauthorizedAccessException ex)
                {
                    await WriteErrorResponseAsync(context, StatusCodes.Status401Unauthorized, ex.Message);
                }                
                catch (ValidationException ex)
                {
                    await WriteErrorResponseAsync(context, StatusCodes.Status400BadRequest, ex.Message);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Unhandled exception");
                    await WriteErrorResponseAsync(context, StatusCodes.Status500InternalServerError,
                        "An unexpected error occurred");
                }                
            }

            private static async Task WriteErrorResponseAsync(HttpContext context, int statusCode,string message)
            {
                context.Response.StatusCode = statusCode;
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = new ApiResponse<object>
                {
                    StatusCode = statusCode,
                    Message = message,
                    Data = null
                };

                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }

}
