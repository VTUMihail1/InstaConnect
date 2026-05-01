namespace InstaConnect.Chats.Application.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageMockFactory
{
	public static IChatMessageCommandService CreateCommandService()
	{
		return Mocker.Mock<IChatMessageCommandService>();
	}

	public static IChatMessageQueryService CreateQueryService()
	{
		return Mocker.Mock<IChatMessageQueryService>();
	}
}
