using AMLRS.Application.DTOs;
using AMLRS.Application.Interfaces.Services.User;
using AMLRS.Core.Abstraction.Reposotory.User;
using AMLRS.Core.Domains.Users.Entities;
using AMLRS.Core.Domains.Users.Entities.Register;
using AMLRS.Core.Domains.Users.Enums;
using AMLRS.Core.QueryModels;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;

namespace AMLRS.Application.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IOtpRepository _otpRepo;
        private readonly IEmailSender _email;

        private readonly IOrganisationRepository _orgRepository;


        public UserService(IUserRepository userRepository, IOtpRepository otpRepo, IEmailSender email, IOrganisationRepository orgRepository)
        {
            _userRepository = userRepository;
            _otpRepo = otpRepo;
            _email = email;
            _orgRepository = orgRepository;
        }



        public async Task<LoggedInUserDto?> LoginAsync(UserLoginRequestDto login)
        {
            if (string.IsNullOrWhiteSpace(login.Email) || string.IsNullOrWhiteSpace(login.Password))
            {
                return null;
            }

            var user = await _userRepository.LoginAsync(login.Email, login.Password);
            if (user == null) return null;

            // Generate OTP
            var otp = RandomNumberGenerator.GetInt32(100000, 999999).ToString();

            var otpEntity = new EmailOtp
            {
                Email = login.Email,
                OtpHash = otp,
                //OtpHash = BCrypt.Net.BCrypt.HashPassword(otp),
                ExpiresAt = DateTime.UtcNow.AddMinutes(5),
                IsUsed = false,
                CreatedAt = DateTime.UtcNow
            };

            await _otpRepo.AddAsync(otpEntity);

            await _email.SendAsync(
                login.Email,
                "Login One Time Password",
                $"""
                Dear User,
                Your OTP is <b>{otp}
                This Otp expires in 5 mins.
                The Otp is confidential, DO NOT share the Otp with anyone.
                """);
            
            // No token generation — simple login returning user details
            return new LoggedInUserDto
            {
                UserId = user.UserId,
                Email = user.Email,
                UserName = user.UserName,
                Role = user.Role.ToString(),
            };
        }

        public async Task<bool> VerifyOtpAndLoginAsync(string email, string otp)
        {
            var otpEntity = await _otpRepo.GetActiveOtpAsync(email);

            //if (otpEntity == null ||
            //    otpEntity.ExpiresAt < DateTime.UtcNow ||
            //    !BCrypt.Net.BCrypt.Verify(otp, otpEntity.OtpHash))
            if (otpEntity == null || string.IsNullOrEmpty(otp))
                throw new Exception("Invalid or expired OTP");

            if (otpEntity.OtpHash != otp)
                throw new Exception("Invalid OTP");

            otpEntity.IsUsed = true;
            await _otpRepo.MarkUsedAsync(otpEntity);

            return true;
        }

        public async Task<InviteUserRequestDto?> GetUserByIdAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null) 
                return null;

            var org = await _orgRepository.GetByIdAsync(user.OrgId);
            if (org == null)
                throw new Exception($"organisation does not exist.");

            return new InviteUserRequestDto
            {
                OrgName = org.OrgLegalName,
                Name = user.UserName,
                EmailId = user.Email,
                Role = user.Role
            };
        }

        public async Task<InviteUserRequestDto?> UpdateUserAsync(int id, InviteUserRequestDto userDto)
        {
            var org = await _orgRepository.GetOrganisationByOrgNameAsync(userDto.OrgName);
            if (org == null)
                throw new Exception($"{userDto.OrgName} does not exist.");

            var userEntity = new Usertbl
            {
                UserId = id,
                UserName = userDto.Name,
                Email = userDto.EmailId,
                Role = userDto.Role,
                OrgId = org.OrgId
            };

            await _userRepository.UpdateAsync(userEntity);
            return userDto;
        }

        public async Task<bool> DeleteAdminAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
                throw new Exception($"User does not exist.");

            await _userRepository.DeleteAsync(user);
            return true;
        }
 public async Task<PagedResult<InviteUserRequestDto>> GetAllUsersAsync(CaseQueryParams queryParams)
        {
            var query = _userRepository.GetUsersWithOrgNameQueryable();

            if (!string.IsNullOrWhiteSpace(queryParams?.SearchText))
            {
                var search = queryParams.SearchText.Trim();

                query = query.Where(x =>
                    x.User.Email.Contains(search) ||
                    x.User.UserName.Contains(search) ||
                    x.OrgName.Contains(search)
                );
            }
            if (!string.IsNullOrWhiteSpace(queryParams?.Role))
            {
                var roles = queryParams.Role.Trim();
                query = query.Where(x =>
                    x.User.Role.ToString().Contains(roles)
                );
            }
            return await query
                    .Select(x => new InviteUserRequestDto
                    {
                        Name = x.User.UserName,
                        EmailId = x.User.Email,
                        Role = x.User.Role,
                        OrgName = x.OrgName
                    })
                    .ToPagedResultAsync(
                        queryParams?.PageNumber ?? 1,
                        queryParams?.PageSize ?? 20
                    );
        }
    }
}
