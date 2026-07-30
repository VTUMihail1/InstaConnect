using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Domain.Features.Guids.Abstractions;

namespace InstaConnect.Posts.Domain.Tests.Features.PostComments.Utilities;

public static class PostCommentMockSetups
{
	extension(IGuidProvider guidProvider)
	{
		public void SetupNewStringGuid(PostComment postComment)
		{
			guidProvider.ClearCalls().NewStringGuid()
				.ReturnsResponse(postComment.Id.CommentId);
		}
	}

	extension(IDateTimeProvider dateTimeProvider)
	{
		public void SetupGetOffsetUtcNow(PostComment postComment)
		{
			dateTimeProvider.ClearCalls().GetOffsetUtcNow()
				.ReturnsResponse(postComment.CreatedAtUtc);
		}
	}

	extension(IPostCommentFactory factory)
	{
		public void SetupCreate(
			AddPostCommentCommand command,
			PostComment postComment)
		{
			factory
				.ClearCalls()
				.Create(
					command.Id,
					command.UserId,
					command.Content)
				.ReturnsResponse(postComment.To(command));
		}
	}

	extension(IPostCommandRepository repository)
	{
		public void SetupGetByIdAsync(
			AddPostCommentCommand command,
			PostInclude include,
			Post post,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.Id, PostCommentDomainMatcher.IsPostInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(post);
		}

		public void RemoveGetByIdAsync(
			AddPostCommentCommand command,
			PostInclude include,
			Post post,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.Id, PostCommentDomainMatcher.IsPostInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void SetupExistsByIdAsync(
			UpdatePostCommentCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.ExistsByIdAsync(command.Id.Id, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void SetupExistsByIdAsync(
			DeletePostCommentCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.ExistsByIdAsync(command.Id.Id, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void RemoveExistsByIdAsync(
			UpdatePostCommentCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.ExistsByIdAsync(command.Id.Id, cancellationToken)
				.ReturnsTaskResponse(false);
		}

		public void RemoveExistsByIdAsync(
			DeletePostCommentCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.ExistsByIdAsync(command.Id.Id, cancellationToken)
				.ReturnsTaskResponse(false);
		}
	}

	extension(IPostCommentCommandRepository repository)
	{
		public void SetupGetByIdAsync(
			UpdatePostCommentCommand command,
			PostCommentInclude include,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.Id, PostCommentDomainMatcher.IsPostCommentInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(postComment);
		}

		public void SetupGetByIdAsync(
			DeletePostCommentCommand command,
			PostCommentInclude include,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.Id, PostCommentDomainMatcher.IsPostCommentInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(postComment);
		}

		public void RemoveGetByIdAsync(
			UpdatePostCommentCommand command,
			PostCommentInclude include,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.Id, PostCommentDomainMatcher.IsPostCommentInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void RemoveGetByIdAsync(
			DeletePostCommentCommand command,
			PostCommentInclude include,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.Id, PostCommentDomainMatcher.IsPostCommentInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public void SetupGetByIdAsync(
			AddPostCommentCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.UserId, cancellationToken)
				.ReturnsTaskResponse(user);
		}

		public void RemoveGetByIdAsync(
			AddPostCommentCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.UserId, cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}

	extension(IPostQueryRepository repository)
	{
		public void SetupGetByIdAsync(
			GetAllPostCommentsQuery query,
			Post post,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(query.Filter.Id, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(post.ToResponse(query));
		}

		public void RemoveGetByIdAsync(
			GetAllPostCommentsQuery query,
			Post post,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(query.Filter.Id, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void SetupExistsByIdAsync(
			GetPostCommentByIdQuery query,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.ExistsByIdAsync(query.Id.Id, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void RemoveExistsByIdAsync(
			GetPostCommentByIdQuery query,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.ExistsByIdAsync(query.Id.Id, cancellationToken)
				.ReturnsTaskResponse(false);
		}
	}

	extension(IUserQueryRepository repository)
	{
		public void SetupGetByIdAsync(
			GetAllPostCommentsForUserQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(query.Filter.UserId, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(query));
		}

		public void RemoveGetByIdAsync(
			GetAllPostCommentsForUserQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(query.Filter.UserId, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}

	extension(IPostCommentQueryRepository repository)
	{
		public void SetupGetAllAsync(
			GetAllPostCommentsQuery query,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetAllAsync(query.Filter, query.CurrentUser, query.Sorting, query.Pagination, cancellationToken)
				.ReturnsTaskResponse(postComments.ToResponse(query));
		}

		public void SetupGetTotalCountAsync(
			GetAllPostCommentsQuery query,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetTotalCountAsync(query.Filter, cancellationToken)
				.ReturnsTaskResponse(postComments.ToTotalCountResponse(query));
		}

		public void SetupGetAllForUserAsync(
			GetAllPostCommentsForUserQuery query,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetAllForUserAsync(query.Filter, query.CurrentUser, query.Sorting, query.Pagination, cancellationToken)
				.ReturnsTaskResponse(postComments.ToResponse(query));
		}

		public void SetupGetTotalCountForUserAsync(
			GetAllPostCommentsForUserQuery query,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetTotalCountForUserAsync(query.Filter, cancellationToken)
				.ReturnsTaskResponse(postComments.ToTotalCountResponse(query));
		}

		public void SetupGetByIdAsync(
			GetPostCommentByIdQuery query,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(query.Id, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(postComment.ToResponse(query));
		}

		public void RemoveGetByIdAsync(
			GetPostCommentByIdQuery query,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
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
			dateTimeProvider.ClearCalls().GetOffsetUtcNow().ReturnsResponse(postComment.UpdatedAtUtc);
		}
	}
}
