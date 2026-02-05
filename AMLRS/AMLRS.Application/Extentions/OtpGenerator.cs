using AMLRS.Core.Domains.Users.Entities.Register;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace AMLRS.Application.Extentions
{
    public class OtpGenerator
    {
        public static void GenerateOtp(string email, out string otp, out EmailOtp otpEntity)
        {
            otp = RandomNumberGenerator.GetInt32(100000, 999999).ToString();
            otpEntity = new EmailOtp
            {
                Email = email,
                OtpHash = otp,
                //OtpHash = BCrypt.Net.BCrypt.HashPassword(otp),
                ExpiresAt = DateTime.UtcNow.AddMinutes(2),
                IsUsed = false,
                CreatedAt = DateTime.UtcNow
            };
        }
    }
}
