namespace AMLRS.Application.Interfaces.Log
{
    public interface IAuditLogger
    {
        void Log(
            string userId,
            string action,
            string entityType,
            string entityId,
            object? oldValue = null,
            object? newValue = null);
    }

}
