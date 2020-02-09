using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LiveKraken.Models
{
    public class Stream
    {
        [Key]
        public Guid StreamId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public bool IsOnline { get; set; }

        [Required]
        public Guid StreamKey { get; set; }

        public Guid GameId { get; set; }
        public Game Game { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
