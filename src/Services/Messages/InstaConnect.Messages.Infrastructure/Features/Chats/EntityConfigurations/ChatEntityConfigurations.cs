using InstaConnect.Chats.Common.Features.Chats.Utilities;
using InstaConnect.Chats.Domain.Features.Chats.Models.Entities;
using InstaConnect.Posts.Domain.Features.Users.Utilities;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.EntityConfigurations;

public class ChatEntityConfigurations : IEntityTypeConfiguration<Chat>
{
    public void Configure(EntityTypeBuilder<Chat> builder)
    {
        builder
            .Property(p => p.ParticipantOneId)
            .HasMaxLength(UserConfigurations.IdMaxLength)
            .IsRequired();

        builder
            .Property(p => p.ParticipantTwoId)
            .HasMaxLength(UserConfigurations.IdMaxLength)
            .IsRequired();

        builder
            .Property(t => t.CreatedAt)
            .IsRequired();

        builder
            .Property(t => t.UpdatedAt)
            .IsRequired();

        builder
            .HasOne(pl => pl.ParticipantOne)
            .WithMany(p => p.Chats)
            .HasForeignKey(pl => pl.ParticipantOneId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(pl => pl.ParticipantTwo)
            .WithMany(p => p.Chats)
            .HasForeignKey(pl => pl.ParticipantTwoId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(pl => pl.Messages)
            .WithOne()
            .HasForeignKey(pl => pl.MessageId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
