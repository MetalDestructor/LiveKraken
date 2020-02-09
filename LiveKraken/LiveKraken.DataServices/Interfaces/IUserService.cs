using LiveKraken.Models.DTO;
using System;
using System.Threading.Tasks;

namespace LiveKraken.DataServices.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> Authenticate(LoginDto loginData);
        Task<UserDto> CreateAsync(RegisterDto registerData);
        Task<UserDto> GetUser(Guid userId);
        Task<UserDto> GetUser(string username);
    }
}
