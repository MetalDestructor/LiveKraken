using LiveKraken.Models.DTO;
using System;

namespace LiveKraken.DataServices.Interfaces
{
    public interface IUserService
    {
        UserDto Authenticate(LoginDto loginData);
        UserDto Create(RegisterDto registerData);
        UserDto GetUser(Guid userId);
        UserDto GetUser(string username);
    }
}
