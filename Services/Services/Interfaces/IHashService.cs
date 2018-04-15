using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services.Interfaces
{
    public interface IHashService
    {
        string PasswordHash(string password, byte[] salt);

        byte[] SaltCreated();
    }
}
