using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Identity.Domain.Features.Users.Models.ValueObjects;
using InstaConnect.Identity.Events.Features.Users;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Tests.Features.Users.Utilities;

public static class UserEquals
{
    extension(UserAddedEventRequest request)
    {
        public bool Matches(User entity)
        {
            return entity.Matches(request.User);
        }
    }

    extension(UserUpdatedEventRequest request)
    {
        public bool Matches(User entity)
        {
            return entity.Matches(request.User);
        }
    }

    extension(UserDeletedEventRequest request)
    {
        public bool Matches(User entity)
        {
            return entity.Matches(request.User);
        }
    }

    extension(UserEventRequest r)
    {
        public bool Matches(UserEventRequest request)
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
    }

    extension(User entity)
    {
        public bool Matches(UserEventRequest request)
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
    }

    extension(UserId p)
    {
        public bool Matches(string id)
        {
            return p.Id.EqualsOrdinalIgnoreCase(id);
        }
    }
}
