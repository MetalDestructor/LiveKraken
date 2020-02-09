using LiveKraken.Services.Interfaces;
using LiveKraken.Data;
using LiveKraken.DataServices.Interfaces;
using LiveKraken.Models;
using LiveKraken.Models.DTO;
using System;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LiveKraken.DataServices
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IAuthUtils authUtils;

        public UserService(ApplicationDbContext dbContext, IAuthUtils authUtils)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException("dbContext");
            this.authUtils = authUtils ?? throw new ArgumentNullException("authUtils");
        }
        public async Task<UserDto> Authenticate(LoginDto loginData)
        {
            if (loginData == null)
                return null;

            var user = await dbContext.Users
                .Where(x => x.Username == loginData.Username)
                .SingleOrDefaultAsync();
            user.Role = await dbContext.Roles.SingleOrDefaultAsync(x => x.Id.Equals(user.RoleId));

            // check if email exists
            if (user == null)
                return null;

            // check if password is correct
            if (!this.authUtils.VerifyPasswordHash(loginData.Password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return new UserDto(user);
        }

        public async Task<UserDto> CreateAsync(RegisterDto registerData)
        {
            if (registerData == null)
                throw new ArgumentNullException("Password is required");

            if (this.dbContext.Users.Any(x => x.Email == registerData.Email))
                throw new ArgumentException("Email \"" + registerData.Email + "\" is already taken");

            if (this.dbContext.Users.Any(x => x.Username == registerData.Username))
                throw new ArgumentException("Username \"" + registerData.Username + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            this.authUtils.CreatePasswordHash(registerData.Password, out passwordHash, out passwordSalt);

            var stream = new Stream()
            {
                StreamId = Guid.NewGuid(),
                StreamKey = Guid.NewGuid()
            };

            var user = new User()
            {
                Id = Guid.NewGuid(),
                Email = registerData.Email,
                Username = registerData.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                StreamId = stream.StreamId,
                Stream = stream
            };

            this.dbContext.Streams.Add(stream);
            this.dbContext.Users.Add(user);
            await this.dbContext.SaveChangesAsync();

            return new UserDto(user);
        }

        public async Task<UserDto> GetUser(Guid userId)
        {
            var user = await this.dbContext.Users.FindAsync(userId);
            var userDto = new UserDto(user);
            return userDto;
        }

        public async Task<UserDto> GetUser(string username)
        {
            var user = await this.dbContext.Users.SingleOrDefaultAsync(u => u.Username == username);
            var userDto = new UserDto(user);
            return userDto;
        }
    }
}
