using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.Common.Extensions;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.Users.Utilities;

public abstract class BaseUserInfrastructureCommandUnitTest : BaseUserTest
{
	protected IApplicationSender Sender { get; }

	protected IApplicationMapper Mapper { get; }

	protected BaseUserInfrastructureCommandUnitTest()
	{
		Sender = MockFactory.CreateApplicationSender();
		Mapper = MockFactory.CreateMapper(PostsInfrastructureReference.Assembly);
	}
}
