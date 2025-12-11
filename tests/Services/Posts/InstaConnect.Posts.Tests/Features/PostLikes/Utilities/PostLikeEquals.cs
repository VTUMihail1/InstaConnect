using InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;
using InstaConnect.Posts.Events.Features.PostLikes;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

public static class PostLikeEquals
{
    public static bool Matches(this PostLikeAddedEventRequest request, PostLike entity)
    {
        return entity.Id.Matches(request.Id, request.UserId) &&
               request.CreatedAtUtc == entity.CreatedAtUtc;
    }

    public static bool Matches(this PostLikeDeletedEventRequest request, PostLike entity)
    {
        return entity.Id.Matches(request.Id, request.UserId);
    }

    public static bool Matches(this PostLikeId p, string id, string userId)
    {
        return p.Id.Matches(id) &&
               p.UserId.Matches(userId);
    }
}
