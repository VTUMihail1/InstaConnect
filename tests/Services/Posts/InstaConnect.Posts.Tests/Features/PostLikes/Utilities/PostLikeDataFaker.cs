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

    public static PostLikesSortTerm GetSortTerm()
    {
        const PostLikesSortTerm SortTerm = PostLikesSortTerm.ByCreatedAt;

        return SortTerm;
    }

    public static PostLikesForUserSortTerm GetForUserSortTerm()
    {
        const PostLikesForUserSortTerm SortTerm = PostLikesForUserSortTerm.ByCreatedAt;

        return SortTerm;
    }
}
