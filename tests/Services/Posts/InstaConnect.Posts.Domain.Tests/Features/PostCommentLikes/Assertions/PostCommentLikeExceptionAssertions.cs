using InstaConnect.Posts.Tests.Features.PostCommentLikes.Assertions;
using InstaConnect.Posts.Tests.Features.PostComments.Assertions;
using InstaConnect.Posts.Tests.Features.Posts.Assertions;
using InstaConnect.Posts.Tests.Features.Users.Assertions;

namespace InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeExceptionAssertions
{
	extension(IPostCommentLikeCommandService service)
	{
		public async Task ShouldThrowUserNotFoundExceptionAsync(
			AddPostCommentLikeCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.AddAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				r => r.UserId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			AddPostCommentLikeCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.AddAsync(request, cancellationToken);

			await func.ShouldThrowPostNotFoundExceptionAsync(
				r => r.CommentId.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			DeletePostCommentLikeCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.DeleteAsync(request, cancellationToken);

			await func.ShouldThrowPostNotFoundExceptionAsync(
				r => r.Id.CommentId.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentNotFoundExceptionAsync(
			AddPostCommentLikeCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.AddAsync(request, cancellationToken);

			await func.ShouldThrowPostCommentNotFoundExceptionAsync(
				r => r.CommentId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentNotFoundExceptionAsync(
			DeletePostCommentLikeCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.DeleteAsync(request, cancellationToken);

			await func.ShouldThrowPostCommentNotFoundExceptionAsync(
				r => r.Id.CommentId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentLikeAlreadyExistsExceptionAsync(
			AddPostCommentLikeCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.AddAsync(request, cancellationToken);

			await func.ShouldThrowPostCommentLikeAlreadyExistsExceptionAsync(
				r => r.CommentId.Id.Id,
				r => r.CommentId.CommentId,
				r => r.UserId.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentLikeNotFoundExceptionAsync(
			DeletePostCommentLikeCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.DeleteAsync(request, cancellationToken);

			await func.ShouldThrowPostCommentLikeNotFoundExceptionAsync(
				r => r.Id,
				request,
				cancellationToken);
		}
	}

	extension(IPostCommentLikeQueryService service)
	{
		public async Task ShouldThrowPostNotFoundExceptionAsync(
			GetAllPostCommentLikesQuery request,
			CancellationToken cancellationToken)
		{
			var func = () => service.GetAllAsync(request, cancellationToken);

			await func.ShouldThrowPostNotFoundExceptionAsync(
				r => r.Filter.CommentId.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			GetPostCommentLikeByIdQuery request,
			CancellationToken cancellationToken)
		{
			var func = () => service.GetByIdAsync(request, cancellationToken);

			await func.ShouldThrowPostNotFoundExceptionAsync(
				r => r.Id.CommentId.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentNotFoundExceptionAsync(
			GetAllPostCommentLikesQuery request,
			CancellationToken cancellationToken)
		{
			var func = () => service.GetAllAsync(request, cancellationToken);

			await func.ShouldThrowPostCommentNotFoundExceptionAsync(
				r => r.Filter.CommentId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentNotFoundExceptionAsync(
			GetPostCommentLikeByIdQuery request,
			CancellationToken cancellationToken)
		{
			var func = () => service.GetByIdAsync(request, cancellationToken);

			await func.ShouldThrowPostCommentNotFoundExceptionAsync(
				r => r.Id.CommentId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			GetAllPostCommentLikesForUserQuery request,
			CancellationToken cancellationToken)
		{
			var func = () => service.GetAllForUserAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				r => r.Filter.UserId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentLikeNotFoundExceptionAsync(
			GetPostCommentLikeByIdQuery request,
			CancellationToken cancellationToken)
		{
			var func = () => service.GetByIdAsync(request, cancellationToken);

			await func.ShouldThrowPostCommentLikeNotFoundExceptionAsync(
				r => r.Id,
				request,
				cancellationToken);
		}
	}
}
