using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Follows.Infrastructure.Features.Common.Extensions;

namespace InstaConnect.Follows.Infrastructure.Tests.Unit.Features.Users.Utilities;

public abstract class BaseUserInfrastructureCommandUnitTest : BaseUserTest
{
	protected IApplicationSender Sender { get; }

	protected IApplicationMapper Mapper { get; }

	protected BaseUserInfrastructureCommandUnitTest()
	{
		Sender = MockFactory.CreateApplicationSender();
		Mapper = MockFactory.CreateMapper(FollowsInfrastructureReference.Assembly);
	}
}
