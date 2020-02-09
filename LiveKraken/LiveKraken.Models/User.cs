using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LiveKraken.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Username { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }

        [Required]
        public byte[] PasswordSalt { get; set; }

        public ICollection<UserToUser> Followers { get; set; } = new List<UserToUser>();

        public ICollection<UserToUser> Following { get; set; } = new List<UserToUser>();
        public string Avatar { get; set; }

        public Guid RoleId { get; set; }
        public Role Role { get; set; }

        public Guid StreamId { get; set; }
        public Stream Stream { get; set; }

    }
}
