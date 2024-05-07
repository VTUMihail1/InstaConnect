using InstaConnect.Users.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InstaConnect.Users.Data.EntityConfigurations;

public class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
{
    public void Configure(EntityTypeBuilder<UserLogin> builder)
    {
        builder.ToTable("user_login");

        builder.Property(ul => ul.Id).HasColumnName("id");
        builder.Property(ul => ul.UserId).HasColumnName("user_id");
        builder.Property(ul => ul.ProviderKey).HasColumnName("provider_key");
        builder.Property(ul => ul.ProviderDisplayName).HasColumnName("provider_display_name");
        builder.Property(ul => ul.LoginProvider).HasColumnName("login_provider");
        builder.Property(ul => ul.CreatedAt).HasColumnName("created_at");
        builder.Property(ul => ul.UpdatedAt).HasColumnName("updated_at");
    }
}
