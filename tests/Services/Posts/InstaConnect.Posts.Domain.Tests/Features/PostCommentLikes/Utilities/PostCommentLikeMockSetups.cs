using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;

namespace InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeMockSetups
{
	extension(IDateTimeProvider dateTimeProvider)
	{
		public void SetupGetOffsetUtcNow(PostCommentLike postCommentLike)
		{
			dateTimeProvider
				.ClearCalls()
				.GetOffsetUtcNow()
				.ReturnsResponse(postCommentLike.CreatedAtUtc);
		}
	}

	extension(IPostCommentLikeFactory factory)
	{
		public void SetupCreate(
			AddPostCommentLikeCommand command,
			PostCommentLike postCommentLike)
		{
			factory
				.ClearCalls()
				.Create(
					command.CommentId,
					command.UserId)
				.ReturnsResponse(postCommentLike.To(command));
		}
	}

	extension(IPostCommentLikeCommandRepository repository)
	{
		public void SetupGetByIdAsync(
			DeletePostCommentLikeCommand command,
			PostCommentLikeInclude include,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.Id, PostCommentLikeDomainMatcher.IsPostCommentLikeInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(postCommentLike);
		}

		public void SetupGetByIdAsync(
			AddPostCommentLikeCommand command,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(postCommentLike.Id, cancellationToken)
				.ReturnsTaskResponse(postCommentLike);
		}

		public void RemoveGetByIdAsync(
			AddPostCommentLikeCommand command,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(postCommentLike.Id, cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void RemoveGetByIdAsync(
			DeletePostCommentLikeCommand command,
			PostCommentLikeInclude include,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.Id, PostCommentLikeDomainMatcher.IsPostCommentLikeInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}

	extension(IPostCommandRepository repository)
	{
		public void SetupExistsByIdAsync(
			AddPostCommentLikeCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.ExistsByIdAsync(command.CommentId.Id, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void SetupExistsByIdAsync(
			DeletePostCommentLikeCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.ExistsByIdAsync(command.Id.CommentId.Id, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void RemoveExistsByIdAsync(
			AddPostCommentLikeCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.ExistsByIdAsync(command.CommentId.Id, cancellationToken)
				.ReturnsTaskResponse(false);
		}

		public void RemoveExistsByIdAsync(
			DeletePostCommentLikeCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.ExistsByIdAsync(command.Id.CommentId.Id, cancellationToken)
				.ReturnsTaskResponse(false);
		}
	}

	extension(IPostCommentCommandRepository repository)
	{
		public void SetupGetByIdAsync(
			AddPostCommentLikeCommand command,
			PostCommentInclude include,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.CommentId, PostCommentLikeDomainMatcher.IsPostCommentInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(postComment);
		}

		public void RemoveGetByIdAsync(
			AddPostCommentLikeCommand command,
			PostCommentInclude include,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.CommentId, PostCommentLikeDomainMatcher.IsPostCommentInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void SetupExistsByIdAsync(
			DeletePostCommentLikeCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.ExistsByIdAsync(command.Id.CommentId, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void RemoveExistsByIdAsync(
			DeletePostCommentLikeCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.ExistsByIdAsync(command.Id.CommentId, cancellationToken)
				.ReturnsTaskResponse(false);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public void SetupGetByIdAsync(
			AddPostCommentLikeCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.UserId, cancellationToken)
				.ReturnsTaskResponse(user);
		}

		public void RemoveGetByIdAsync(
			AddPostCommentLikeCommand command,
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
		public void SetupExistsByIdAsync(
			GetAllPostCommentLikesQuery query,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.ExistsByIdAsync(query.Filter.CommentId.Id, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void SetupExistsByIdAsync(
			GetPostCommentLikeByIdQuery query,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.ExistsByIdAsync(query.Id.CommentId.Id, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void RemoveExistsByIdAsync(
			GetAllPostCommentLikesQuery query,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.ExistsByIdAsync(query.Filter.CommentId.Id, cancellationToken)
				.ReturnsTaskResponse(false);
		}

		public void RemoveExistsByIdAsync(
			GetPostCommentLikeByIdQuery query,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.ExistsByIdAsync(query.Id.CommentId.Id, cancellationToken)
				.ReturnsTaskResponse(false);
		}
	}

	extension(IPostCommentQueryRepository repository)
	{
		public void SetupGetByIdAsync(
			GetAllPostCommentLikesQuery query,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(query.Filter.CommentId, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(postComment.ToResponse(query));
		}

		public void RemoveGetByIdAsync(
			GetAllPostCommentLikesQuery query,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(query.Filter.CommentId, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void SetupExistsByIdAsync(
			GetPostCommentLikeByIdQuery query,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.ExistsByIdAsync(query.Id.CommentId, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void RemoveExistsByIdAsync(
			GetPostCommentLikeByIdQuery query,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.ExistsByIdAsync(query.Id.CommentId, cancellationToken)
				.ReturnsTaskResponse(false);
		}
	}

	extension(IUserQueryRepository repository)
	{
		public void SetupGetByIdAsync(
			GetAllPostCommentLikesForUserQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(query.Filter.UserId, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(query));
		}

		public void RemoveGetByIdAsync(
			GetAllPostCommentLikesForUserQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(query.Filter.UserId, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}

	extension(IPostCommentLikeQueryRepository repository)
	{
		public void SetupGetAllAsync(
			GetAllPostCommentLikesQuery query,
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetAllAsync(query.Filter, query.CurrentUser, query.Sorting, query.Pagination, cancellationToken)
				.ReturnsTaskResponse(postCommentLikes.ToResponse(query));
		}

		public void SetupGetTotalCountAsync(
			GetAllPostCommentLikesQuery query,
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetTotalCountAsync(query.Filter, cancellationToken)
				.ReturnsTaskResponse(postCommentLikes.ToTotalCountResponse(query));
		}

		public void SetupGetAllForUserAsync(
			GetAllPostCommentLikesForUserQuery query,
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetAllForUserAsync(query.Filter, query.CurrentUser, query.Sorting, query.Pagination, cancellationToken)
				.ReturnsTaskResponse(postCommentLikes.ToResponse(query));
		}

		public void SetupGetTotalCountForUserAsync(
			GetAllPostCommentLikesForUserQuery query,
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetTotalCountForUserAsync(query.Filter, cancellationToken)
				.ReturnsTaskResponse(postCommentLikes.ToTotalCountResponse(query));
		}

		public void SetupGetByIdAsync(
			GetPostCommentLikeByIdQuery query,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(query.Id, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(postCommentLike.ToResponse(query));
		}

		public void RemoveGetByIdAsync(
			GetPostCommentLikeByIdQuery query,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(query.Id, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}
}
