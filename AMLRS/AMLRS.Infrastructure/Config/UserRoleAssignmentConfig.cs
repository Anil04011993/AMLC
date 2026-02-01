using AMLRS.Core.Domains.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AMLRS.Infrastructure.Config
{
    public class UserRoleAssignmentConfig : IEntityTypeConfiguration<UserRoleAssignment>
    {
        public void Configure(EntityTypeBuilder<UserRoleAssignment> builder)
        {
            builder.ToTable(nameof(UserRoleAssignment));
            builder.HasKey(x => x.UserRoleAssignmentId);
            builder.Property(x => x.UserRoleAssignmentId).UseIdentityColumn();
        }
    }
}
