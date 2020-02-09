using System;
using System.Collections.Generic;
using System.Text;

namespace LiveKraken.Models
{
    public class UserToUser
    {
        public User User { get; set; }
        public Guid UserId { get; set; }
        public User Follower { get; set; }
        public Guid FollowerId { get; set; }
    }
}
