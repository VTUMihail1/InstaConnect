using InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Events.Features.EmailConfirmationTokens;

namespace InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Assertions;

public static class EmailConfirmationTokenEventAssertions
{
	extension(ICollection<EmailConfirmationTokenAddedEventRequest> r)
	{
		public bool ShouldSatisfy(AddEmailConfirmationTokenCommand command, ICollection<EmailConfirmationToken> entities)
		{
			return r.Matches(command, entities);
		}
	}

	extension(ICollection<EmailConfirmationTokenDeletedEventRequest> r)
	{
		public bool ShouldSatisfy(VerifyEmailConfirmationTokenCommand command, ICollection<EmailConfirmationToken> entities)
		{
			return r.Matches(command, entities);
		}
	}
}
