using InstaConnect.Identity.Presentation.Extensions;

namespace InstaConnect.Identity.Presentation.Tests.Unit.Features.EmailConfirmationTokens.Utilities;

public abstract class BaseEmailConfirmationTokenPresentationCommandUnitTest : BaseEmailConfirmationTokenTest
{
    protected IApplicationSender Sender { get; }

    protected IApplicationMapper Mapper { get; }

    protected BaseEmailConfirmationTokenPresentationCommandUnitTest() : base(IdentityMockFactory.CreatePasswordHasher())
    {
        Sender = MockFactory.CreateApplicationSender();
        Mapper = MockFactory.CreateMapper(IdentityPresentationReference.Assembly);
    }
}
