using InstaConnect.Common.Domain.Features.Entities.Abstractions;

namespace InstaConnect.Chats.Domain.Features.Chats.Models.ValueObjects;

public record ChatId(UserId ParticipantOneId, UserId ParticipantTwoId) : IEntityId;
