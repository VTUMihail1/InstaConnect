using InstaConnect.Posts.Application.Extensions;

namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikeApplicationQueryUnitTest : BasePostCommentLikeTest
{
    protected IApplicationMapper Mapper { get; }

    protected IPostCommentLikeQueryService CommentLikeService { get; }

    protected BasePostCommentLikeApplicationQueryUnitTest()
    {
        Mapper = MockFactory.CreateMapper(PostApplicationReference.Assembly);
        CommentLikeService = PostCommentLikeMockFactory.CreateQueryService();
    }
}
