using InstaConnect.Posts.Presentation.Features.Common.Extensions;

namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.PostComments.Utilities;

public abstract class BasePostCommentPresentationCommandUnitTest : BasePostCommentTest
{
    protected IApplicationSender Sender { get; }

    protected IApplicationMapper Mapper { get; }

    protected BasePostCommentPresentationCommandUnitTest()
    {
        Sender = MockFactory.CreateApplicationSender();
        Mapper = MockFactory.CreateMapper(PostsPresentationReference.Assembly);
    }
}
