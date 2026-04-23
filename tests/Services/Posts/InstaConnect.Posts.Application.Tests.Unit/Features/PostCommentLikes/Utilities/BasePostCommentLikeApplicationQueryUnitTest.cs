using InstaConnect.Posts.Application.Features.Common.Extensions;

namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikeApplicationQueryUnitTest : BasePostCommentLikeTest
{
    protected IApplicationMapper Mapper { get; }

    protected IPostCommentLikeQueryService CommentLikeService { get; }

    protected BasePostCommentLikeApplicationQueryUnitTest()
    {
        Mapper = MockFactory.CreateMapper(PostsApplicationReference.Assembly);
        CommentLikeService = PostCommentLikeMockFactory.CreateQueryService();
    }
}
