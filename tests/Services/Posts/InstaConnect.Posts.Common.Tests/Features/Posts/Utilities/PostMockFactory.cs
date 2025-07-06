using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;

public static class PostMockFactory
{
    public static IPostService CreatePostService()
    {
        return Mocker.Mock<IPostService>();
    }
}
