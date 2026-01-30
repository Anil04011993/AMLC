using AMLRS.Core.Domains.Users.Entities.Register;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Core.Abstraction.Reposotory
{
    public interface IOtpRepository
    {
        Task AddAsync(EmailOtp otp);
        Task<EmailOtp?> GetValidOtpAsync(int userId);
        Task MarkUsedAsync(EmailOtp otp);
    }

}
