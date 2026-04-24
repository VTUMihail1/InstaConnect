using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Identity.Application.Tests.Integration.Features.UserClaims.Utilities;

public abstract class BaseUserClaimApplicationCommandIntegrationTest : BaseUserClaimWebTest
{
    protected IApplicationSender Sender { get; }

    protected BaseUserClaimApplicationCommandIntegrationTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        Sender = ServiceScope.GetSender();
    }
}
