using InstaConnect.Posts.Application.Extensions;

namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostLikes.Utilities;

public abstract class BasePostLikeApplicationUnitTest : BasePostLikeTest
{
    protected IApplicationMapper ApplicationMapper { get; }

    protected IPostLikeService PostLikeService { get; }

    protected IPostLikeIncludeQueryBuilderFactory PostLikeIncludeQueryBuilderFactory { get; }

    protected BasePostLikeApplicationUnitTest()
    {
        ApplicationMapper = MockFactory.CreateApplicationMapper(PostApplicationReference.Assembly);
        PostLikeService = PostLikeMockFactory.CreateService();
        PostLikeIncludeQueryBuilderFactory = PostLikeMockFactory.CreateIncludeQueryBuilderFactory();
    }
}
