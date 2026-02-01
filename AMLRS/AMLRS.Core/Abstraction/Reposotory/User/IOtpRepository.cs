using AMLRS.Core.Domains.Users.Entities.Register;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Core.Abstraction.Reposotory.User
{
    public interface IOtpRepository
    {
        Task AddAsync(EmailOtp otp);
        Task<EmailOtp?> GetActiveOtpAsync(string email);
        Task MarkUsedAsync(EmailOtp otp);
    }

}
