using InstaConnect.Posts.Domain.Features.PostCommentLikes.Helpers;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;

public interface IPostCommentLikeIncludeQueryBuilderFactory
{
    PostCommentLikeIncludeQueryBuilder Create();
}