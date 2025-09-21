using InstaConnect.ChatMessages.Common.Features.ChatMessages.Utilities;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Entities;
using InstaConnect.Posts.Domain.Features.Users.Utilities;

namespace InstaConnect.ChatMessages.Infrastructure.Features.ChatMessages.EntityConfigurations;

public class ChatMessageEntityConfigurations : IEntityTypeConfiguration<ChatMessage>
{
    public void Configure(EntityTypeBuilder<ChatMessage> builder)
    {
        builder.HasKey(t => t.MessageId);

        builder
            .Property(p => p.ParticipantOneId)
            .HasMaxLength(UserConfigurations.IdMaxLength)
            .IsRequired();

        builder
            .Property(p => p.ParticipantTwoId)
            .HasMaxLength(UserConfigurations.IdMaxLength)
            .IsRequired();

        builder
            .Property(p => p.MessageId)
            .HasMaxLength(ChatMessageConfigurations.IdMaxLength)
            .IsRequired();

        builder
            .Property(p => p.Content)
            .HasMaxLength(ChatMessageConfigurations.ContentMaxLength)
            .IsRequired();

        builder
            .Property(t => t.CreatedAt)
            .IsRequired();

        builder
            .Property(t => t.UpdatedAt)
            .IsRequired();

        builder
            .HasOne(pl => pl.Sender)
            .WithMany(p => p.ChatMessages)
            .HasForeignKey(pl => pl.SenderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
