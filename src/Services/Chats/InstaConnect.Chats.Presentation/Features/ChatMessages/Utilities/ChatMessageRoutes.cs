namespace InstaConnect.Chats.Presentation.Features.ChatMessages.Utilities;

public static class ChatMessageRoutes
{
	public const string Resource = "api/v{version:apiVersion}/participants/current/chats/{participantTwoId}/messages";

	public const string Id = "{messageId}";

	public const string Version1 = "1.0";

	public const string Hub = "/hubs/chat-messages";
}

