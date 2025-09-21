using InstaConnect.Chats.Domain.Features.Chats.Models.Entities;
using InstaConnect.Chats.Infrastructure.Features.Chats.Models;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

using Mapster;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Mappings;

internal class ChatInfrastructureMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ChatQueryEntity, Chat>()
              .ConstructUsing(pl => new(
                            new User(
                                pl.ParticipantOneId,
                                pl.ParticipantOneFirstName,
                                pl.ParticipantOneLastName,
                                pl.ParticipantOneEmail,
                                pl.ParticipantOneName,
                                pl.ParticipantOneProfileImage,
                                pl.ParticipantOneCreatedAt,
                                pl.ParticipantOneUpdatedAt),
                            new User(
                                pl.ParticipantTwoId,
                                pl.ParticipantTwoFirstName,
                                pl.ParticipantTwoLastName,
                                pl.ParticipantTwoEmail,
                                pl.ParticipantTwoName,
                                pl.ParticipantTwoProfileImage,
                                pl.ParticipantTwoCreatedAt,
                                pl.ParticipantTwoUpdatedAt),
                            pl.CreatedAt,
                            pl.UpdatedAt));
    }
}
