using InstaConnect.Common.Abstractions;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Application.Extensions;

namespace InstaConnect.PostCommentLikes.Application.UnitTests.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikeApplicationUnitTest : BasePostCommentLikeTest
{
    protected IApplicationMapper ApplicationMapper { get; }

    protected IPostCommentLikeService PostCommentLikeService { get; }

    protected BasePostCommentLikeApplicationUnitTest()
    {
        ApplicationMapper = MockFactory.CreateApplicationMapper(PostApplicationReference.Assembly);
        PostCommentLikeService = PostCommentLikeMockFactory.CreateService();
    }
}
