using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AMLRS.Core.Domains.Audit.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("AuditLogs")]
    public class AuditLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long AuditLogId { get; private set; }

        // =========================
        // Who
        // =========================

        [Required]
        [MaxLength(100)]
        public string UserId { get; private set; } = default!;

        [MaxLength(200)]
        public string? UserName { get; private set; }

        [MaxLength(100)]
        public string? UserRole { get; private set; }

        // =========================
        // What
        // =========================

        [Required]
        [MaxLength(100)]
        public string Action { get; private set; } = default!;

        [Required]
        [MaxLength(100)]
        public string EntityType { get; private set; } = default!;

        [Required]
        [MaxLength(100)]
        public string EntityId { get; private set; } = default!;

        // =========================
        // Context (JSON)
        // =========================

        public string? OldValue { get; private set; }
        public string? NewValue { get; private set; }
        public string? AdditionalData { get; private set; }

        // =========================
        // Technical
        // =========================

        [MaxLength(100)]
        public string? CorrelationId { get; private set; }

        [MaxLength(45)]
        public string? IpAddress { get; private set; }

        [MaxLength(500)]
        public string? UserAgent { get; private set; }

        [Required]
        [MaxLength(50)]
        public string Severity { get; private set; } = default!;

        [Required]
        [MaxLength(100)]
        public string Source { get; private set; } = default!;

        public DateTime CreatedAtUtc { get; private set; }

        private AuditLog() { } // EF Core only

        public AuditLog(
            string userId,
            string action,
            string entityType,
            string entityId,
            string severity,
            string source,
            string? userName = null,
            string? userRole = null,
            string? oldValue = null,
            string? newValue = null,
            string? additionalData = null,
            string? correlationId = null,
            string? ipAddress = null,
            string? userAgent = null)
        {
            UserId = userId;
            Action = action;
            EntityType = entityType;
            EntityId = entityId;
            Severity = severity;
            Source = source;

            UserName = userName;
            UserRole = userRole;
            OldValue = oldValue;
            NewValue = newValue;
            AdditionalData = additionalData;
            CorrelationId = correlationId;
            IpAddress = ipAddress;
            UserAgent = userAgent;

            CreatedAtUtc = DateTime.UtcNow;
        }
    }


}
