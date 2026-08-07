using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Identity.Domain.Features.Users.Models.ValueObjects;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Tests.Features.Users.Utilities;

public static class UserEquals
{
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
