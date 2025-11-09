using InstaConnect.Posts.Presentation.Extensions;

namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.PostLikes.Utilities;

public abstract class BasePostLikePresentationUnitTest : BasePostLikeTest
{
    protected IApplicationSender ApplicationSender { get; }

    protected IApplicationMapper ApplicationMapper { get; }

    protected BasePostLikePresentationUnitTest()
    {
        ApplicationSender = MockFactory.CreateApplicationSender();
        ApplicationMapper = MockFactory.CreateApplicationMapper(PostPresentationReference.Assembly);
    }
}
