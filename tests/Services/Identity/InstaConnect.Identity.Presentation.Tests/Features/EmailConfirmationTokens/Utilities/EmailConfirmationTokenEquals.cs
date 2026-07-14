using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Identity.Events.Features.EmailConfirmationTokens;
using InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Utilities;


public static class EmailConfirmationTokenEquals
{
	extension(EmailConfirmationTokenAddedEventRequest r)
	{
		public bool Matches(AddEmailConfirmationTokenApiRequest request, EmailConfirmationToken entity)
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
		public bool Matches(VerifyEmailConfirmationTokenApiRequest request, EmailConfirmationToken entity)
		{
			return entity.Id.Matches(r.EmailConfirmationToken.Id, r.EmailConfirmationToken.Value) &&
				   entity.User != null && entity.User.Matches(r.EmailConfirmationToken.User) &&
				   entity.ExpiresAtUtc == r.EmailConfirmationToken.ExpiresAtUtc &&
				   entity.CreatedAtUtc == r.EmailConfirmationToken.CreatedAtUtc;
		}
	}

	extension(AddEmailConfirmationTokenCommandRequest command)
	{
		public bool Matches(AddEmailConfirmationTokenApiRequest request)
		{
			return command.Name == request.Name;
		}
	}

	extension(VerifyEmailConfirmationTokenCommandRequest command)
	{
		public bool Matches(VerifyEmailConfirmationTokenApiRequest request)
		{
			return command.Id == request.Id &&
				   command.Value == request.Value;
		}
	}

	extension(EmailConfirmationToken emailConfirmationToken)
	{
		public bool Matches(AddEmailConfirmationTokenApiRequest request)
		{
			return emailConfirmationToken.User!.Name.Matches(request.Name);
		}

		public bool Matches(VerifyEmailConfirmationTokenApiRequest request)
		{
			return emailConfirmationToken.Id.Matches(request.Id, request.Value);
		}
	}
}
