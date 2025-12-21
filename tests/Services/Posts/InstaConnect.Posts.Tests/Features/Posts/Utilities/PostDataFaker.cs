namespace InstaConnect.Posts.Tests.Features.Posts.Utilities;

public static class PostDataFaker
{
    public static string GetId()
    {
        return DataFaker.GetAverageString(PostConfigurations.IdMaxLength, PostConfigurations.IdMinLength);
    }

    public static string GetTitle()
    {
        return DataFaker.GetAverageString(PostConfigurations.TitleMaxLength, PostConfigurations.TitleMinLength);
    }

    public static string GetTitleWithPrefix(string title)
    {
        return DataFaker.GetAverageWithPrefixString(title, PostConfigurations.TitleMaxLength, PostConfigurations.TitleMinLength);
    }

    public static string GetContent()
    {
        return DataFaker.GetAverageString(PostConfigurations.ContentMaxLength, PostConfigurations.ContentMinLength);
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

    public static PostSortProperty GetSortProperty()
    {
        const PostSortProperty SortProperty = PostSortProperty.ByCreatedAt;

        return SortProperty;
    }
}
