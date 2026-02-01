using AMLRS.Core.Domains.OrganisationAdmins.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
