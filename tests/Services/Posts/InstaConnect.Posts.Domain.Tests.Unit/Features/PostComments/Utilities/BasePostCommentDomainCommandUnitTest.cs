using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Common.Domain.Tests.Features.Utilities;
using InstaConnect.Common.Events.Features.Common.Abstractions;
using InstaConnect.Posts.Domain.Features.Common.Extensions;
using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Domain.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.PostComments.Utilities;

public abstract class BasePostCommentDomainCommandUnitTest : BasePostCommentTest
{
	protected IApplicationMapper Mapper { get; }

	protected IPostCommentFactory Factory { get; }

	protected IEventPublisher EventPublisher { get; }

	protected IPostCommandRepository Repository { get; }

	protected IDateTimeProvider DateTimeProvider { get; }

	protected IUserCommandRepository UserRepository { get; }

	protected IPostCommentCommandRepository CommentRepository { get; }

	protected IPostIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected IPostCommentIncludeBuilderFactory CommentIncludeBuilderFactory { get; }

	protected BasePostCommentDomainCommandUnitTest()
	{
		Mapper = MockFactory.CreateMapper(PostsDomainReference.Assembly);
		Factory = PostCommentDomainMockFactory.CreateFactory();
		EventPublisher = DomainMockFactory.CreateEventPublisher();
		Repository = PostDomainMockFactory.CreateCommandRepository();
		DateTimeProvider = DomainMockFactory.CreateDateTimeProvider();
		UserRepository = UserDomainMockFactory.CreateCommandRepository();
		CommentRepository = PostCommentDomainMockFactory.CreateCommandRepository();
		IncludeBuilderFactory = PostDomainMockFactory.CreateIncludeBuilderFactory();
		CommentIncludeBuilderFactory = PostCommentDomainMockFactory.CreateIncludeBuilderFactory();
	}
}
