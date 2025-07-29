using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Abstractions;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Entities;

namespace InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Helpers;

internal class PostCommentLikeFactory : IPostCommentLikeFactory
{
    private readonly IGuidProvider _guidProvider;
    private readonly IDateTimeProvider _dateTimeProvider;

    public PostCommentLikeFactory(
        IGuidProvider guidProvider,
        IDateTimeProvider dateTimeProvider)
    {
        _guidProvider = guidProvider;
        _dateTimeProvider = dateTimeProvider;
    }

    public PostCommentLike Create(string id, string commentId, string userId)
    {
        var commentLikeId = _guidProvider.NewGuid().ToString();
        var utcNow = _dateTimeProvider.GetOffsetUtcNow();
        var postCommentLike = new PostCommentLike(
            id,
            commentId,
            commentLikeId,
            userId,
            utcNow,
            utcNow);

        return postCommentLike;
    }
}
