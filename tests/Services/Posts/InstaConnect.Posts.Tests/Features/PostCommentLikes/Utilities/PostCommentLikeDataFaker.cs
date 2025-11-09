namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeDataFaker
{
    public static DateTimeOffset GetCreatedAt()
    {
        return DataFaker.GetMaxDate();
    }

    public static DateTimeOffset GetUpdatedAt()
    {
        return DataFaker.GetMaxDate();
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

    public static PostCommentLikeSortProperty GetSortProperty()
    {
        const PostCommentLikeSortProperty SortProperty = PostCommentLikeSortProperty.ByCreatedAt;

        return SortProperty;
    }
}
