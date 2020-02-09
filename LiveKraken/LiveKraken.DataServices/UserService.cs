using LiveKraken.Services.Interfaces;
using LiveKraken.Data;
using LiveKraken.DataServices.Interfaces;
using LiveKraken.Models;
using LiveKraken.Models.DTO;
using System;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;

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
        public UserDto Authenticate(LoginDto loginData)
        {
            if (loginData == null)
                return null;

            var user = dbContext.Users
                .Where(x => x.Username == loginData.Username)
                .SingleOrDefault();
            user.Role = dbContext.Roles.FirstOrDefault(x => x.Id.Equals(user.RoleId));

            // check if email exists
            if (user == null)
                return null;

            // check if password is correct
            if (!this.authUtils.VerifyPasswordHash(loginData.Password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return new UserDto(user);
        }

        public UserDto Create(RegisterDto registerData)
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
            this.dbContext.SaveChanges();

            return new UserDto(user);
        }

        public UserDto GetUser(Guid userId)
        {
            var user = this.dbContext.Users.Find(userId);
            var userDto = new UserDto(user);
            return userDto;
        }

        public UserDto GetUser(string username)
        {
            var user = this.dbContext.Users.First(u => u.Username == username);
            var userDto = new UserDto(user);
            return userDto;
        }
    }
}
