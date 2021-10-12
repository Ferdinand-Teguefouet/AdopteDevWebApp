using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdopteDevWebApp.Interface
{
    public interface IHashPw
    {
        string HashPassword(string _passwordToHash);
    }
}
