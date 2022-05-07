using ITPack.Domain.Entities;
using ITPack.Domain.ValueObjects;
using ITPack.Infrastructure.EF.Config;
using Microsoft.EntityFrameworkCore;

namespace ITPack.Infrastructure.EF.Contexts
{
    internal class WriteDbContext : DbContext
    {
        public DbSet<PackingList> PackingLists { get; set; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("packing");

            var configuration = new WriteConfiguration();
            modelBuilder.ApplyConfiguration<PackingList>(configuration);
            modelBuilder.ApplyConfiguration<PackingItem>(configuration);
        }
    }
}
