using InstaConnect.Chats.Presentation.Features.Users.Abstractions;

namespace InstaConnect.Chats.Presentation.Features.ChatMessages.Models.Requests;

public record GetChatMessageByIdApiRequest(
    [FromRoute] string ParticipantTwoId,
    [FromRoute] string MessageId,
    [UserIdFromClaim] string CurrentUserId
) : ICurrentUserableApiRequest;
