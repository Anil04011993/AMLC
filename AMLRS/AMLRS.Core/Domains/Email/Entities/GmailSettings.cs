using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Core.Domains.Email.Entities
{
    namespace AMLRS.Application.Settings
    {
        public class GmailSettings
        {
            public string FromEmail { get; set; } = default!;
            public string Username { get; set; } = default!;
            public string AppPassword { get; set; } = default!;
            public string Host { get; set; } = default!;
            public int Port { get; set; }
        }
    }
}
