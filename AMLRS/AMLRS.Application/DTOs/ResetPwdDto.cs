using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Application.DTOs
{
    public class ResetPwdDto
    {
        public bool IsResetSuccess { get; set; }
        public bool IsNewPwdSameAsOld{ get; set; }
    }
}
