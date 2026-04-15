using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Presentation.Features.Posts.Utilities;

public static class PostDefaultValues
{
    public const string Title = "";

    public const PostsSortTerm SortTerm = PostsSortTerm.ByCreatedAt;

    public const PostsForUserSortTerm SortTermForUser = PostsForUserSortTerm.ByCreatedAt;

    public const int Page = 1;

    public const int PageSize = 20;
}
