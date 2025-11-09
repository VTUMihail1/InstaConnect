using InstaConnect.Posts.Presentation.Extensions;

namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.Users.Utilities;

public abstract class BaseUserPresentationUnitTest : BaseUserTest
{
    protected IApplicationSender ApplicationSender { get; }

    protected IApplicationMapper ApplicationMapper { get; }

    protected BaseUserPresentationUnitTest()
    {
        ApplicationSender = MockFactory.CreateApplicationSender();
        ApplicationMapper = MockFactory.CreateApplicationMapper(PostPresentationReference.Assembly);
    }
}
