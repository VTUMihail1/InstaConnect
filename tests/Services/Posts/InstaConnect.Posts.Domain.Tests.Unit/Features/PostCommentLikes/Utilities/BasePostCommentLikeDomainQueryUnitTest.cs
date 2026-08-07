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

public abstract class BasePostCommentLikeDomainQueryUnitTest : BasePostCommentLikeTest
{
	protected IPostQueryRepository Repository { get; }

	protected IUserQueryRepository UserRepository { get; }

	protected IPostCommentQueryRepository CommentRepository { get; }

	protected IPostCommentLikeQueryRepository CommentLikeRepository { get; }

	internal IPostCommentLikeCollectionResponseFactory CollectionResponseFactory { get; }

	protected BasePostCommentLikeDomainQueryUnitTest()
	{
		Repository = PostDomainMockFactory.CreateQueryRepository();
		UserRepository = UserDomainMockFactory.CreateQueryRepository();
		CommentRepository = PostCommentDomainMockFactory.CreateQueryRepository();
		CommentLikeRepository = PostCommentLikeDomainMockFactory.CreateQueryRepository();
		CollectionResponseFactory = PostCommentLikeDomainMockFactory.CreateCollectionResponseFactory();
	}
}
