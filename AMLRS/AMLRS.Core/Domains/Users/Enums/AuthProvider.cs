using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Core.Domains.Users.Enums
{
    public enum AuthProvider
    {
        Internal,
        LDAP,
        SAML,
        OAuth,
        OIDC
    }
}
