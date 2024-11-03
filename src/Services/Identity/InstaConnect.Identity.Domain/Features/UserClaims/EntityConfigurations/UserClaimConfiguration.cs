using InstaConnect.Identity.Data.Features.UserClaims.Models.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InstaConnect.Identity.Data.Features.UserClaims.EntityConfigurations;

public class UserClaimConfiguration : IEntityTypeConfiguration<UserClaim>
{
    public void Configure(EntityTypeBuilder<UserClaim> builder)
    {
        builder
            .ToTable("user_claim");

        builder
            .Property(uc => uc.Id)
            .HasColumnName("id");

        builder
            .Property(uc => uc.UserId)
            .HasColumnName("user_id");

        builder
            .Property(uc => uc.Claim)
            .HasColumnName("claim");

        builder
            .Property(uc => uc.Value)
            .HasColumnName("value");

        builder
            .Property(t => t.CreatedAt)
            .HasColumnName("created_at");

        builder
            .Property(t => t.UpdatedAt)
            .HasColumnName("updated_at");

        builder
            .HasOne(t => t.User)
            .WithMany(u => u.UserClaims)
            .HasForeignKey(t => t.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
