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

            builder.Property(rc => rc.Id).HasColumnName("id");
            builder.Property(rc => rc.RoleId).HasColumnName("role_id");
            builder.Property(rc => rc.ClaimType).HasColumnName("claim_type");
            builder.Property(rc => rc.ClaimValue).HasColumnName("claim_value");
            builder.Property(rc => rc.CreatedAt).HasColumnName("created_at");
            builder.Property(rc => rc.UpdatedAt).HasColumnName("updated_at");
        }
    }
}
