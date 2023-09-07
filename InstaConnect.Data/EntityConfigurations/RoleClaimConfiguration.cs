using InstaConnect.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InstaConnect.Data.EntityConfigurations
{
    public class RoleClaimConfiguration : IEntityTypeConfiguration<RoleClaim>
    {
        public void Configure(EntityTypeBuilder<RoleClaim> builder)
        {
            builder.ToTable("role_claim");

            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.RoleId).HasColumnName("role_id");
            builder.Property(p => p.ClaimType).HasColumnName("claim_type");
            builder.Property(p => p.ClaimValue).HasColumnName("claim_value");
            builder.Property(p => p.CreatedAt).HasColumnName("created_at");
            builder.Property(p => p.UpdatedAt).HasColumnName("updated_at");
        }
    }
}
