using InstaConnect.Posts.Presentation.Extensions;

namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.Posts.Utilities;

public abstract class BasePostPresentationUnitTest : BasePostTest
{
    protected IApplicationSender ApplicationSender { get; }

    protected IApplicationMapper ApplicationMapper { get; }

    protected BasePostPresentationUnitTest()
    {
        ApplicationSender = MockFactory.CreateApplicationSender();
        ApplicationMapper = MockFactory.CreateApplicationMapper(PostPresentationReference.Assembly);
    }
}
