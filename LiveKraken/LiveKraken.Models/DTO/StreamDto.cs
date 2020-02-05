using System;
using System.Collections.Generic;
using System.Text;

namespace LiveKraken.Models.DTO
{
    public class StreamDto
    {
        public StreamDto(Stream s)
        {
            Id = s.StreamId;
            Username = s.User.Username;
            Title = s.Title;
            Game = s.Game.Title;
            Image = s.Image;
        }
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Title { get; set; }
        public string Game { get; set; }
        public string Image { get; set; }
    }
}
