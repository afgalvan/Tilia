using Microsoft.EntityFrameworkCore;
using Shared.Infrastructure.Persistence;

namespace Tilia.Integration.Test.Mocks
{
    public class TestDbContext : TiliaDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=test.db");
        }
    }
}
