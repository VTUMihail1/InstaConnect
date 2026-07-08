using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Domain.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Features.PostComments.Utilities;

public static class PostCommentMockSetups
{
	extension(IPostCommentFactory factory)
	{
		public void SetupCreate(
			AddPostCommentCommand command,
			PostComment postComment)
		{
			factory
				.Create(
					command.Id,
					command.UserId,
					command.Content)
				.ReturnsResponse(postComment.ToFull(command));
		}
	}

	extension(IPostCommandRepository repository)
	{
		public void SetupGetById(
			AddPostCommentCommand command,
			PostInclude include,
			Post post,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, PostCommentMatcher.IsPostInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(post.ToFull());
		}

		public void RemoveGetById(
			AddPostCommentCommand command,
			PostInclude include,
			Post post,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, PostCommentMatcher.IsPostInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void SetupExistsById(
			UpdatePostCommentCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ExistsByIdAsync(command.Id.Id, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void SetupExistsById(
			DeletePostCommentCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ExistsByIdAsync(command.Id.Id, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void RemoveExistsById(
			UpdatePostCommentCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ExistsByIdAsync(command.Id.Id, cancellationToken)
				.ReturnsTaskResponse(false);
		}

		public void RemoveExistsById(
			DeletePostCommentCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ExistsByIdAsync(command.Id.Id, cancellationToken)
				.ReturnsTaskResponse(false);
		}
	}

	extension(IPostCommentCommandRepository repository)
	{
		public void SetupGetById(
			UpdatePostCommentCommand command,
			PostCommentInclude include,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, PostCommentMatcher.IsPostCommentInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(postComment.ToFull());
		}

		public void SetupGetById(
			DeletePostCommentCommand command,
			PostCommentInclude include,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, PostCommentMatcher.IsPostCommentInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(postComment.ToFull());
		}

		public void RemoveGetById(
			UpdatePostCommentCommand command,
			PostCommentInclude include,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, PostCommentMatcher.IsPostCommentInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void RemoveGetById(
			DeletePostCommentCommand command,
			PostCommentInclude include,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, PostCommentMatcher.IsPostCommentInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public void SetupGetById(
			AddPostCommentCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.UserId, cancellationToken)
				.ReturnsTaskResponse(user.ToFull());
		}

		public void RemoveGetById(
			AddPostCommentCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.UserId, cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}

	extension(IPostQueryRepository repository)
	{
		public void SetupGetById(
			GetAllPostCommentsQuery query,
			Post post,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(query.Filter.Id, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(post.ToFullResponse(query));
		}

		public void RemoveGetById(
			GetAllPostCommentsQuery query,
			Post post,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(query.Filter.Id, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void SetupExistsById(
			GetPostCommentByIdQuery query,
			CancellationToken cancellationToken)
		{
			repository
				.ExistsByIdAsync(query.Id.Id, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void RemoveExistsById(
			GetPostCommentByIdQuery query,
			CancellationToken cancellationToken)
		{
			repository
				.ExistsByIdAsync(query.Id.Id, cancellationToken)
				.ReturnsTaskResponse(false);
		}
	}

	extension(IUserQueryRepository repository)
	{
		public void SetupGetById(
			GetAllPostCommentsForUserQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(query.Filter.UserId, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(user.ToFullResponse());
		}

		public void RemoveGetById(
			GetAllPostCommentsForUserQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(query.Filter.UserId, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}

	extension(IPostCommentQueryRepository repository)
	{
		public void SetupGetAllQuery(
			GetAllPostCommentsQuery query,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			repository
				.GetAllAsync(query.Filter, query.CurrentUser, query.Sorting, query.Pagination, cancellationToken)
				.ReturnsTaskResponse(postComments.ToResponse(query));
		}

		public void SetupGetTotalCount(
			GetAllPostCommentsQuery query,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			repository
				.GetTotalCountAsync(query.Filter, cancellationToken)
				.ReturnsTaskResponse(postComments.ToTotalCountResponse(query));
		}

		public void SetupGetAllForUserQuery(
			GetAllPostCommentsForUserQuery query,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			repository
				.GetAllForUserAsync(query.Filter, query.CurrentUser, query.Sorting, query.Pagination, cancellationToken)
				.ReturnsTaskResponse(postComments.ToResponse(query));
		}

		public void SetupGetTotalCountForUser(
			GetAllPostCommentsForUserQuery query,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			repository
				.GetTotalCountForUserAsync(query.Filter, cancellationToken)
				.ReturnsTaskResponse(postComments.ToTotalCountResponse(query));
		}

		public void SetupGetById(
			GetPostCommentByIdQuery query,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(query.Id, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(postComment.ToFullResponse(query));
		}

		public void RemoveGetById(
			GetPostCommentByIdQuery query,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(query.Id, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}

	extension(IDateTimeProvider dateTimeProvider)
	{
		public void SetupGetOffsetUtcNow(
			UpdatePostCommentCommand command,
			PostComment postComment)
		{
			dateTimeProvider.GetOffsetUtcNow().ReturnsResponse(postComment.UpdatedAtUtc);
		}
	}
}
