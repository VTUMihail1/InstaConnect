using InstaConnect.Messages.Read.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InstaConnect.Messages.Read.Data.EntityConfigurations;

public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder
            .ToTable("message");

        builder
            .HasKey(m => m.Id);

        builder
            .Property(m => m.Id)
            .HasColumnName("id")
            .ValueGeneratedNever()
            .IsRequired();

        builder
            .Property(m => m.SenderId)
            .HasColumnName("sender_id")
            .IsRequired();

        builder
            .Property(m => m.ReceiverId)
            .HasColumnName("receiver_id")
            .IsRequired();

        builder
            .Property(m => m.Content)
            .HasColumnName("content")
            .HasMaxLength(2000)
            .IsRequired();

        builder
            .Property(t => t.CreatedAt)
            .HasColumnName("created_at");

        builder
            .Property(t => t.UpdatedAt)
            .HasColumnName("updated_at");

        builder.HasOne(u => u.Sender)
                    .WithMany(f => f.SenderMessages)
                    .HasForeignKey(f => f.SenderId)
                    .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(f => f.Receiver)
                    .WithMany(u => u.ReceiverMessages)
                    .HasForeignKey(f => f.ReceiverId)
                    .OnDelete(DeleteBehavior.Restrict);
    }
}
