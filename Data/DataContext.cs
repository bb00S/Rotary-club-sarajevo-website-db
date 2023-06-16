using Microsoft.EntityFrameworkCore;
using RotaryClub.Helpers;
using RotaryClub.Models;
using System.Reflection.Metadata;
using System.Security.Cryptography;

namespace RotaryClub.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Member> Members => Set<Member>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            HashFunctions.CreatePasswordHash("admin", out byte[] passwordHash, out byte[] passwordSalt);
            modelBuilder.Entity<User>()
                .HasData(new User()
                {
                    Id= 1,
                    Email = "admin@admin.ba",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    VerificationToken = HashFunctions.CreateRandomToken(),
                    VerifiedAt = DateTime.Now,
                });
        }
    }
}
