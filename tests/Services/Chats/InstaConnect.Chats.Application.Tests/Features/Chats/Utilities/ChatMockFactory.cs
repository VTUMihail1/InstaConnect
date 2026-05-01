namespace InstaConnect.Chats.Application.Tests.Features.Chats.Utilities;

public static class ChatMockFactory
{
	public static IChatCommandService CreateCommandService()
	{
		return Mocker.Mock<IChatCommandService>();
	}

	public static IChatQueryService CreateQueryService()
	{
		return Mocker.Mock<IChatQueryService>();
	}
}
