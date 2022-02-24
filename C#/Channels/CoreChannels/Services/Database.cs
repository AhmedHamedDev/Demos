using Microsoft.EntityFrameworkCore;

namespace CoreChannels.Services
{
    public class Database : DbContext
    {
        public Database(DbContextOptions<Database> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
