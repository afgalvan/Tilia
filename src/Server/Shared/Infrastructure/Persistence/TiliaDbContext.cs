using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Shared.Infrastructure.Persistence
{
    public class TiliaDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public TiliaDbContext(DbContextOptions options) : base(options)
        {
        }

        public TiliaDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TiliaDbContext).Assembly);
        }
    }
}
