using InstaConnect.Common.Tests.Utilities;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Abstractions;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities;

public static class PostLikeMockFactory
{
    public static IPostLikeService CreatePostLikeService()
    {
        return Mocker.Mock<IPostLikeService>();
    }
}
