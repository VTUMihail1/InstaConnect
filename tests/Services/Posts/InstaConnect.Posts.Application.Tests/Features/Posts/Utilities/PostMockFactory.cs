namespace InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;

public static class PostMockFactory
{
    public static IPostCommandService CreateCommandService()
    {
        return Mocker.Mock<IPostCommandService>();
    }

    public static IPostQueryService CreateQueryService()
    {
        return Mocker.Mock<IPostQueryService>();
    }
}
