using Microsoft.EntityFrameworkCore;
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

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private string CreateRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Member> Members => Set<Member>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CreatePasswordHash("admin", out byte[] passwordHash, out byte[] passwordSalt);
            modelBuilder.Entity<User>()
                .HasData(new User()
                {
                    Email = "admin@admin.ba",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    VerificationToken = CreateRandomToken(),
                    VerifiedAt = DateTime.Now,
                });
        }
    }
}
