namespace InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

public static class PostLikeDataFaker
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

    public static PostLikeSortProperty GetSortProperty()
    {
        const PostLikeSortProperty SortProperty = PostLikeSortProperty.ByCreatedAt;

        return SortProperty;
    }
}
