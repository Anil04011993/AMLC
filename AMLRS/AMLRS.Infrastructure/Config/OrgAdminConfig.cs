using AMLRS.Core.Domains.Admin.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AMLRS.Infrastructure.Config
{
    public class OrgAdminConfig : IEntityTypeConfiguration<OrgAdmin>
    {
        public void Configure(EntityTypeBuilder<OrgAdmin> builder)
        {
            builder.ToTable(nameof(OrgAdmin));
            builder.HasKey(x => x.AdminId);
            builder.Property(x => x.AdminId).UseIdentityColumn();
            builder.Property(e => e.Role)
                .HasConversion<string>();

        }
    }
}
