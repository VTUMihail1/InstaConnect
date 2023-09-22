using InstaConnect.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InstaConnect.Data.EntityConfigurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("message");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .HasColumnName("id")
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(m => m.SenderId)
                .HasColumnName("sender_id")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(m => m.ReceiverId)
                .HasColumnName("receiver_id")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(m => m.Content)
                .HasColumnName("content")
                .HasMaxLength(2000)
                .IsRequired();

            builder.Property(m => m.CreatedAt).HasColumnName("created_at");
            builder.Property(m => m.UpdatedAt).HasColumnName("updated_at");

            builder.HasOne(m => m.Sender)
                .WithMany(u => u.Senders)
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(m => m.Receiver)
                .WithMany(u => u.Receivers)
                .HasForeignKey(m => m.ReceiverId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
