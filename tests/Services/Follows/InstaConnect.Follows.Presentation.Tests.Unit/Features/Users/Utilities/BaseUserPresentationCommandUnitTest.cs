using InstaConnect.Follows.Presentation.Features.Common.Extensions;

namespace InstaConnect.Follows.Presentation.Tests.Unit.Features.Users.Utilities;

public abstract class BaseUserPresentationCommandUnitTest : BaseUserTest
{
    protected IApplicationSender Sender { get; }

    protected IApplicationMapper Mapper { get; }

    protected BaseUserPresentationCommandUnitTest()
    {
        Sender = MockFactory.CreateApplicationSender();
        Mapper = MockFactory.CreateMapper(FollowsPresentationReference.Assembly);
    }
}
