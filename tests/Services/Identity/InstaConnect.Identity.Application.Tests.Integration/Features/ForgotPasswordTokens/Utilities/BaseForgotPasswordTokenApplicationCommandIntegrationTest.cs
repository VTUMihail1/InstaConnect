using InstaConnect.Identity.Tests.Features.Common.Utilities;

namespace InstaConnect.Identity.Application.Tests.Integration.Features.ForgotPasswordTokens.Utilities;

public abstract class BaseForgotPasswordTokenApplicationCommandIntegrationTest : BaseForgotPasswordTokenWebTest
{
    protected IApplicationSender Sender { get; }

    protected BaseForgotPasswordTokenApplicationCommandIntegrationTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        Sender = ServiceScope.GetSender();
    }
}
