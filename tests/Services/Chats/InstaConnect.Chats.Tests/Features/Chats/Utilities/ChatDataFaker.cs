namespace InstaConnect.Chats.Tests.Features.Chats.Utilities;

public static class ChatDataFaker
{
	public static DateTimeOffset GetCreatedAtUtc()
	{
		return DataFaker.GetRecentDate();
	}

	public static int GetPage()
	{
		const int Page = 1;

		return Page;
	}

	public static int GetPageSize()
	{
		const int PageSize = 20;

		return PageSize;
	}

	public static ChatsSortTerm GetSortTerm()
	{
		const ChatsSortTerm SortTerm = ChatsSortTerm.ByCreatedAt;

		return SortTerm;
	}
}
