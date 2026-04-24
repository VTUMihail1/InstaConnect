using InstaConnect.Common.Domain.Features.ValueObjects.Models;

namespace InstaConnect.Chats.Domain.Features.Chats.Models.Requests;

public record ChatsFilterQuery(
    UserId ParticipantOneId,
    Name ParticipantTwoName);
