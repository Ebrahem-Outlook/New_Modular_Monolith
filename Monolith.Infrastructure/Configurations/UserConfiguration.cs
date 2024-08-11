using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monolith.Domain.Users;

namespace Monolith.Infrastructure.Configurations
{
    /// <summary>
    /// Configuration class for the <see cref="User"/> entity.
    /// </summary>
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        /// <summary>
        /// Configures the <see cref="User"/> entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the <see cref="User"/> entity.</param>
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Configure the table name and schema
            builder.ToTable("Users", "Users_Schema_1");

            // Configure the primary key
            builder.HasKey(user => user.Id);

            // Configure the Name property
            builder.Property(user => user.Name)
                   .HasColumnName(nameof(User.Name))
                   .HasMaxLength(50)
                   .IsRequired();

            // Configure the Bio property
            builder.Property(user => user.Bio)
                   .HasColumnName(nameof(User.Bio))
                   .HasMaxLength(150)
                   .IsRequired(false);

            // Configure the UserName property with a unique index
            builder.Property(user => user.UserName)
                   .HasColumnName(nameof(User.UserName))
                   .HasMaxLength(30)
                   .IsRequired();

            builder.HasIndex(user => user.UserName)
                   .IsUnique();

            // Configure the Email property with a unique index
            builder.Property(user => user.Email)
                   .HasColumnName(nameof(User.Email))
                   .HasMaxLength(50)
                   .IsRequired();

            builder.HasIndex(user => user.Email)
                   .IsUnique();

            // Configure the PasswordHash property
            builder.Property(user => user.PasswordHash)
                   .HasColumnName(nameof(User.PasswordHash))
                   .HasMaxLength(255)
                   .IsRequired();
        }
    }
}