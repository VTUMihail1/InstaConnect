using InstaConnect.PostLikeLikes.Domain.Features.PostLikeLikes.Abstractions;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Abstractions;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;

namespace InstaConnect.PostLikes.Domain.Features.PostLikes.Helpers;

internal class PostLikeFactory : IPostLikeFactory
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public PostLikeFactory(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public PostLike Create(string id, string userId)
    {
        var utcNow = _dateTimeProvider.GetOffsetUtcNow();
        var postLike = new PostLike(
            id,
            userId,
            utcNow,
            utcNow);

        return postLike;
    }
}
