using InstaConnect.Chats.Presentation.Features.ChatMessages.Models.Bodies;

namespace InstaConnect.Chats.Presentation.Features.ChatMessages.Models.Requests;

public record AddChatMessageApiRequest(
	[UserIdFromClaim] string ParticipantOneId,
	[FromRoute] string ParticipantTwoId,
	[FromBody] AddChatMessageApiBody Body
);
