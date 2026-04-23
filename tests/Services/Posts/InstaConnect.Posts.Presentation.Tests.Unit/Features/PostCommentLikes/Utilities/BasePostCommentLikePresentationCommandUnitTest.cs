using InstaConnect.Posts.Presentation.Features.Common.Extensions;

namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikePresentationCommandUnitTest : BasePostCommentLikeTest
{
    protected IApplicationSender Sender { get; }

    protected IApplicationMapper Mapper { get; }

    protected BasePostCommentLikePresentationCommandUnitTest()
    {
        Sender = MockFactory.CreateApplicationSender();
        Mapper = MockFactory.CreateMapper(PostsPresentationReference.Assembly);
    }
}
