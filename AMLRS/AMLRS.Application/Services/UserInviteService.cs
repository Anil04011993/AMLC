using AMLRS.Application.Interfaces.Services;
using AMLRS.Core.Abstraction.Reposotory;
using AMLRS.Core.Domains.Users.Entities.Register;

namespace AMLRS.Application.Services
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

        public async Task InviteUserAsync(string email)
        {
            var token = Guid.NewGuid().ToString();

            var invite = new UserInvite
            {
                Id = Guid.NewGuid(),
                Email = email,
                InviteToken = token,
                ExpiresAt = DateTime.Now.AddDays(1),
                IsUsed = false
            };

            await _repo.AddAsync(invite);

            var link = $"https://localhost:7174/api/signup?token={token}";

            var subject = "You're invited to AMLRS";
            var body =
                $"""
                Hello,
                You have been invited to AMLRS.
                Click the link below to activate your account:
                {link}
                This link expires in 48 hours.
                If you did not expect this email, please ignore it.
                """;

            await _email.SendAsync(
                email,
                subject,
                body);
        }
    }

}
