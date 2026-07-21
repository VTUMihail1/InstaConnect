using InstaConnect.Identity.Application.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Events.Features.EmailConfirmationTokens;

namespace InstaConnect.Identity.Application.Tests.Features.EmailConfirmationTokens.Assertions;

public static class EmailConfirmationTokenEventAssertions
{
	extension(ICollection<EmailConfirmationTokenAddedEventRequest> r)
	{
		public bool ShouldSatisfy(AddEmailConfirmationTokenCommandRequest request, ICollection<EmailConfirmationToken> entities)
		{
			return r.Matches(request, entities);
		}
	}

	extension(ICollection<EmailConfirmationTokenDeletedEventRequest> r)
	{
		public bool ShouldSatisfy(VerifyEmailConfirmationTokenCommandRequest request, ICollection<EmailConfirmationToken> entities)
		{
			return r.Matches(request, entities);
		}
	}
}
