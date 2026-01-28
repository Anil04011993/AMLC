using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Core.Domains.Users.Enums
{
    public enum MfaMethod
    {
        Authenticator_App,
        SMS,
        Email,
        Hardware_Key
    }
}
