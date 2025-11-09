using InstaConnect.Posts.Domain.Features.Posts.Helpers;

namespace InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;

public static class PostMockFactory
{
    public static IPostService CreateService()
    {
        return Mocker.Mock<IPostService>();
    }

    public static IPostIncludeQueryBuilderFactory CreateIncludeQueryBuilderFactory()
    {
        return new PostIncludeQueryBuilderFactory();
    }
}
