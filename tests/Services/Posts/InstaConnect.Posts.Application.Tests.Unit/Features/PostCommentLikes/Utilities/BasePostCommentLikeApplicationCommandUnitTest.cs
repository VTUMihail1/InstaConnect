using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Posts.Application.Features.Common.Extensions;

namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikeApplicationCommandUnitTest : BasePostCommentLikeTest
{
	protected IApplicationMapper Mapper { get; }

	protected IPostCommentLikeCommandService CommentLikeService { get; }

	protected BasePostCommentLikeApplicationCommandUnitTest()
	{
		Mapper = MockFactory.CreateMapper(PostsApplicationReference.Assembly);
		CommentLikeService = PostCommentLikeMockFactory.CreateCommandService();
	}
}
