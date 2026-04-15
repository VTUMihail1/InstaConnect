using InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;

namespace InstaConnect.Posts.Presentation.Features.PostLikes.Utilities;

public static class PostLikeDefaultValues
{
    public const PostLikesSortTerm SortTerm = PostLikesSortTerm.ByCreatedAt;

    public const PostLikesForUserSortTerm SortTermForUser = PostLikesForUserSortTerm.ByCreatedAt;

    public const int Page = 1;

    public const int PageSize = 20;
}
