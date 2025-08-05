using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;

public static class PostMockFactory
{
    public static IPostService CreateService()
    {
        return Mocker.Mock<IPostService>();
    }
}
