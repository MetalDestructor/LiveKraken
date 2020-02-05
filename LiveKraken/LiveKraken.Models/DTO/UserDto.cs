﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LiveKraken.Models.DTO
{
    public class UserDto
    {
        public UserDto(User u)
        {
            this.Id = u.Id;
            this.Username = u.Username;
            this.Email = u.Email;

            this.Followers = u.Followers;
            this.Following = u.Following;
            this.Avatar = u.Avatar;
            this.Role = u.Role?.RoleName;
        }
        public Guid Id { get; set; }

        [Required]
        public string Username { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        public IEnumerable<string> Followers { get; set; }

        public IEnumerable<string> Following { get; set; }

        public string Role { get; set; }

        public string Avatar { get; set; }
    }
}
