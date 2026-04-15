using InstaConnect.Posts.Application.Extensions;

namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostComments.Utilities;

public abstract class BasePostCommentApplicationQueryUnitTest : BasePostCommentTest
{
    protected IApplicationMapper Mapper { get; }

    protected IPostCommentQueryService CommentService { get; }

    protected BasePostCommentApplicationQueryUnitTest()
    {
        Mapper = MockFactory.CreateMapper(PostApplicationReference.Assembly);
        CommentService = PostCommentMockFactory.CreateQueryService();
    }
}
