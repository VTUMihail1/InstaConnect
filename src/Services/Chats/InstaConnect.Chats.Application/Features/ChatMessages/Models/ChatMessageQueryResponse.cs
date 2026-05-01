namespace InstaConnect.Chats.Application.Features.ChatMessages.Models;

public record ChatMessageQueryResponse(
	string ParticipantOneId,
	string ParticipantTwoId,
	string MessageId,
	string SenderId,
	string Content,
	ChatQueryResponse? Chat,
	UserQueryResponse? Sender,
	DateTimeOffset CreatedAtUtc,
	DateTimeOffset UpdatedAtUtc);
