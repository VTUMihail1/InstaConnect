using InstaConnect.Posts.Application.Extensions;

namespace InstaConnect.Posts.Application.Tests.Unit.Features.Users.Utilities;

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
