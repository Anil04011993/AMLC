using AMLRS.Core.Domains.Cases.Entities;
using AMLRS.Core.Domains.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Infrastructure.Config
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(x => x.RoleId).UseIdentityColumn();
            builder.ToTable(nameof(Role));
            builder.HasKey(x => x.RoleId);
            builder.Property(e => e.RoleName)
                 .HasConversion<string>();
        }
    }
}
