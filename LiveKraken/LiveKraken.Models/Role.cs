using System;
using System.ComponentModel.DataAnnotations;

namespace LiveKraken.Models
{
    public class Role
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string RoleName { get; set; }
    }
}
