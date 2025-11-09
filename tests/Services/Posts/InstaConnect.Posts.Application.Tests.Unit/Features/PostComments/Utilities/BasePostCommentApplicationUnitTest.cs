using InstaConnect.Posts.Application.Extensions;

namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostComments.Utilities;

public abstract class BasePostCommentApplicationUnitTest : BasePostCommentTest
{
    protected IApplicationMapper ApplicationMapper { get; }

    protected IPostCommentService PostCommentService { get; }

    protected IPostCommentIncludeQueryBuilderFactory PostCommentIncludeQueryBuilderFactory { get; }

    protected BasePostCommentApplicationUnitTest()
    {
        ApplicationMapper = MockFactory.CreateApplicationMapper(PostApplicationReference.Assembly);
        PostCommentService = PostCommentMockFactory.CreateService();
        PostCommentIncludeQueryBuilderFactory = PostCommentMockFactory.CreateIncludeQueryBuilderFactory();
    }
}
