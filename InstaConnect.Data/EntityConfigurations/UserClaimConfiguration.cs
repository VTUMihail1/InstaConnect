using InstaConnect.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InstaConnect.Data.EntityConfigurations
{
    public class UserClaimConfiguration : IEntityTypeConfiguration<UserClaim>
    {
        public void Configure(EntityTypeBuilder<UserClaim> builder)
        {
            builder.ToTable("user_claim");

            builder.Property(uc => uc.Id).HasColumnName("id");
            builder.Property(uc => uc.UserId).HasColumnName("role_id");
            builder.Property(uc => uc.ClaimType).HasColumnName("claim_type");
            builder.Property(uc => uc.ClaimValue).HasColumnName("claim_value");
            builder.Property(uc => uc.CreatedAt).HasColumnName("created_at");
            builder.Property(uc => uc.UpdatedAt).HasColumnName("updated_at");
        }
    }
}
