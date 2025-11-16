using InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;

namespace InstaConnect.Posts.Presentation.Features.PostLikes.Utilities;

public static class PostLikeDefaultValues
{
    public const PostLikeSortProperty SortProperty = PostLikeSortProperty.ByCreatedAt;

    public const int Page = 1;

    public const int PageSize = 20;
}
