using InstaConnect.Posts.Application.Features.Common.Extensions;

namespace InstaConnect.Posts.Application.Tests.Unit.Features.Users.Utilities;

public abstract class BaseUserApplicationCommandUnitTest : BaseUserTest
{
    protected IApplicationMapper Mapper { get; }

    protected IUserCommandService UserService { get; }

    protected BaseUserApplicationCommandUnitTest()
    {
        Mapper = MockFactory.CreateMapper(PostsApplicationReference.Assembly);
        UserService = UserMockFactory.CreateCommandService();
    }
}
