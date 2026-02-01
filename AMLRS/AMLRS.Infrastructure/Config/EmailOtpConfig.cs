using AMLRS.Core.Domains.Users.Entities.Register;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AMLRS.Infrastructure.Config
{
    public class EmailOtpConfig : IEntityTypeConfiguration<EmailOtp>
    {
        public void Configure(EntityTypeBuilder<EmailOtp> builder)
        {
            builder.ToTable(nameof(EmailOtp));
            builder.HasKey(x => x.OtpId);
            builder.Property(x => x.OtpId).UseIdentityColumn();
        }
    }
}
