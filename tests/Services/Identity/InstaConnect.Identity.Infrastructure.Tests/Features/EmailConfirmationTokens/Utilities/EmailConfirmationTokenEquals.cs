using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Entities;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.ValueObjects;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenEquals
{
	extension(EmailConfirmationToken p)
	{
		public bool Matches(
			EmailConfirmationTokenId id,
			EmailConfirmationToken emailConfirmationToken)
		{
			return p.Matches(emailConfirmationToken);
		}
	}

	extension(bool response)
	{
		public bool Matches(EmailConfirmationTokenId id)
		{
			return response;
		}
	}
}
