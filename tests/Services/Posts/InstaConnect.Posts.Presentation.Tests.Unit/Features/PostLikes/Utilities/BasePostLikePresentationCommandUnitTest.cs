using InstaConnect.Posts.Presentation.Extensions;

namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.PostLikes.Utilities;

public abstract class BasePostLikePresentationCommandUnitTest : BasePostLikeTest
{
    protected IApplicationSender Sender { get; }

    protected IApplicationMapper Mapper { get; }

    protected BasePostLikePresentationCommandUnitTest()
    {
        Sender = MockFactory.CreateApplicationSender();
        Mapper = MockFactory.CreateMapper(PostPresentationReference.Assembly);
    }
}
