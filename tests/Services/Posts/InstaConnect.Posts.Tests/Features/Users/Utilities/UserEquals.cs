using InstaConnect.Identity.Events.Features.Users;
using InstaConnect.Posts.Domain.Features.Users.Models.ValueObjects;

namespace InstaConnect.Posts.Tests.Features.Users.Utilities;
public static class UserEquals
{
    public static bool Matches(this UserAddedEventRequest p, UserAddedEventRequest request)
    {
        return p.Id == request.Id &&
               p.Name == request.Name &&
               p.Email == request.Email &&
               p.FirstName == request.FirstName &&
               p.LastName == request.LastName &&
               p.ProfileImageUrl == request.ProfileImageUrl &&
               p.CreatedAtUtc == request.CreatedAtUtc &&
               p.UpdatedAtUtc == request.UpdatedAtUtc;
    }

    public static bool Matches(this UserUpdatedEventRequest p, UserUpdatedEventRequest request)
    {
        return p.Id == request.Id &&
               p.Name == request.Name &&
               p.Email == request.Email &&
               p.FirstName == request.FirstName &&
               p.LastName == request.LastName &&
               p.ProfileImageUrl == request.ProfileImageUrl &&
               p.UpdatedAtUtc == request.UpdatedAtUtc;
    }

    public static bool Matches(this UserDeletedEventRequest p, UserDeletedEventRequest request)
    {
        return p.Id == request.Id;
    }

    public static bool Matches(this UserId p, string id)
    {
        return p.Id == id;
    }
}
