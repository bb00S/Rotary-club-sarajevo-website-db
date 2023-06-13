using Microsoft.EntityFrameworkCore;
using RotaryClub.Models;

namespace RotaryClub.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Member> Members => Set<Member>();
    }
}
