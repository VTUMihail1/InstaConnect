namespace InstaConnect.Chats.Presentation.Features.ChatMessages.Models.Requests;

public record DeleteChatMessageApiRequest(
	[UserIdFromClaim] string ParticipantOneId,
	[FromRoute] string ParticipantTwoId,
	[FromRoute] string MessageId
);
