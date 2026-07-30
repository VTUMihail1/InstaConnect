using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;

namespace InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeMockSetups
{
	extension(IDateTimeProvider dateTimeProvider)
	{
		public void SetupGetOffsetUtcNow(PostCommentLike postCommentLike)
		{
			dateTimeProvider.GetOffsetUtcNow()
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
				.Create(
					command.CommentId,
					command.UserId)
				.ReturnsResponse(postCommentLike.To(command));
		}
	}

	extension(IPostCommentLikeCommandRepository repository)
	{
		public void SetupGetById(
			AddPostCommentLikeCommand command,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(postCommentLike.Id, cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void SetupGetById(
			DeletePostCommentLikeCommand command,
			PostCommentLikeInclude include,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, PostCommentLikeDomainMatcher.IsPostCommentLikeInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(postCommentLike);
		}

		public void SetupGetByIdExists(
			AddPostCommentLikeCommand command,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(postCommentLike.Id, cancellationToken)
				.ReturnsTaskResponse(postCommentLike);
		}

		public void RemoveGetById(
			DeletePostCommentLikeCommand command,
			PostCommentLikeInclude include,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, PostCommentLikeDomainMatcher.IsPostCommentLikeInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}

	extension(IPostCommandRepository repository)
	{
		public void SetupExistsById(
			AddPostCommentLikeCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ExistsByIdAsync(command.CommentId.Id, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void SetupExistsById(
			DeletePostCommentLikeCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ExistsByIdAsync(command.Id.CommentId.Id, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void RemoveExistsById(
			AddPostCommentLikeCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ExistsByIdAsync(command.CommentId.Id, cancellationToken)
				.ReturnsTaskResponse(false);
		}

		public void RemoveExistsById(
			DeletePostCommentLikeCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ExistsByIdAsync(command.Id.CommentId.Id, cancellationToken)
				.ReturnsTaskResponse(false);
		}
	}

	extension(IPostCommentCommandRepository repository)
	{
		public void SetupGetById(
			AddPostCommentLikeCommand command,
			PostCommentInclude include,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.CommentId, PostCommentLikeDomainMatcher.IsPostCommentInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(postComment);
		}

		public void RemoveGetById(
			AddPostCommentLikeCommand command,
			PostCommentInclude include,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.CommentId, PostCommentLikeDomainMatcher.IsPostCommentInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void SetupExistsById(
			DeletePostCommentLikeCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ExistsByIdAsync(command.Id.CommentId, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void RemoveExistsById(
			DeletePostCommentLikeCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ExistsByIdAsync(command.Id.CommentId, cancellationToken)
				.ReturnsTaskResponse(false);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public void SetupGetById(
			AddPostCommentLikeCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.UserId, cancellationToken)
				.ReturnsTaskResponse(user);
		}

		public void RemoveGetById(
			AddPostCommentLikeCommand command,
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
		public void SetupExistsById(
			GetAllPostCommentLikesQuery query,
			CancellationToken cancellationToken)
		{
			repository
				.ExistsByIdAsync(query.Filter.CommentId.Id, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void SetupExistsById(
			GetPostCommentLikeByIdQuery query,
			CancellationToken cancellationToken)
		{
			repository
				.ExistsByIdAsync(query.Id.CommentId.Id, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void RemoveExistsById(
			GetAllPostCommentLikesQuery query,
			CancellationToken cancellationToken)
		{
			repository
				.ExistsByIdAsync(query.Filter.CommentId.Id, cancellationToken)
				.ReturnsTaskResponse(false);
		}

		public void RemoveExistsById(
			GetPostCommentLikeByIdQuery query,
			CancellationToken cancellationToken)
		{
			repository
				.ExistsByIdAsync(query.Id.CommentId.Id, cancellationToken)
				.ReturnsTaskResponse(false);
		}
	}

	extension(IPostCommentQueryRepository repository)
	{
		public void SetupGetById(
			GetAllPostCommentLikesQuery query,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(query.Filter.CommentId, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(postComment.ToResponse(query));
		}

		public void RemoveGetById(
			GetAllPostCommentLikesQuery query,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(query.Filter.CommentId, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void SetupExistsById(
			GetPostCommentLikeByIdQuery query,
			CancellationToken cancellationToken)
		{
			repository
				.ExistsByIdAsync(query.Id.CommentId, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void RemoveExistsById(
			GetPostCommentLikeByIdQuery query,
			CancellationToken cancellationToken)
		{
			repository
				.ExistsByIdAsync(query.Id.CommentId, cancellationToken)
				.ReturnsTaskResponse(false);
		}
	}

	extension(IUserQueryRepository repository)
	{
		public void SetupGetById(
			GetAllPostCommentLikesForUserQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(query.Filter.UserId, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(query));
		}

		public void RemoveGetById(
			GetAllPostCommentLikesForUserQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(query.Filter.UserId, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}

	extension(IPostCommentLikeQueryRepository repository)
	{
		public void SetupGetAllQuery(
			GetAllPostCommentLikesQuery query,
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			repository
				.GetAllAsync(query.Filter, query.CurrentUser, query.Sorting, query.Pagination, cancellationToken)
				.ReturnsTaskResponse(postCommentLikes.ToResponse(query));
		}

		public void SetupGetTotalCount(
			GetAllPostCommentLikesQuery query,
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			repository
				.GetTotalCountAsync(query.Filter, cancellationToken)
				.ReturnsTaskResponse(postCommentLikes.ToTotalCountResponse(query));
		}

		public void SetupGetAllForUserQuery(
			GetAllPostCommentLikesForUserQuery query,
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			repository
				.GetAllForUserAsync(query.Filter, query.CurrentUser, query.Sorting, query.Pagination, cancellationToken)
				.ReturnsTaskResponse(postCommentLikes.ToResponse(query));
		}

		public void SetupGetTotalCountForUser(
			GetAllPostCommentLikesForUserQuery query,
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			repository
				.GetTotalCountForUserAsync(query.Filter, cancellationToken)
				.ReturnsTaskResponse(postCommentLikes.ToTotalCountResponse(query));
		}

		public void SetupGetById(
			GetPostCommentLikeByIdQuery query,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(query.Id, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(postCommentLike.ToResponse(query));
		}

		public void RemoveGetById(
			GetPostCommentLikeByIdQuery query,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(query.Id, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}
}
