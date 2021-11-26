using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SharedLib.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(user => user.Name).IsUnique();
            builder.HasIndex(user => user.Email).IsUnique();
            builder.Property(user => user.Name).HasMaxLength(255);
            builder.Property(user => user.Email).HasMaxLength(255);
            builder.Property(user => user.Password).HasMaxLength(255);
        }
    }
}
