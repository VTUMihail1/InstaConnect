using InstaConnect.Identity.Events.Features.EmailConfirmationTokens;
using InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Assertions;

public static class EmailConfirmationTokenEventAssertions
{
	extension(ICollection<EmailConfirmationTokenAddedEventRequest> r)
	{
		public bool ShouldSatisfy(AddEmailConfirmationTokenApiRequest request, ICollection<EmailConfirmationToken> entities)
		{
			return r.Matches(request, entities);
		}
	}

	extension(ICollection<EmailConfirmationTokenDeletedEventRequest> r)
	{
		public bool ShouldSatisfy(VerifyEmailConfirmationTokenApiRequest request, ICollection<EmailConfirmationToken> entities)
		{
			return r.Matches(request, entities);
		}
	}
}
