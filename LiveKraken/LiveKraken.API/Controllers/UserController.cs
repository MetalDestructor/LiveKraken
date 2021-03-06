﻿using LiveKraken.DataServices.Interfaces;
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
        public async Task<IActionResult> Login([FromBody] LoginDto user)
        {
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }

            var userDto = await this.userService.Authenticate(user);

            if (userDto == null)
            {
                return Unauthorized();
            }

            string token = this.jwtAuthService.GenerateToken(userDto);
            return Ok(new { Token = token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto user)
        {
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }
            try
            {
                var createdUser = await this.userService.CreateAsync(user);
                string token = this.jwtAuthService.GenerateToken(createdUser);
                return this.Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult("Server error !" +  ex.Message);
            }
        }

        [HttpGet("{userId:guid}")]
        public async Task<IActionResult> GetUser(Guid userId)
        {
            try
            {
                var userDto = await this.userService.GetUser(userId);
                return Ok(userDto);
            }
            catch (Exception)
            {
                return this.StatusCode(500, "Server error on getting user with id " + userId);
            }

        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetUser(string username)
        {
            try
            {
                var userDto = await this.userService.GetUser(username);
                return Ok(userDto);
            }
            catch (Exception)
            {
                return this.StatusCode(500, "Server error on getting user with username " + username);
            }

        }
    }
}
