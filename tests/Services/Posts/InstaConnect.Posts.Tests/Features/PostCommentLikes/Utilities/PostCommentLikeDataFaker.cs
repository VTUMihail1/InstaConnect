namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeDataFaker
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

    public static PostCommentLikesSortTerm GetSortTerm()
    {
        const PostCommentLikesSortTerm SortTerm = PostCommentLikesSortTerm.ByCreatedAt;

        return SortTerm;
    }

    public static PostCommentLikesForUserSortTerm GetForUserSortTerm()
    {
        const PostCommentLikesForUserSortTerm SortTerm = PostCommentLikesForUserSortTerm.ByCreatedAt;

        return SortTerm;
    }
}
