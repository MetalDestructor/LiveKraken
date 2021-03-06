﻿using LiveKraken.Models;
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

        public static void SeedUsers(this ModelBuilder modelBuilder)
        {
            byte[] userPasswordHash;
            byte[] userPasswordSalt;
            HashPassword("asd123", out userPasswordHash, out userPasswordSalt);

            var streams = new Stream[]
            {
                new Stream
                {
                    StreamId = new Guid("4e50232e-357e-4c80-a529-ad3045b79606"),
                    StreamKey = new Guid("0949d6e4-3f4d-436a-9a2f-becba24d83a5"),
                    UserId = new Guid("b2a03e9c-73df-433c-b843-84184767894a")
                }
            };

            modelBuilder.Entity<Stream>().HasData(streams);
            var users = new User[]
            {
                new User
                {
                    Id = new Guid("b2a03e9c-73df-433c-b843-84184767894a"),
                    Email = "asd@asd.bg",
                    Username = "asd",
                    PasswordHash = userPasswordHash,
                    PasswordSalt = userPasswordSalt,
                    StreamId = new Guid("4e50232e-357e-4c80-a529-ad3045b79606")
                }
            };

            modelBuilder.Entity<User>().HasData(users);
        }

        private static void HashPassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(Encoding.UTF8.GetBytes("GPSQZRH9ET0HSZOEJ27UVGUEA0GSZUL82NDN5URYRXP1WY004EPTA3K8DJZFV2EFV3A8VDAF8XXALUEVY1A2GI520A7OKISSO7PBAHOS9BE3JZ4PQPF79TRZ1WFVVV5L")))
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
