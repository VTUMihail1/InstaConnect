using InstaConnect.Identity.Events.Features.Users;
using InstaConnect.Posts.Domain.Features.Users.Models.ValueObjects;

namespace InstaConnect.Posts.Tests.Features.Users.Utilities;
public static class UserEquals
{
    public static bool Matches(this UserAddedEventRequest p, UserAddedEventRequest request)
    {
        return p.User.Matches(request.User);
    }

    public static bool Matches(this UserUpdatedEventRequest p, UserUpdatedEventRequest request)
    {
        return p.User.Matches(request.User);
    }

    public static bool Matches(this UserDeletedEventRequest p, UserDeletedEventRequest request)
    {
        return p.User.Matches(request.User);
    }

    public static bool Matches(this UserEventRequest r, UserEventRequest request)
    {
        return r.Id == request.Id &&
               r.Name == request.Name &&
               r.Email == request.Email &&
               r.FirstName == request.FirstName &&
               r.LastName == request.LastName &&
               r.ProfileImageUrl == request.ProfileImageUrl &&
               r.CreatedAtUtc == request.CreatedAtUtc &&
               r.UpdatedAtUtc == request.UpdatedAtUtc;
    }

    public static bool Matches(this User entity, UserEventRequest request)
    {
        return entity.Id.Matches(request.Id) &&
               entity.Name.Matches(request.Name) &&
               entity.Email.Matches(request.Email) &&
               entity.FirstName == request.FirstName &&
               entity.LastName == request.LastName &&
               entity.ProfileImage.Matches(request.ProfileImageUrl) &&
               entity.CreatedAtUtc == request.CreatedAtUtc &&
               entity.UpdatedAtUtc == request.UpdatedAtUtc;
    }

    public static bool Matches(this UserId p, string id)
    {
        return p.Id.EqualsOrdinalIgnoreCase(id);
    }
}
