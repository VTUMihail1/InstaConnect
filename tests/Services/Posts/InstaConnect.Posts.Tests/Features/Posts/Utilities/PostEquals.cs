using InstaConnect.Posts.Domain.Features.Posts.Models.ValueObjects;
using InstaConnect.Posts.Events.Features.Posts;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.Posts.Utilities;
public static class PostEquals
{
    public static bool Matches(this PostAddedEventRequest request, Post entity)
    {
        return entity.Id.Matches(request.Id) &&
               entity.UserId.Matches(request.UserId) &&
               entity.Title == request.Title &&
               entity.Content == request.Content &&
               entity.CreatedAtUtc == request.CreatedAtUtc &&
               entity.UpdatedAtUtc == request.UpdatedAtUtc;
    }

    public static bool Matches(this PostUpdatedEventRequest request, Post entity)
    {
        return entity.Id.Matches(request.Id) &&
               entity.UserId.Matches(request.UserId) &&
               entity.Title == request.Title &&
               entity.Content == request.Content &&
               entity.UpdatedAtUtc == request.UpdatedAtUtc;
    }

    public static bool Matches(this PostDeletedEventRequest request, Post entity)
    {
        return entity.Id.Matches(request.Id);
    }

    public static bool Matches(this PostId p, string id)
    {
        return p.Id == id;
    }
}
