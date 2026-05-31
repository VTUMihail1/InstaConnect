using InstaConnect.Chats.Infrastructure.Features.Common.Extensions;
using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Common.Domain.Features.Mappers.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.Users.Utilities;

public abstract class BaseUserInfrastructureCommandUnitTest : BaseUserTest
{
	protected IApplicationSender Sender { get; }

	protected IApplicationMapper Mapper { get; }

	protected BaseUserInfrastructureCommandUnitTest()
	{
		Sender = MockFactory.CreateApplicationSender();
		Mapper = MockFactory.CreateMapper(ChatsInfrastructureReference.Assembly);
	}
}
