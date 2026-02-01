using AMLRS.Core.Domains.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AMLRS.Infrastructure.Config
{
    public class UserConfig : IEntityTypeConfiguration<Usertbl>
    {
        public void Configure(EntityTypeBuilder<Usertbl> builder)
        {
            builder.ToTable(nameof(Usertbl));
            builder.HasKey(x => x.UserId);
           
            builder.Property(x => x.UserId).UseIdentityColumn();

            //builder.HasOne(e => e.Auth_and_Security)
            //    .WithOne(i => i.User)
            //    .HasForeignKey<Auth_and_Security>(i => i.UserId)
            //    .OnDelete(DeleteBehavior.Cascade);
            //builder.HasOne(e => e.Role_and_permission)
            //    .WithOne(i => i.User)
            //    .HasForeignKey<Role_and_permission>(i => i.UserId)
            //    .OnDelete(DeleteBehavior.Cascade);
            //builder.HasOne(e => e.Notification_and_preferences)
            //    .WithOne(i => i.User)
            //    .HasForeignKey<Notification_and_preferences>(i => i.UserId)
            //    .OnDelete(DeleteBehavior.Cascade);
            //builder.HasOne(e => e.Compliance_Training)
            //    .WithOne(i => i.User)
            //    .HasForeignKey<Compliance_Training>(i => i.UserId)
            //    .OnDelete(DeleteBehavior.Cascade);
            //builder.HasOne(e => e.Audit_Metadata)
            //   .WithOne(i => i.User)
            //   .HasForeignKey<Audit_Metadata>(i => i.UserId)
            //   .OnDelete(DeleteBehavior.Cascade);
            //builder.HasOne(e => e.Optional_UX_Enhancements)
            //   .WithOne(i => i.User)
            //   .HasForeignKey<Optional_UX_Enhancements>(i => i.UserId)
            //   .OnDelete(DeleteBehavior.Cascade);
            //builder.HasOne(e => e.Access_Control_ABAC)
            //   .WithOne(i => i.User)
            //   .HasForeignKey<Access_Control>(i => i.UserId)
            //   .OnDelete(DeleteBehavior.Cascade);
            //builder.HasOne(e => e.Governance_Compliance_Metadata)
            //   .WithOne(i => i.User)
            //   .HasForeignKey<Governance_Compliance_Metadata>(i => i.UserId)
            //   .OnDelete(DeleteBehavior.Cascade);
            //builder.HasOne(e => e.Operational_Behavior_Signals)
            // .WithOne(i => i.User)
            // .HasForeignKey<Operational_Behavior_Signals>(i => i.UserId)
            // .OnDelete(DeleteBehavior.Cascade);
            //builder.HasOne(e => e.Integration_External_Identity)
            // .WithOne(i => i.User)
            // .HasForeignKey<Integration_External_Identity>(i => i.UserId)
            // .OnDelete(DeleteBehavior.Cascade);
            //builder.HasOne(e => e.Notifications_Alerts)
            // .WithOne(i => i.User)
            // .HasForeignKey<Notifications_Alerts>(i => i.UserId)
            // .OnDelete(DeleteBehavior.Cascade);
            //builder.HasOne(e => e.Localization_UX)
            // .WithOne(i => i.User)
            // .HasForeignKey<Localization_UX>(i => i.UserId)
            // .OnDelete(DeleteBehavior.Cascade);

            //builder.HasOne(e => e.Decommission_Lifecycle)
            // .WithOne(i => i.User)
            // .HasForeignKey<Decommission_Lifecycle>(i => i.UserId)
            // .OnDelete(DeleteBehavior.Cascade);


            //builder.Property(x => x.UserId).UseIdentityColumn();
            //builder.HasData(new List<User>() {
            //    new User
            //    {
            //        UserId = "UserSarahChen",
            //        FirstName = "Sarah",
            //        LastName = "Chen",
            //        Email = "sarah.chen@amlrs.com",
            //        //CreatedAt = DateTime.UtcNow
            //    },
            //    new User
            //    {
            //        UserId = "UserMichaelTorres",
            //        FirstName = "Michael",
            //        LastName = "Torres",
            //        Email = "michael.torres@amlrs.com",
            //        //CreatedAt = DateTime.UtcNow
            //    }
            //});
        }
    }
}
