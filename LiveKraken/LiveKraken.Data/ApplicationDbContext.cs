using LiveKraken.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LiveKraken.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Stream> Streams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(u => u.RoleId).HasDefaultValue(new Guid("d5fe4106-e7c1-493c-8118-02298e96e2a8"));
            modelBuilder.Entity<User>().Property(p => p.Followers)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<List<string>>(v));
            modelBuilder.Entity<User>().Property(p => p.Following)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<List<string>>(v));
            modelBuilder.Entity<User>().HasOne(u => u.Stream).WithOne(s => s.User).HasForeignKey<Stream>(s => s.UserId);
            modelBuilder.Entity<Stream>().Property(s => s.Title).HasDefaultValue(string.Empty);
            modelBuilder.Entity<Stream>().Property(s => s.Image).HasDefaultValue("https://www.tourniagara.com/wp-content/uploads/2014/10/default-img.gif");
            modelBuilder.Entity<Stream>().Property(s => s.IsOnline).HasDefaultValue(false);
            modelBuilder.Entity<Stream>().Property(s => s.GameId).HasDefaultValue(new Guid("8e99bcbb-84e1-4957-98cf-eb5c3a186296"));
            modelBuilder.Entity<Stream>().Property(s => s.StreamKey).HasDefaultValue(Guid.NewGuid());

            modelBuilder.SeedRoles();
            modelBuilder.SeedGames();
        }
    }
}
