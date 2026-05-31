using InstaConnect.Chats.Domain.Features.Users.Models.ValueObjects;
using InstaConnect.Chats.Tests.Features.Users.Utilities;
using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Identity.Events.Features.Users;

namespace InstaConnect.Chats.Tests.Features.Users.Utilities;

public static class UserEquals
{
	extension(UserAddedEventRequest p)
	{
		public bool Matches(UserAddedEventRequest request)
		{
			return p.User.Matches(request.User);
		}
	}

	extension(UserUpdatedEventRequest p)
	{
		public bool Matches(UserUpdatedEventRequest request)
		{
			return p.User.Matches(request.User);
		}
	}

	extension(UserDeletedEventRequest p)
	{
		public bool Matches(UserDeletedEventRequest request)
		{
			return p.User.Matches(request.User);
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

		public bool Matches(User u)
		{
			return entity.Id.Matches(u.Id.Id) &&
				   entity.Email.Matches(u.Email.Value) &&
				   entity.FirstName == u.FirstName &&
				   entity.LastName == u.LastName &&
				   entity.Name.Matches(u.Name.Value) &&
				   entity.ProfileImage.Matches(u.ProfileImage?.Url) &&
				   entity.CreatedAtUtc == u.CreatedAtUtc &&
				   entity.UpdatedAtUtc == u.UpdatedAtUtc;
		}

		public bool Matches(UserNotificationRequest request)
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
