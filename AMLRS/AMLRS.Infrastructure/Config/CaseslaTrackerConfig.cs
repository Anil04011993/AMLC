using AMLRS.Core.Domains.Cases.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Infrastructure.Config
{
    public class CaseslaTrackerConfig : IEntityTypeConfiguration<CaseSlaTracker>
    {
        public void Configure(EntityTypeBuilder<CaseSlaTracker> builder)
        {
            builder.ToTable(nameof(CaseSlaTracker));
            builder.HasKey(x => x.SlaTrackerId);

            builder.Property(x => x.SlaTrackerId).UseIdentityColumn();
            builder.HasData(new List<CaseSlaTracker>()
            {
                new CaseSlaTracker
                {
                    SlaTrackerId = "66666666",
                    CaseId = "C20240901",
                    DueDate = new DateTime(2025, 01, 17),
                    IsBreached = false
                }
            });
        }
    }
}
