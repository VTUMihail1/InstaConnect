using InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Extensions;

namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.ForgotPasswordTokens.Utilities;

public abstract class BaseForgotPasswordTokenPresentationCommandFunctionalTest : BaseForgotPasswordTokenWebTest
{
	protected IForgotPasswordTokenClient Client { get; }

	protected BaseForgotPasswordTokenPresentationCommandFunctionalTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Client = webApplicationFactory.CreateForgotPasswordTokenClient();
	}
}
