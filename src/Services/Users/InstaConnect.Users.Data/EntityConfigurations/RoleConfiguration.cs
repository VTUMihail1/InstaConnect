using InstaConnect.Users.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InstaConnect.Users.Data.EntityConfigurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder
            .ToTable("role");

        builder
            .Property(r => r.Id)
            .HasColumnName("id");

        builder
            .Property(r => r.Name)
            .HasColumnName("name");

        builder
            .Property(r => r.NormalizedName)
            .HasColumnName("normalized_name");

        builder
            .Property(r => r.ConcurrencyStamp)
            .HasColumnName("concurrency_stamp");

        builder
            .Property(t => t.CreatedAt)
            .HasColumnType("timestamp(6)")
            .HasColumnName("created_at");

        builder
            .Property(t => t.UpdatedAt)
            .HasColumnType("timestamp(6)")
            .HasColumnName("updated_at");
    }
}
