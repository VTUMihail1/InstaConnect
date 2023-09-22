using InstaConnect.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InstaConnect.Data.EntityConfigurations
{
    public class TokenConfiguration : IEntityTypeConfiguration<Token>
    {
        public void Configure(EntityTypeBuilder<Token> builder)
        {
            builder.ToTable("token");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnName("id")
                .HasMaxLength(255)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(t => t.Type)
                .HasColumnName("type")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(t => t.Value)
                .HasColumnName("value")
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(t => t.ValidUntil)
                .HasColumnName("is_valid_until")
                .IsRequired();

            builder.Property(t => t.UserId)
                .HasColumnName("user_id")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(t => t.CreatedAt).HasColumnName("created_at");
            builder.Property(t => t.UpdatedAt).HasColumnName("updated_at");

            builder.HasOne(t => t.User)
                .WithMany(u => u.Tokens)
                .HasForeignKey(t => t.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
