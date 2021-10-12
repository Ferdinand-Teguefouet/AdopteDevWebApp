using AdopteDevWebApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdopteDevWebApp.Services
{
    public class HashPwService : IHashPw
    {
        public string HashPassword(string _passwordToHash)
        {
            SHA512CryptoServiceProvider shasp = new();
            byte[] bytes = Encoding.UTF8.GetBytes(_passwordToHash);
            byte[] encoded = shasp.ComputeHash(bytes);
            return Encoding.UTF8.GetString(encoded);
        }
    }
}
