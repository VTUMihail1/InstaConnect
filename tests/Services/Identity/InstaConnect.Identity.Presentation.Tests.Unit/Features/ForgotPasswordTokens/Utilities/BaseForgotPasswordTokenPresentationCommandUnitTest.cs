using InstaConnect.Identity.Presentation.Features.Common.Extensions;
using InstaConnect.Identity.Tests.Features.Common.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Unit.Features.ForgotPasswordTokens.Utilities;

public abstract class BaseForgotPasswordTokenPresentationCommandUnitTest : BaseForgotPasswordTokenTest
{
    protected IApplicationSender Sender { get; }

    protected IApplicationMapper Mapper { get; }

    protected BaseForgotPasswordTokenPresentationCommandUnitTest() : base(IdentityMockFactory.CreatePasswordHasher())
    {
        Sender = MockFactory.CreateApplicationSender();
        Mapper = MockFactory.CreateMapper(IdentityPresentationReference.Assembly);
    }
}
