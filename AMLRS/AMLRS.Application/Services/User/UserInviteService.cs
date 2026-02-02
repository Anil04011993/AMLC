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
            try
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

                var body = $@"
                <!DOCTYPE html>
                <html>
                <head>
                    <meta charset='UTF-8'>
                </head>
                <body style='font-family: Arial, sans-serif; line-height: 1.6;'>
                    <p>Hello,</p>

                    <p>You have been invited to <strong>AMLRS</strong>.</p>

                    <p>
                        Click the link below to activate your account:
                    </p>

                    <p>
                        <a href='{link}' target='_blank'
                           style='display:inline-block;
                                  padding:10px 16px;
                                  background-color:#2563eb;
                                  color:#ffffff;
                                  text-decoration:none;
                                  border-radius:4px;'>
                            Activate Account
                        </a>
                    </p>
                    <p>This link expires in <strong>24 hours</strong>.</p>
                </body>
                </html>";


                await _email.SendAsync(
                    email,
                    subject,
                    body);
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }

}
