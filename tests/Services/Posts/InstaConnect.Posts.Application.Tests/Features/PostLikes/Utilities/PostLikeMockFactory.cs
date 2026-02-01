namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;

public static class PostLikeMockFactory
{
    public static IPostLikeCommandService CreateCommandService()
    {
        return Mocker.Mock<IPostLikeCommandService>();
    }

    public static IPostLikeQueryService CreateQueryService()
    {
        return Mocker.Mock<IPostLikeQueryService>();
    }
}
