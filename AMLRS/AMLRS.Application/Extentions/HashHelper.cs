using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace AMLRS.Application.Extentions
{
    public static class HashHelper
    {
        public static string ComputeSha256(Stream stream)
        {
            using var sha = SHA256.Create();
            var hash = sha.ComputeHash(stream);
            return Convert.ToHexString(hash);
        }
    }

}
