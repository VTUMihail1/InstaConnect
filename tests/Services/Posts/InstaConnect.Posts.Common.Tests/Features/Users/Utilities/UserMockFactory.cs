using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;

namespace InstaConnect.Users.Common.Tests.Features.Users.Utilities;

public static class UserMockFactory
{
    public static IUserService CreateService()
    {
        return Mocker.Mock<IUserService>();
    }
}
