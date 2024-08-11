using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monolith.Domain.Users;

namespace Monolith.Infrastructure.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users","Users_Schema_1");

        builder.HasKey(user => user.Id);

        builder.Property(user => user.Name)
            .HasColumnName(nameof(User.Name))
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(user => user.Bio)
            .HasColumnName(nameof(User.Bio))
            .HasMaxLength(150)
            .IsRequired(false);

        builder.Property(user => user.UserName)
            .HasColumnName(nameof(User.UserName))
            .HasMaxLength(30)
            .IsRequired();

        builder.HasIndex(user => user.UserName)
            .IsUnique();

        builder.Property(user => user.Email)
            .HasColumnName(nameof(User.Email))
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(user => user.Email)
            .IsUnique();

        builder.Property(user => user.PasswordHash)
            .HasColumnName(nameof(User.PasswordHash))
            .HasMaxLength(255)
            .IsRequired();
    }
}
