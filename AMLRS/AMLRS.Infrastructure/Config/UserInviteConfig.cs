using AMLRS.Core.Domains.Users.Entities.Register;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AMLRS.Infrastructure.Config
{
    public class UserInviteConfig : IEntityTypeConfiguration<UserInvite>
    {
        public void Configure(EntityTypeBuilder<UserInvite> builder)
        {
            builder.ToTable(nameof(UserInvite));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(e => e.Role)
                .HasConversion<string>();

        }
    }
}
