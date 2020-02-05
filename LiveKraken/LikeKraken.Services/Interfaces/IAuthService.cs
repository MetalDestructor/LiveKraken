using LiveKraken.Models.DTO;

namespace LiveKraken.Services.Interfaces
{
    public interface IAuthService
    {
        string GenerateToken(UserDto user);
    }
}
