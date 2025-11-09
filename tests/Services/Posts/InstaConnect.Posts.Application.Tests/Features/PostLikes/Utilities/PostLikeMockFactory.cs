using InstaConnect.Posts.Domain.Features.PostLikes.Helpers;

namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;

public static class PostLikeMockFactory
{
    public static IPostLikeService CreateService()
    {
        return Mocker.Mock<IPostLikeService>();
    }

    public static IPostLikeIncludeQueryBuilderFactory CreateIncludeQueryBuilderFactory()
    {
        return new PostLikeIncludeQueryBuilderFactory();
    }
}
