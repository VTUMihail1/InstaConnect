using InstaConnect.Chats.Application.Extensions;

namespace InstaConnect.Chats.Application.Tests.Unit.Features.Users.Utilities;

public abstract class BaseUserApplicationCommandUnitTest : BaseUserTest
{
    protected IApplicationMapper Mapper { get; }

    protected IUserCommandService UserService { get; }

    protected BaseUserApplicationCommandUnitTest()
    {
        Mapper = MockFactory.CreateMapper(ChatApplicationReference.Assembly);
        UserService = UserMockFactory.CreateCommandService();
    }
}
