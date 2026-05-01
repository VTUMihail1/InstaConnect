using InstaConnect.Chats.Application.Features.Common.Extensions;
using InstaConnect.Common.Domain.Features.Mappers.Abstractions;

namespace InstaConnect.Chats.Application.Tests.Unit.Features.Users.Utilities;

public abstract class BaseUserApplicationCommandUnitTest : BaseUserTest
{
	protected IApplicationMapper Mapper { get; }

	protected IUserCommandService UserService { get; }

	protected BaseUserApplicationCommandUnitTest()
	{
		Mapper = MockFactory.CreateMapper(ChatsApplicationReference.Assembly);
		UserService = UserMockFactory.CreateCommandService();
	}
}
