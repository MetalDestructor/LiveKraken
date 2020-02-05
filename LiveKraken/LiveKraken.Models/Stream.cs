using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LiveKraken.Models
{
    public class Stream
    {
        [Key]
        public Guid StreamId { get; set; }

        public string Title { get; set; }

        public string Image { get; set; }

        public bool IsOnline { get; set; }

        public Guid GameId { get; set; }
        public Game Game { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
