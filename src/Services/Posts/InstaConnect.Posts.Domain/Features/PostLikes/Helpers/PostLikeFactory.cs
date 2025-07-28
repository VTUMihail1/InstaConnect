using InstaConnect.PostLikeLikes.Domain.Features.PostLikeLikes.Abstractions;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Abstractions;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;

namespace InstaConnect.PostLikes.Domain.Features.PostLikes.Helpers;

internal class PostLikeFactory : IPostLikeFactory
{
    private readonly IGuidProvider _guidProvider;
    private readonly IDateTimeProvider _dateTimeProvider;

    public PostLikeFactory(
        IGuidProvider guidProvider,
        IDateTimeProvider dateTimeProvider)
    {
        _guidProvider = guidProvider;
        _dateTimeProvider = dateTimeProvider;
    }

    public PostLike Create(string id, string userId)
    {
        var likeId = _guidProvider.NewGuid().ToString();
        var utcNow = _dateTimeProvider.GetOffsetUtcNow();
        var postLike = new PostLike(
            id,
            likeId,
            userId,
            utcNow,
            utcNow);

        return postLike;
    }
}
