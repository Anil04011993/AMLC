using AMLRS.Application.Extentions;
using AMLRS.Application.Interfaces.Services.User;
using AMLRS.Core.Abstraction.Reposotory.User;
using AMLRS.Core.Domains.Users.Entities.Register;

namespace AMLRS.Application.Services.User
{
    public class UserInviteService : IUserInviteService
    {
        private readonly IUserInviteRepository _repo;
        private readonly IEmailSender _email;

        public UserInviteService(IUserInviteRepository repo, IEmailSender email)
        {
            _repo = repo;
            _email = email;
        }

        public async Task InviteUserAsync(string email, string role)
        {
            var token = Guid.NewGuid().ToString();

            var invite = new UserInvite
            {
                Email = email,
                InviteToken = token,
                ExpiresAt = DateTime.UtcNow.AddDays(1),
                Role = ParseRole.TryParseRole(role),
                IsUsed = false
            };

            await _repo.AddAsync(invite);

            var link = $"https://localhost:7174/api/signup?token={token}&role={role}";


            var subject = "You're invited to AMLRS";
            var body =
                $"""
                Hello,
                You have been invited to AMLRS.
                Click the link below to activate your account:
                {link}
                This link expires in 24 hours.
                If you did not expect this email, please ignore it.
                """;

            await _email.SendAsync(
                email,
                subject,
                body);
        }
    }

}
