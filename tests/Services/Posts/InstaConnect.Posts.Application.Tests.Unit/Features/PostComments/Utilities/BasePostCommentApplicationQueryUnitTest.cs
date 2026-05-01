using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Posts.Application.Features.Common.Extensions;

namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostComments.Utilities;

public abstract class BasePostCommentApplicationQueryUnitTest : BasePostCommentTest
{
	protected IApplicationMapper Mapper { get; }

	protected IPostCommentQueryService CommentService { get; }

	protected BasePostCommentApplicationQueryUnitTest()
	{
		Mapper = MockFactory.CreateMapper(PostsApplicationReference.Assembly);
		CommentService = PostCommentMockFactory.CreateQueryService();
	}
}
