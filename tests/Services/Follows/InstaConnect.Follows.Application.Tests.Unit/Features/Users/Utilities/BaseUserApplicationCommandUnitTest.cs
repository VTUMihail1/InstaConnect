using InstaConnect.Follows.Application.Extensions;

namespace InstaConnect.Follows.Application.Tests.Unit.Features.Users.Utilities;

public abstract class BaseUserApplicationCommandUnitTest : BaseUserTest
{
    protected IApplicationMapper Mapper { get; }

    protected IUserCommandService UserService { get; }

    protected BaseUserApplicationCommandUnitTest()
    {
        Mapper = MockFactory.CreateMapper(FollowApplicationReference.Assembly);
        UserService = UserMockFactory.CreateCommandService();
    }
}
