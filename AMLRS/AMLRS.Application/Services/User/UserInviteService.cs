using AMLRS.Application.DTOs;
using AMLRS.Application.Interfaces.Services.User;
using AMLRS.Core.Abstraction.Reposotory.User;
using AMLRS.Core.Domains.Users.Entities;
using AMLRS.Core.Domains.Users.Entities.Register;
using System.Xml.Linq;

namespace AMLRS.Application.Services.User
{
    public class UserInviteService : IUserInviteService
    {
        private readonly IUserInviteRepository _repo;
        private readonly IEmailSender _email;
        private readonly IOrganisationRepository _orgRepo;
        private readonly IUserRepository _userRepo;

        public UserInviteService(IUserInviteRepository repo, IEmailSender email, IOrganisationRepository orgRepo, IUserRepository userRepo)
        {
            _repo = repo;
            _email = email;
            _orgRepo = orgRepo;
            _userRepo = userRepo;
        }

        public async Task<InviteResponse> InviteUserAsync(InviteUserRequestDto userDto)
        {
            try
            {       
                var org = await _orgRepo.GetOrganisationByOrgNameAsync(userDto.OrgName);

                if (org == null)
                    throw new Exception($"{userDto.OrgName} does not exist.");

                var isInvited = _userRepo.GetByEmailAsync(userDto.EmailId);
               
                if (isInvited.Result != null)
                {
                    return new InviteResponse
                    {
                        Message = "This email address has already been invited or registered.",
                        IsAlreadyInvited = true,
                    };
                }

                var token = Guid.NewGuid().ToString();

                var invite = new UserInvite
                {
                    Email = userDto.EmailId,
                    InviteToken = token,
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    UserName = userDto.Name,
                    ExpiresAt = DateTime.UtcNow.AddDays(1),
                    Role = userDto.Role,
                    IsUsed = false,
                    OrgId = org.OrgId,
                };

                await _repo.AddAsync(invite);
                // https://localhost:5173/auth/signup/:
                var link = $"http://localhost:5173/auth/signup/{token}";

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
                    userDto.EmailId,
                    subject,
                    body);

                return new InviteResponse
                {
                    Message = "Invitation sent successfully",
                    IsAlreadyInvited = false,
                };
            }
            catch (Exception)
            {
                throw;
            }            
        }

        //public async Task<UsertblDto> AddUser(UsertblDto userDto)
        //{

        //    var org = await _orgRepo.GetOrganisationByOrgNameAsync(userDto.OrgName);

        //    var admin = new Usertbl
        //    {
        //        UserId = userDto.UserdtoId,
        //        Email = userDto.EmailId,
        //        PreferredName = userDto.Name,
        //        OrgId = org.OrgId,
        //        Role = userDto.Role,
        //    };

        //    await _userRepo.AddAsync(admin);

        //    return userDto;
        //}
    }

}
