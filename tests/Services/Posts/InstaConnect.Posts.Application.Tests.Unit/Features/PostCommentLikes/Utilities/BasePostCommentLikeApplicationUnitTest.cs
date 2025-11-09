using InstaConnect.Posts.Application.Extensions;

namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikeApplicationUnitTest : BasePostCommentLikeTest
{
    protected IApplicationMapper ApplicationMapper { get; }

    protected IPostCommentLikeService PostCommentLikeService { get; }

    protected IPostCommentLikeIncludeQueryBuilderFactory PostCommentLikeIncludeQueryBuilderFactory { get; }

    protected BasePostCommentLikeApplicationUnitTest()
    {
        ApplicationMapper = MockFactory.CreateApplicationMapper(PostApplicationReference.Assembly);
        PostCommentLikeService = PostCommentLikeMockFactory.CreateService();
        PostCommentLikeIncludeQueryBuilderFactory = PostCommentLikeMockFactory.CreateIncludeQueryBuilderFactory();
    }
}
