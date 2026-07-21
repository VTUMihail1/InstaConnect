using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.ValueObjects;
using InstaConnect.Identity.Events.Features.EmailConfirmationTokens;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenEquals
{
	extension(EmailConfirmationToken? entity)
	{
		public bool Matches(EmailConfirmationTokenEventRequest request)
		{
			return entity != null &&
				   entity.Id.Matches(request.Id, request.Value) &&
				   entity.User.Matches(request.User) &&
				   entity.ExpiresAtUtc == request.ExpiresAtUtc &&
				   entity.CreatedAtUtc == request.CreatedAtUtc;
		}
	}

	extension(EmailConfirmationToken entity)
	{
		public bool Matches(EmailConfirmationToken e)
		{
			return entity.Id.Matches(e.Id) &&
				   entity.ExpiresAtUtc == e.ExpiresAtUtc &&
				   entity.CreatedAtUtc == e.CreatedAtUtc;
		}
	}

	extension(EmailConfirmationTokenId p)
	{
		public bool Matches(EmailConfirmationTokenId id)
		{
			return p.Matches(id.Id.Id, id.Value);
		}

		public bool Matches(string id, string value)
		{
			return p.Id.Matches(id) &&
				   p.Value.EqualsOrdinalIgnoreCase(value);
		}
	}
}
