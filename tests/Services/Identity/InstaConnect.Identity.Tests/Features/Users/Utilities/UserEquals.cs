using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Identity.Domain.Features.Users.Models.ValueObjects;
using InstaConnect.Identity.Events.Features.Users;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Tests.Features.Users.Utilities;

public static class UserEquals
{
	extension(User? entity)
	{
		public bool Matches(UserEventRequest request)
		{
			return entity != null &&
				   entity.Id.Matches(request.Id) &&
				   entity.Name.Matches(request.Name) &&
				   entity.Email.Matches(request.Email) &&
				   entity.FirstName == request.FirstName &&
				   entity.LastName == request.LastName &&
				   entity.ProfileImage.Matches(request.ProfileImageUrl) &&
				   entity.CreatedAtUtc == request.CreatedAtUtc &&
				   entity.UpdatedAtUtc == request.UpdatedAtUtc;
		}
	}

	extension(User entity)
	{
		public bool Matches(User user)
		{
			return entity.Id.Matches(user.Id) &&
				   entity.Name.Matches(user.Name) &&
				   entity.Email.Matches(user.Email) &&
				   entity.FirstName == user.FirstName &&
				   entity.LastName == user.LastName &&
				   entity.ProfileImage.Matches(user.ProfileImage) &&
				   entity.CreatedAtUtc == user.CreatedAtUtc &&
				   entity.UpdatedAtUtc == user.UpdatedAtUtc;
		}
	}

	extension(UserId p)
	{
		public bool Matches(UserId id)
		{
			return p.Matches(id.Id);
		}

		public bool Matches(string id)
		{
			return p.Id.EqualsOrdinalIgnoreCase(id);
		}
	}
}
