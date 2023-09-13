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

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType("varchar")
                .HasMaxLength(255)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(p => p.Type)
                .HasColumnName("type")
                .HasColumnType("varchar")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(p => p.Value)
                .HasColumnName("value")
                .HasColumnType("varchar")
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(p => p.ValidUntil)
                .HasColumnName("is_valid_until")
                .IsRequired();

            builder.Property(p => p.CreatedAt).HasColumnName("created_at");
            builder.Property(p => p.UpdatedAt).HasColumnName("updated_at");
        }
    }
}
