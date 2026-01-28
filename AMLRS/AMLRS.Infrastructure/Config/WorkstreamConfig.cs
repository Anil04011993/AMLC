using AMLRS.Core.Domains.Cases.Entities;
using AMLRS.Core.Domains.Cases.Enums;
using AMLRS.Core.Domains.Documents.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Infrastructure.Config
{
    public class WorkstreamConfig : IEntityTypeConfiguration<Workstream>
    {
        public void Configure(EntityTypeBuilder<Workstream> builder)
        {
            builder.ToTable(nameof(Workstream));
            builder.HasKey(x => x.WorkstreamId);

            builder.Property(e => e.Type)
                   .HasConversion<string>();

            builder.Property(e => e.Status)
                   .HasConversion<string>();

            builder
            .HasOne(w => w.Case)
            .WithMany(e => e.Workstreams)
            .HasForeignKey(w => w.CaseId)
            .HasPrincipalKey(e => e.CaseId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(new List<Workstream>()
            {
                  new Workstream{WorkstreamId = "WS-001", CaseId = "C-2024-0901", Type = ServiceType.KYCCase, Status = CaseStatus.New, Maker = "Michael Torres", Owner = "Sarah Chen"},
                  new Workstream{WorkstreamId = "WS-002", CaseId = "C-2024-0901",  Type = ServiceType.TransactionMonitoring, Status = CaseStatus.InProgress, Maker = "Michael Torres", Owner = "Sarah Chen" },
                  new Workstream{WorkstreamId = "WS-003", CaseId = "C-2024-0901", Type = ServiceType.ClientOutreach, Status = CaseStatus.Rejected, Maker = "Michael Torres", Owner = "Sarah Chen" },
                  new Workstream{WorkstreamId = "WS-004", CaseId = "C-2024-0902", Type = ServiceType.KYCCase, Status = CaseStatus.New, Maker = "Michael Torres", Owner = "Sarah Chen"},
                  new Workstream{WorkstreamId = "WS-005", CaseId = "C-2024-0902", Type = ServiceType.TransactionMonitoring, Status = CaseStatus.InProgress, Maker = "Michael Torres", Owner = "Sarah Chen" },
                  new Workstream{WorkstreamId = "WS-006", CaseId = "C-2024-0902", Type = ServiceType.ClientOutreach, Status = CaseStatus.Rejected, Maker = "Michael Torres", Owner = "Sarah Chen" },
                  new Workstream{WorkstreamId = "WS-007", CaseId = "C-2024-9802", Type = ServiceType.KYCCase, Status = CaseStatus.New},
                  new Workstream{WorkstreamId = "WS-008", CaseId = "C-2024-9802", Type = ServiceType.TransactionMonitoring, Status = CaseStatus.InProgress},
                  new Workstream{WorkstreamId = "WS-009", CaseId = "C-2024-9802", Type = ServiceType.ClientOutreach, Status = CaseStatus.Rejected},
                  new Workstream{WorkstreamId = "WS-010", CaseId = "C-2024-9811", Type = ServiceType.KYCCase, Status = CaseStatus.New},
                  new Workstream{WorkstreamId = "WS-011", CaseId = "C-2024-9811", Type = ServiceType.TransactionMonitoring, Status = CaseStatus.InProgress},
                  new Workstream{WorkstreamId = "WS-012", CaseId = "C-2024-9811", Type = ServiceType.ClientOutreach, Status = CaseStatus.Rejected},

            });
        }

        
    }
}
