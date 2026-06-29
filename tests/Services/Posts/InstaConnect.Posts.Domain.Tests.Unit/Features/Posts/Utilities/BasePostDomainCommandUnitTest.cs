using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Common.Domain.Tests.Features.Utilities;
using InstaConnect.Common.Events.Features.Common.Abstractions;
using InstaConnect.Posts.Domain.Features.Common.Extensions;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Domain.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.Posts.Utilities;

public abstract class BasePostDomainCommandUnitTest : BasePostTest
{
	protected IPostFactory Factory { get; }

	protected IApplicationMapper Mapper { get; }

	protected IEventPublisher EventPublisher { get; }

	protected IPostCommandRepository Repository { get; }

	protected IDateTimeProvider DateTimeProvider { get; }

	protected IUserCommandRepository UserRepository { get; }

	protected IPostIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BasePostDomainCommandUnitTest()
	{
		Factory = PostDomainMockFactory.CreateFactory();
		Mapper = MockFactory.CreateMapper(PostsDomainReference.Assembly);
		EventPublisher = DomainMockFactory.CreateEventPublisher();
		Repository = PostDomainMockFactory.CreateCommandRepository();
		DateTimeProvider = DomainMockFactory.CreateDateTimeProvider();
		UserRepository = UserDomainMockFactory.CreateCommandRepository();
		IncludeBuilderFactory = PostDomainMockFactory.CreateIncludeBuilderFactory();
	}
}
