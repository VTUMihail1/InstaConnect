using InstaConnect.Posts.Domain.Features.Posts.Models.ValueObjects;
using InstaConnect.Posts.Events.Features.Posts;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.Posts.Utilities;

public static class PostEquals
{
    extension(PostAddedEventRequest request)
    {
        public bool Matches(Post entity)
        {
            return entity.Matches(request.Post);
        }
    }

    extension(PostUpdatedEventRequest request)
    {
        public bool Matches(Post entity)
        {
            return entity.Matches(request.Post);
        }
    }

    extension(PostDeletedEventRequest request)
    {
        public bool Matches(Post entity)
        {
            return entity.Matches(request.Post);
        }
    }

    extension(PostEventRequest r)
    {
        public bool Matches(PostEventRequest request)
        {
            return r.Id == request.Id &&
                   r.UserId == request.UserId &&
                   r.User.Matches(request.User) &&
                   r.Title == request.Title &&
                   r.Content == request.Content &&
                   r.CreatedAtUtc == request.CreatedAtUtc &&
                   r.UpdatedAtUtc == request.UpdatedAtUtc;
        }
    }

    extension(Post entity)
    {
        public bool Matches(PostEventRequest request)
        {
            return entity.Id.Matches(request.Id) &&
                   entity.UserId.Matches(request.UserId) &&
                   entity.User != null && entity.User.Matches(request.User) &&
                   entity.Title == request.Title &&
                   entity.Content == request.Content &&
                   entity.CreatedAtUtc == request.CreatedAtUtc &&
                   entity.UpdatedAtUtc == request.UpdatedAtUtc;
        }
    }

    extension(PostId p)
    {
        public bool Matches(string id)
        {
            return p.Id.EqualsOrdinalIgnoreCase(id);
        }
    }
}
