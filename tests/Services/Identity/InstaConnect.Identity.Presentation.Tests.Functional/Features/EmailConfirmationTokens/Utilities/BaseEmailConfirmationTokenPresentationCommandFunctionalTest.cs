using InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Extensions;

namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.EmailConfirmationTokens.Utilities;

public abstract class BaseEmailConfirmationTokenPresentationCommandFunctionalTest : BaseEmailConfirmationTokenWebTest
{
	protected IEmailConfirmationTokenClient Client { get; }

	protected BaseEmailConfirmationTokenPresentationCommandFunctionalTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Client = webApplicationFactory.CreateEmailConfirmationTokenClient();
	}
}
