using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Helpers;

namespace InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Abstractions;

public interface IPostCommentLikeIncludeQueryBuilderFactory
{
    PostCommentLikeIncludeQueryBuilder Create();
}