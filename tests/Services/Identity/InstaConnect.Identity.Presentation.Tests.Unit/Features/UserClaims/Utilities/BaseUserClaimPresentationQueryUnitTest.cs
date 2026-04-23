using InstaConnect.Identity.Presentation.Features.Common.Extensions;
using InstaConnect.Identity.Tests.Features.Common.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Unit.Features.UserClaims.Utilities;

public abstract class BaseUserClaimPresentationQueryUnitTest : BaseUserClaimTest
{
    protected IApplicationSender Sender { get; }

    protected IApplicationMapper Mapper { get; }

    protected BaseUserClaimPresentationQueryUnitTest() : base(IdentityMockFactory.CreatePasswordHasher())
    {
        Sender = MockFactory.CreateApplicationSender();
        Mapper = MockFactory.CreateMapper(IdentityPresentationReference.Assembly);
    }
}
