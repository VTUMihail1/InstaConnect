using InstaConnect.Posts.Application.Features.Common.Extensions;

namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostLikes.Utilities;

public abstract class BasePostLikeApplicationQueryUnitTest : BasePostLikeTest
{
    protected IApplicationMapper Mapper { get; }

    protected IPostLikeQueryService LikeService { get; }

    protected BasePostLikeApplicationQueryUnitTest()
    {
        Mapper = MockFactory.CreateMapper(PostsApplicationReference.Assembly);
        LikeService = PostLikeMockFactory.CreateQueryService();
    }
}
