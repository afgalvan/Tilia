using Domain.Employees;
using Domain.People;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace SharedLib.Infrastructure.Persistence
{
    public class TiliaDbContext : DbContext
    {
        public DbSet<User>             Users             { get; set; }
        public DbSet<AccessRole>       AccessRoles       { get; set; }
        public DbSet<Privilege>        Privileges        { get; set; }
        public DbSet<Person>           People            { get; set; }
        public DbSet<Employee>         Employees         { get; set; }
        public DbSet<SanitaryEmployee> SanitaryEmployees { get; set; }
        public DbSet<SanitaryRole>     SanitaryRoles     { get; set; }

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
