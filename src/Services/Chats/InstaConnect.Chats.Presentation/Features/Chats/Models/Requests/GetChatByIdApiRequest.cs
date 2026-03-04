using System.Security.Claims;

using InstaConnect.Chats.Presentation.Features.Users.Abstractions;

namespace InstaConnect.Chats.Presentation.Features.Chats.Models.Requests;

public record GetChatByIdApiRequest(
    [FromClaim(ClaimTypes.NameIdentifier)] string ParticipantOneId,
    [FromRoute] string ParticipantTwoId,
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentUserId) : ICurrentUserableApiRequest;
