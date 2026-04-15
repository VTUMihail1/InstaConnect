using InstaConnect.Posts.Application.Extensions;

namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostLikes.Utilities;

public abstract class BasePostLikeApplicationCommandUnitTest : BasePostLikeTest
{
    protected IApplicationMapper Mapper { get; }

    protected IPostLikeCommandService LikeService { get; }

    protected BasePostLikeApplicationCommandUnitTest()
    {
        Mapper = MockFactory.CreateMapper(PostApplicationReference.Assembly);
        LikeService = PostLikeMockFactory.CreateCommandService();
    }
}
