using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Domain.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.PostComments.Utilities;

public abstract class BasePostCommentDomainQueryUnitTest : BasePostCommentTest
{
	protected IPostQueryRepository Repository { get; }

	protected IUserQueryRepository UserRepository { get; }

	protected IPostCommentQueryRepository CommentRepository { get; }

	protected IPostCommentCollectionResponseFactory CollectionResponseFactory { get; }

	protected BasePostCommentDomainQueryUnitTest()
	{
		Repository = PostDomainMockFactory.CreateQueryRepository();
		UserRepository = UserDomainMockFactory.CreateQueryRepository();
		CommentRepository = PostCommentDomainMockFactory.CreateQueryRepository();
		CollectionResponseFactory = PostCommentDomainMockFactory.CreateCollectionResponseFactory();
	}
}
