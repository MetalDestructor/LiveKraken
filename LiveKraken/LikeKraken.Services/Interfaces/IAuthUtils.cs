using System;
using System.Collections.Generic;
using System.Text;

namespace LiveKraken.Services.Interfaces
{
    public interface IAuthUtils
    {
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);

        bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt);
    }
}
