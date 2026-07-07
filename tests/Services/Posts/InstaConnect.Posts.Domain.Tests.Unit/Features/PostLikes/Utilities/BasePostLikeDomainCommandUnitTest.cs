using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Common.Domain.Tests.Features.Utilities;
using InstaConnect.Common.Events.Features.Common.Abstractions;
using InstaConnect.Posts.Domain.Features.Common.Extensions;
using InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Domain.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Domain.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.PostLikes.Utilities;

public abstract class BasePostLikeDomainCommandUnitTest : BasePostLikeTest
{
	protected IPostLikeFactory Factory { get; }

	protected IApplicationMapper Mapper { get; }

	protected IEventPublisher EventPublisher { get; }

	protected IPostCommandRepository Repository { get; }

	protected IUserCommandRepository UserRepository { get; }

	protected IPostLikeCommandRepository LikeRepository { get; }

	protected IPostIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected IPostLikeIncludeBuilderFactory LikeIncludeBuilderFactory { get; }

	protected BasePostLikeDomainCommandUnitTest()
	{
		Mapper = MockFactory.CreateMapper(PostsDomainReference.Assembly);
		Factory = PostLikeDomainMockFactory.CreateFactory();
		EventPublisher = DomainMockFactory.CreateEventPublisher();
		Repository = PostDomainMockFactory.CreateCommandRepository();
		UserRepository = UserDomainMockFactory.CreateCommandRepository();
		LikeRepository = PostLikeDomainMockFactory.CreateCommandRepository();
		IncludeBuilderFactory = PostDomainMockFactory.CreateIncludeBuilderFactory();
		LikeIncludeBuilderFactory = PostLikeDomainMockFactory.CreateIncludeBuilderFactory();
	}
}
