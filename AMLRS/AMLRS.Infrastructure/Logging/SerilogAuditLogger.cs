using AMLRS.Application.Interfaces.Log;
using Serilog;

namespace AMLRS.Infrastructure.Logging
{
  
    public class SerilogAuditLogger : IAuditLogger
    {
        private readonly ILogger _logger;

        public SerilogAuditLogger(ILogger logger)
        {
            _logger = logger;
        }

        public void Log(
            string userId,
            string action,
            string entityType,
            string entityId,
            object? oldValue = null,
            object? newValue = null)
        {
            _logger
                .ForContext("UserId", userId)
                .ForContext("Action", action)
                .ForContext("EntityType", entityType)
                .ForContext("EntityId", entityId)
                .ForContext("OldValue", oldValue, true)
                .ForContext("NewValue", newValue, true)
                .Information("Audit event");
        }
    }

}
