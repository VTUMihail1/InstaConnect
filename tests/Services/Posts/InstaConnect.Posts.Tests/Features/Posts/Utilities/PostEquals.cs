using InstaConnect.Identity.Events.Features.Users;
using InstaConnect.Posts.Domain.Features.Posts.Models.ValueObjects;
using InstaConnect.Posts.Events.Features.Posts;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.Posts.Utilities;
public static class PostEquals
{
    public static bool Matches(this PostAddedEventRequest request, Post entity)
    {
        return entity.Matches(request.Post);
    }

    public static bool Matches(this PostUpdatedEventRequest request, Post entity)
    {
        return entity.Matches(request.Post);
    }

    public static bool Matches(this PostDeletedEventRequest request, Post entity)
    {
        return entity.Matches(request.Post);
    }

    public static bool Matches(this PostEventRequest r, PostEventRequest request)
    {
        return r.Id == request.Id &&
               r.UserId == request.UserId &&
               r.User.Matches(request.User) &&
               r.Title == request.Title &&
               r.Content == request.Content &&
               r.CreatedAtUtc == request.CreatedAtUtc &&
               r.UpdatedAtUtc == request.UpdatedAtUtc;
    }

    public static bool Matches(this Post entity, PostEventRequest request)
    {
        return entity.Id.Matches(request.Id) &&
               entity.UserId.Matches(request.UserId) &&
               entity.User != null && entity.User.Matches(request.User) &&
               entity.Title == request.Title &&
               entity.Content == request.Content &&
               entity.CreatedAtUtc == request.CreatedAtUtc &&
               entity.UpdatedAtUtc == request.UpdatedAtUtc;
    }

    public static bool Matches(this PostId p, string id)
    {
        return p.Id.EqualsOrdinalIgnoreCase(id);
    }
}
