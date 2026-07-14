using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Identity.Application.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Events.Features.EmailConfirmationTokens;

namespace InstaConnect.Identity.Application.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenEquals
{
	extension(EmailConfirmationTokenAddedEventRequest r)
	{
		public bool Matches(AddEmailConfirmationTokenCommandRequest request, EmailConfirmationToken entity)
		{
			return entity.Id.Matches(r.EmailConfirmationToken.Id, r.EmailConfirmationToken.Value) &&
				   request.Name.EqualsOrdinalIgnoreCase(r.EmailConfirmationToken.User.Name) &&
				   entity.User != null && entity.User.Matches(r.EmailConfirmationToken.User) &&
				   entity.ExpiresAtUtc == r.EmailConfirmationToken.ExpiresAtUtc &&
				   entity.CreatedAtUtc == r.EmailConfirmationToken.CreatedAtUtc;
		}
	}

	extension(EmailConfirmationTokenDeletedEventRequest r)
	{
		public bool Matches(VerifyEmailConfirmationTokenCommandRequest request, EmailConfirmationToken entity)
		{
			return entity.Id.Matches(r.EmailConfirmationToken.Id, r.EmailConfirmationToken.Value) &&
				   entity.User != null && entity.User.Matches(r.EmailConfirmationToken.User) &&
				   entity.ExpiresAtUtc == r.EmailConfirmationToken.ExpiresAtUtc &&
				   entity.CreatedAtUtc == r.EmailConfirmationToken.CreatedAtUtc;
		}
	}

	extension(AddEmailConfirmationTokenCommand command)
	{
		public bool Matches(AddEmailConfirmationTokenCommandRequest request)
		{
			return command.Name.Matches(request.Name);
		}
	}

	extension(VerifyEmailConfirmationTokenCommand command)
	{
		public bool Matches(VerifyEmailConfirmationTokenCommandRequest request)
		{
			return command.Id.Matches(request.Id, request.Value);
		}
	}

	extension(EmailConfirmationToken emailConfirmationToken)
	{
		public bool Matches(AddEmailConfirmationTokenCommandRequest request)
		{
			return emailConfirmationToken.User!.Name.Matches(request.Name);
		}

		public bool Matches(VerifyEmailConfirmationTokenCommandRequest request)
		{
			return emailConfirmationToken.Id.Matches(request.Id, request.Value);
		}
	}
}
