using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using Serilog.Filters;

namespace AMLRS.Infrastructure.Logging
{   
    public static class SerilogConfiguration
    {
        public static void Configure(IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("System", LogEventLevel.Warning)
                .MinimumLevel.Information()

                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .Enrich.WithThreadId()
                .Enrich.WithEnvironmentName()

                //// Runtime logs
                .WriteTo.Console()

                //// File logs (warnings+)
                //.WriteTo.File(
                //    "logs/app-.log",
                //    rollingInterval: RollingInterval.Day,
                //    restrictedToMinimumLevel: LogEventLevel.Warning)

                // Audit logs (filtered)
                .WriteTo.Logger(lc => lc
                    .Filter.ByIncludingOnly(
                        Matching.WithProperty("IsAudit", true))
                    .WriteTo.MSSqlServer(
                        configuration.GetConnectionString("devCS"),
                        sinkOptions: new()
                        {
                            TableName = "AuditLogs",
                            AutoCreateSqlTable = false
                        }))

                .CreateLogger();
        }
    }

}
