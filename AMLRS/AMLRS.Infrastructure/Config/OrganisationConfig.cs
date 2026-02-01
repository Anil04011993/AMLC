using AMLRS.Core.Domains.Admin.Entites;
using AMLRS.Core.Domains.Admin.Entities;
using AMLRS.Core.Domains.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Infrastructure.Config
{
    public class OrganisationConfig : IEntityTypeConfiguration<Organisation>
    {
        public void Configure(EntityTypeBuilder<Organisation> builder)
        {
            builder.ToTable(nameof(Organisation));
            builder.HasKey(x => x.OrgId);
            builder.Property(x => x.OrgId).UseIdentityColumn();
        }
    }
}
