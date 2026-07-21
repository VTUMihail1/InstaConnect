using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;
using InstaConnect.Identity.Events.Features.ForgotPasswordTokens;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenEquals
{
	extension(ForgotPasswordToken? entity)
	{
		public bool Matches(ForgotPasswordTokenEventRequest request)
		{
			return entity != null &&
				   entity.Id.Matches(request.Id, request.Value) &&
				   entity.User.Matches(request.User) &&
				   entity.ExpiresAtUtc == request.ExpiresAtUtc &&
				   entity.CreatedAtUtc == request.CreatedAtUtc;
		}
	}

	extension(ForgotPasswordToken entity)
	{
		public bool Matches(ForgotPasswordToken e)
		{
			return entity.Id.Matches(e.Id) &&
				   entity.ExpiresAtUtc == e.ExpiresAtUtc &&
				   entity.CreatedAtUtc == e.CreatedAtUtc;
		}
	}

	extension(ForgotPasswordTokenId p)
	{
		public bool Matches(ForgotPasswordTokenId id)
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
