namespace AMLRS.Api.Middleware
{
    public sealed class CorrelationIdMiddleware
    {
        private readonly RequestDelegate _next;

        public CorrelationIdMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            using (Serilog.Context.LogContext.PushProperty(
                "CorrelationId",
                context.TraceIdentifier))
            {
                await _next(context);
            }
        }
    }

}
