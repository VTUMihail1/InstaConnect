using InstaConnect.Common.Tests.Utilities;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Abstractions;

namespace InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeMockFactory
{
    public static IPostCommentLikeService CreateService()
    {
        return Mocker.Mock<IPostCommentLikeService>();
    }
}
