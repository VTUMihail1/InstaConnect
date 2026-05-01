using InstaConnect.Chats.Presentation.Features.Chats.Models.Bodies;

namespace InstaConnect.Chats.Presentation.Features.Chats.Models.Requests;

public record AddChatApiRequest(
	[UserIdFromClaim] string ParticipantOneId,
	[FromBody] AddChatApiBody Body
);
