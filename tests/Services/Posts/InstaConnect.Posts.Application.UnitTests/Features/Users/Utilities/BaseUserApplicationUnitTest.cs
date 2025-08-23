using InstaConnect.Common.Abstractions;
using InstaConnect.Posts.Application.Extensions;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Users.Common.Tests.Features.Users.Utilities;

namespace InstaConnect.Users.Application.UnitTests.Features.Users.Utilities;

public abstract class BaseUserApplicationUnitTest : BaseUserTest
{
    protected IApplicationMapper ApplicationMapper { get; }

    protected IUserService UserService { get; }

    protected BaseUserApplicationUnitTest()
    {
        ApplicationMapper = MockFactory.CreateApplicationMapper(PostApplicationReference.Assembly);
        UserService = UserMockFactory.CreateService();
    }
}
