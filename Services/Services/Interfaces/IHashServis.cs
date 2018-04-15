using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services.Interfaces
{
    public interface IHashServis
    {
        string PasswordHash(string password, byte[] salt);
    }
}
