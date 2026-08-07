using InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Domain.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Domain.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.PostLikes.Utilities;

public abstract class BasePostLikeDomainQueryUnitTest : BasePostLikeTest
{
	protected IPostQueryRepository Repository { get; }

	protected IUserQueryRepository UserRepository { get; }

	protected IPostLikeQueryRepository LikeRepository { get; }

	internal IPostLikeCollectionResponseFactory CollectionResponseFactory { get; }

	protected BasePostLikeDomainQueryUnitTest()
	{
		Repository = PostDomainMockFactory.CreateQueryRepository();
		UserRepository = UserDomainMockFactory.CreateQueryRepository();
		LikeRepository = PostLikeDomainMockFactory.CreateQueryRepository();
		CollectionResponseFactory = PostLikeDomainMockFactory.CreateCollectionResponseFactory();
	}
}
