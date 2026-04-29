using InstaConnect.Chats.Presentation.Features.Users.Abstractions;

namespace InstaConnect.Chats.Presentation.Features.Chats.Models.Requests;

public record GetChatByIdApiRequest(
	[FromRoute] string ParticipantTwoId,
	[UserIdFromClaim] string CurrentUserId) : ICurrentUserableApiRequest;
