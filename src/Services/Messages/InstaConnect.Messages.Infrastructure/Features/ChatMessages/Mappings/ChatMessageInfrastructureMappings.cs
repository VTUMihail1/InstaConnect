using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Entities;
using InstaConnect.ChatMessages.Infrastructure.Features.ChatMessages.Models;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

using Mapster;

namespace InstaConnect.ChatMessages.Infrastructure.Features.ChatMessages.Mappings;

internal class ChatMessageInfrastructureMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ChatMessageQueryEntity, ChatMessage>()
              .ConstructUsing(pl => new(
                            pl.ParticipantOneId,
                            pl.ParticipantTwoId,
                            pl.MessageId,
                            new User(
                                pl.SenderId,
                                pl.SenderFirstName,
                                pl.SenderLastName,
                                pl.SenderEmail,
                                pl.SenderName,
                                pl.SenderProfileImage,
                                pl.SenderCreatedAt,
                                pl.SenderUpdatedAt),
                            pl.Content,
                            pl.CreatedAt,
                            pl.UpdatedAt));
    }
}
