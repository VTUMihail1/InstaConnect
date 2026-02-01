using InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;
using InstaConnect.Posts.Events.Features.PostLikes;
using InstaConnect.Posts.Events.Features.Posts;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

public static class PostLikeEquals
{
    public static bool Matches(this PostLikeAddedEventRequest request, PostLike entity)
    {
        return entity.Matches(request.PostLike);
    }

    public static bool Matches(this PostLikeDeletedEventRequest request, PostLike entity)
    {
        return entity.Matches(request.PostLike);
    }

    public static bool Matches(this PostLikeEventRequest r, PostLikeEventRequest request)
    {
        return r.Id == request.Id &&
               r.UserId == request.UserId &&
               r.User.Matches(request.User) &&
               r.Post.Matches(request.Post) &&
               r.CreatedAtUtc == request.CreatedAtUtc;
    }

    public static bool Matches(this PostLike entity, PostLikeEventRequest request)
    {
        return entity.Id.Matches(request.Id, request.UserId) &&
               entity.User != null && entity.User.Matches(request.User) &&
               entity.Post != null && entity.Post.Matches(request.Post) &&
               entity.CreatedAtUtc == request.CreatedAtUtc;
    }

    public static bool Matches(this PostLikeId p, string id, string userId)
    {
        return p.Id.Matches(id) &&
               p.UserId.Matches(userId);
    }
}
