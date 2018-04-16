using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services.Interfaces
{
    public interface IHashService
    {
        string HashPassword(string password, byte[] salt);

        byte[] CreatedSalt();
    }
}
