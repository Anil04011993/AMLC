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

            await _email.SendAsync(
                email,
                "You're Invited",
                $"Click <a href='{link}'>here</a> to register.");
        }
    }

}
