using InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Assertions;

public static class PostCommentMockAssertions
{
	extension(IPostCommentQueryService postCommentService)
	{
		public async Task ShouldReceiveOneGetAllAsync(GetAllPostCommentsQueryRequest request, CancellationToken cancellationToken)
		{
			await postCommentService.ShouldHaveReceivedOne()
				.GetAllAsync(PostCommentMatcher.IsGetAllPostCommentsQuery(request), cancellationToken);
		}

		public async Task ShouldReceiveOneGetAllForUserAsync(GetAllPostCommentsForUserQueryRequest request, CancellationToken cancellationToken)
		{
			await postCommentService.ShouldHaveReceivedOne()
				.GetAllForUserAsync(PostCommentMatcher.IsGetAllPostCommentsForUserQuery(request), cancellationToken);
		}

		public async Task ShouldReceiveOneGetByIdAsync(GetPostCommentByIdQueryRequest request, CancellationToken cancellationToken)
		{
			await postCommentService.ShouldHaveReceivedOne()
				.GetByIdAsync(PostCommentMatcher.IsGetPostCommentByIdQuery(request), cancellationToken);
		}
	}

	extension(IPostCommentCommandService postCommentService)
	{
		public async Task ShouldReceiveOneAddAsync(AddPostCommentCommandRequest request, CancellationToken cancellationToken)
		{
			await postCommentService.ShouldHaveReceivedOne()
				.AddAsync(PostCommentMatcher.IsAddPostCommentCommand(request), cancellationToken);
		}

		public async Task ShouldReceiveOneUpdateAsync(UpdatePostCommentCommandRequest request, CancellationToken cancellationToken)
		{
			await postCommentService.ShouldHaveReceivedOne()
				.UpdateAsync(PostCommentMatcher.IsUpdatePostCommentCommand(request), cancellationToken);
		}

		public async Task ShouldReceiveOneDeleteAsync(DeletePostCommentCommandRequest request, CancellationToken cancellationToken)
		{
			await postCommentService.ShouldHaveReceivedOne()
				.DeleteAsync(PostCommentMatcher.IsDeletePostCommentCommand(request), cancellationToken);
		}
	}
}
