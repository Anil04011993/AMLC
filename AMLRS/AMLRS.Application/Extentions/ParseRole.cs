using AMLRS.Core.Domains.Users.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Application.Extentions
{
    public class ParseRole
    {
        public static RoleName TryParseRole(string role)
        {
            if (!Enum.TryParse<RoleName>(role, ignoreCase: true, out var parsedRole))
                throw new ArgumentException($"Invalid role: {role}");

            return parsedRole;
        }

    }
}
