using InstaConnect.Posts.Domain.Features.Users.Helpers;

namespace InstaConnect.Posts.Application.Tests.Features.Users.Utilities;

public static class UserMockFactory
{
    public static IUserService CreateService()
    {
        return Mocker.Mock<IUserService>();
    }

    public static IUserIncludeQueryBuilderFactory CreateIncludeQueryBuilderFactory()
    {
        return new UserIncludeQueryBuilderFactory();
    }
}
