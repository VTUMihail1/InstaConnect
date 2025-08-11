using InstaConnect.Common.Abstractions;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Application.Extensions;

namespace InstaConnect.PostLikes.Application.UnitTests.Features.PostLikes.Utilities;

public abstract class BasePostLikeApplicationUnitTest : BasePostLikeTest
{
    protected IApplicationMapper ApplicationMapper { get; }

    protected IPostLikeService PostLikeService { get; }

    protected BasePostLikeApplicationUnitTest()
    {
        ApplicationMapper = MockFactory.CreateApplicationMapper(PostApplicationReference.Assembly);
        PostLikeService = PostLikeMockFactory.CreateService();
    }
}
