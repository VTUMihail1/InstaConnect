namespace InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageDataFaker
{
    public static string GetId()
    {
        return DataFaker.GetAverageString(ChatMessageConfigurations.IdMaxLength, ChatMessageConfigurations.IdMinLength);
    }

    public static string GetContent()
    {
        return DataFaker.GetAverageString(ChatMessageConfigurations.ContentMaxLength, ChatMessageConfigurations.ContentMinLength);
    }

    public static DateTimeOffset GetCreatedAtUtc()
    {
        return DataFaker.GetRecentDate();
    }

    public static DateTimeOffset GetUpdatedAtUtc()
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

    public static ChatMessagesSortTerm GetSortTerm()
    {
        const ChatMessagesSortTerm SortTerm = ChatMessagesSortTerm.ByCreatedAt;

        return SortTerm;
    }
}
