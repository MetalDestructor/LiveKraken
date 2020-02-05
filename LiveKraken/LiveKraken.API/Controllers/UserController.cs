using LiveKraken.DataServices.Interfaces;
using LiveKraken.Models.DTO;
using LiveKraken.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveKraken.API.Controllers
{
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IAuthService jwtAuthService;

        public UserController(IUserService userService, IAuthService jwtAuthService)
        {
            this.userService = userService ?? throw new ArgumentNullException("userService");
            this.jwtAuthService = jwtAuthService ?? throw new ArgumentNullException("jwtAuthService");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto user)
        {
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }

            var userDto = this.userService.Authenticate(user);

            if (userDto == null)
            {
                return Unauthorized();
            }

            string token = this.jwtAuthService.GenerateToken(userDto);
            return Ok(new { Token = token });
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDto user)
        {
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }
            try
            {
                var createdUser = this.userService.Create(user);
                string token = this.jwtAuthService.GenerateToken(createdUser);
                return this.Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult("Server error !" +  ex.Message);
            }
        }

        [HttpGet("{userId:guid}")]
        public IActionResult GetUser(Guid userId)
        {
            try
            {
                var userDto = this.userService.GetUser(userId);
                return Ok(userDto);
            }
            catch (Exception)
            {
                return this.StatusCode(500, "Server error on getting user with id " + userId);
            }

        }

        [HttpGet("{username}")]
        public IActionResult GetUser(string username)
        {
            try
            {
                var userDto = this.userService.GetUser(username);
                return Ok(userDto);
            }
            catch (Exception)
            {
                return this.StatusCode(500, "Server error on getting user with username " + username);
            }

        }
    }
}
