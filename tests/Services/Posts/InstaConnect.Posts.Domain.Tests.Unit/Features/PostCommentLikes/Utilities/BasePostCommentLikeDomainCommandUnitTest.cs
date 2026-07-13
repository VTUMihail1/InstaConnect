using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Common.Domain.Tests.Features.Utilities;
using InstaConnect.Common.Events.Features.Common.Abstractions;
using InstaConnect.Posts.Domain.Features.Common.Extensions;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Domain.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikeDomainCommandUnitTest : BasePostCommentLikeTest
{
	protected IApplicationMapper Mapper { get; }

	protected IEventPublisher EventPublisher { get; }

	protected IPostCommentLikeFactory Factory { get; }

	protected IPostCommandRepository Repository { get; }

	protected IDateTimeProvider DateTimeProvider { get; }

	protected IUserCommandRepository UserRepository { get; }

	protected IPostCommentCommandRepository CommentRepository { get; }

	protected IPostIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected IPostCommentLikeCommandRepository CommentLikeRepository { get; }

	protected IPostCommentIncludeBuilderFactory CommentIncludeBuilderFactory { get; }

	protected IPostCommentLikeIncludeBuilderFactory CommentLikeIncludeBuilderFactory { get; }

	protected BasePostCommentLikeDomainCommandUnitTest()
	{
		Mapper = MockFactory.CreateMapper(PostsDomainReference.Assembly);
		EventPublisher = DomainMockFactory.CreateEventPublisher();
		Factory = PostCommentLikeDomainMockFactory.CreateFactory();
		Repository = PostDomainMockFactory.CreateCommandRepository();
		DateTimeProvider = DomainMockFactory.CreateDateTimeProvider();
		UserRepository = UserDomainMockFactory.CreateCommandRepository();
		CommentRepository = PostCommentDomainMockFactory.CreateCommandRepository();
		IncludeBuilderFactory = PostDomainMockFactory.CreateIncludeBuilderFactory();
		CommentLikeRepository = PostCommentLikeDomainMockFactory.CreateCommandRepository();
		CommentIncludeBuilderFactory = PostCommentDomainMockFactory.CreateIncludeBuilderFactory();
		CommentLikeIncludeBuilderFactory = PostCommentLikeDomainMockFactory.CreateIncludeBuilderFactory();
	}
}
