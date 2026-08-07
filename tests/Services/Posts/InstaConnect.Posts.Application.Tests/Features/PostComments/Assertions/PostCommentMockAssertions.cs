using InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Assertions;

public static class PostCommentMockAssertions
{
	extension(IPostCommentQueryService postCommentService)
	{
		public async Task ShouldReceiveOneGetAllAsync(GetAllPostCommentsQueryRequest request, CancellationToken cancellationToken)
		{
			await postCommentService.ShouldHaveReceivedOne()
				.GetAllAsync(PostCommentApplicationMatcher.IsGetAllPostCommentsQuery(request), cancellationToken);
		}

		public async Task ShouldReceiveOneGetAllForUserAsync(GetAllPostCommentsForUserQueryRequest request, CancellationToken cancellationToken)
		{
			await postCommentService.ShouldHaveReceivedOne()
				.GetAllForUserAsync(PostCommentApplicationMatcher.IsGetAllPostCommentsForUserQuery(request), cancellationToken);
		}

		public async Task ShouldReceiveOneGetByIdAsync(GetPostCommentByIdQueryRequest request, CancellationToken cancellationToken)
		{
			await postCommentService.ShouldHaveReceivedOne()
				.GetByIdAsync(PostCommentApplicationMatcher.IsGetPostCommentByIdQuery(request), cancellationToken);
		}
	}

	extension(IPostCommentCommandService postCommentService)
	{
		public async Task ShouldReceiveOneAddAsync(AddPostCommentCommandRequest request, CancellationToken cancellationToken)
		{
			await postCommentService.ShouldHaveReceivedOne()
				.AddAsync(PostCommentApplicationMatcher.IsAddPostCommentCommand(request), cancellationToken);
		}

		public async Task ShouldReceiveOneUpdateAsync(UpdatePostCommentCommandRequest request, CancellationToken cancellationToken)
		{
			await postCommentService.ShouldHaveReceivedOne()
				.UpdateAsync(PostCommentApplicationMatcher.IsUpdatePostCommentCommand(request), cancellationToken);
		}

		public async Task ShouldReceiveOneDeleteAsync(DeletePostCommentCommandRequest request, CancellationToken cancellationToken)
		{
			await postCommentService.ShouldHaveReceivedOne()
				.DeleteAsync(PostCommentApplicationMatcher.IsDeletePostCommentCommand(request), cancellationToken);
		}
	}
}
