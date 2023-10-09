using api.Entities.Base;
using api.Entities.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.Configurations;

public sealed class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).ValueGeneratedNever();
        builder.Property(u => u.Email)
            .HasConversion(
                mail => mail.Value,
                value => Email.Create(value)!
            );

        builder.HasIndex(u => u.Email);
        builder.HasIndex(u => u.PersonalId);

        builder.Property(u => u.Password)
            .HasConversion(
                pwd => pwd.Value,
                value => Password.CreateFromHash(value)
            );

        builder
            .HasMany(u => u.Roles)
            .WithMany(r => r.Users);
    }
}
