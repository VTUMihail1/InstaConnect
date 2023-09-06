using DocConnect.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocConnect.Data.EntityConfigurations
{
    public class UserClaimConfiguration : IEntityTypeConfiguration<UserClaim>
    {
        public void Configure(EntityTypeBuilder<UserClaim> builder)
        {
            builder.ToTable("user_claim");

            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.UserId).HasColumnName("role_id");
            builder.Property(p => p.ClaimType).HasColumnName("claim_type");
            builder.Property(p => p.ClaimValue).HasColumnName("claim_value");
            builder.Property(p => p.CreatedAt).HasColumnName("created_at");
            builder.Property(p => p.UpdatedAt).HasColumnName("updated_at");
        }
    }
}
