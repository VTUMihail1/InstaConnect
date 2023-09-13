using InstaConnect.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InstaConnect.Data.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");

            builder.Property(p => p.FirstName)
                .HasColumnName("first_name")
                .HasColumnType("varchar")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(p => p.LastName)
                .HasColumnName("last_name")
                .HasColumnType("varchar")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.AccessFailedCount).HasColumnName("access_failed_count");
            builder.Property(p => p.ConcurrencyStamp).HasColumnName("concurrency_stamp");
            builder.Property(p => p.Email).HasColumnName("email");
            builder.Property(p => p.EmailConfirmed).HasColumnName("email_is_confirmed");
            builder.Property(p => p.LockoutEnd).HasColumnName("lockout_end");
            builder.Property(p => p.LockoutEnabled).HasColumnName("lockout_is_enabled");
            builder.Property(p => p.NormalizedEmail).HasColumnName("normalized_email");
            builder.Property(p => p.NormalizedUserName).HasColumnName("normalized_username");
            builder.Property(p => p.PasswordHash).HasColumnName("password_hash");
            builder.Property(p => p.PhoneNumber).HasColumnName("phone_number");
            builder.Property(p => p.PhoneNumberConfirmed).HasColumnName("phone_number_is_confirmed");
            builder.Property(p => p.SecurityStamp).HasColumnName("security_stamp");
            builder.Property(p => p.TwoFactorEnabled).HasColumnName("two_factor_is_enabled");
            builder.Property(p => p.UserName).HasColumnName("username");
            builder.Property(p => p.CreatedAt).HasColumnName("created_at");
            builder.Property(p => p.UpdatedAt).HasColumnName("updated_at");
        }
    }
}
