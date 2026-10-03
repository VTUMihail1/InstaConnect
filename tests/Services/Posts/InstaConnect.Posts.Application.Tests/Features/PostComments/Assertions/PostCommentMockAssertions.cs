using InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Assertions;

public static class PostCommentMockAssertions
{
	extension(IPostCommentQueryService postCommentService)
	{
		public async Task ShouldReceiveOneGetAllAsync(GetAllPostCommentsQueryRequest request, CancellationToken cancellationToken)
		{
			await postCommentService.ShouldHaveReceivedOne()
				.GetAllAsync(request.IsGetAllPostCommentsQuery(), cancellationToken);
		}

		public async Task ShouldReceiveOneGetAllForUserAsync(GetAllPostCommentsForUserQueryRequest request, CancellationToken cancellationToken)
		{
			await postCommentService.ShouldHaveReceivedOne()
				.GetAllForUserAsync(request.IsGetAllPostCommentsForUserQuery(), cancellationToken);
		}

		public async Task ShouldReceiveOneGetByIdAsync(GetPostCommentByIdQueryRequest request, CancellationToken cancellationToken)
		{
			await postCommentService.ShouldHaveReceivedOne()
				.GetByIdAsync(request.IsGetPostCommentByIdQuery(), cancellationToken);
		}
	}

	extension(IPostCommentCommandService postCommentService)
	{
		public async Task ShouldReceiveOneAddAsync(AddPostCommentCommandRequest request, CancellationToken cancellationToken)
		{
			await postCommentService.ShouldHaveReceivedOne()
				.AddAsync(request.IsAddPostCommentCommand(), cancellationToken);
		}

		public async Task ShouldReceiveOneUpdateAsync(UpdatePostCommentCommandRequest request, CancellationToken cancellationToken)
		{
			await postCommentService.ShouldHaveReceivedOne()
				.UpdateAsync(request.IsUpdatePostCommentCommand(), cancellationToken);
		}

		public async Task ShouldReceiveOneDeleteAsync(DeletePostCommentCommandRequest request, CancellationToken cancellationToken)
		{
			await postCommentService.ShouldHaveReceivedOne()
				.DeleteAsync(request.IsDeletePostCommentCommand(), cancellationToken);
		}
	}
}
