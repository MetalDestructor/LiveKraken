using LiveKraken.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiveKraken.Data
{
    public static class ModelBuilderExtensions
    {
        public static void SeedRoles(this ModelBuilder modelBuilder)
        {
            var roles = new Role[]
            {
                new Role
                {
                    Id = new Guid("d5fe4106-e7c1-493c-8118-02298e96e2a8"),
                    RoleName = "user"
                }
            };

            modelBuilder.Entity<Role>()
                .HasData(roles);
        }

        public static void SeedGames(this ModelBuilder modelBuilder)
        {
            var games = new Game[]
            {
                new Game
                {
                    Id = new Guid("8e99bcbb-84e1-4957-98cf-eb5c3a186296"),
                    Image = "https://pbs.twimg.com/profile_images/1049746840/blank_400x400.jpg",
                    Description = "",
                    Title = ""
                }
            };

            modelBuilder.Entity<Game>().HasData(games);
        }
    }
}
