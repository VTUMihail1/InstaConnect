using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;

namespace InstaConnect.Posts.Domain.Tests.Features.PostLikes.Utilities;

public static class PostLikeMockSetups
{
	extension(IDateTimeProvider dateTimeProvider)
	{
		public void SetupGetOffsetUtcNow(PostLike postLike)
		{
			dateTimeProvider
				.GetOffsetUtcNow()
				.ReturnsResponse(postLike.CreatedAtUtc);
		}
	}

	extension(IPostLikeFactory factory)
	{
		public void SetupCreate(
			AddPostLikeCommand command,
			PostLike postLike)
		{
			factory
				.Create(
					command.Id,
					command.UserId)
				.ReturnsResponse(postLike.To(command));
		}
	}

	extension(IPostLikeCommandRepository repository)
	{
		public void SetupGetByIdAsync(
			DeletePostLikeCommand command,
			PostLikeInclude include,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, command.IsPostLikeInclude(include), cancellationToken)
				.ReturnsTaskResponse(postLike);
		}

		public void SetupGetByIdAsync(
			AddPostLikeCommand command,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(postLike.Id, cancellationToken)
				.ReturnsTaskResponse(postLike);
		}

		public void RemoveGetByIdAsync(
			AddPostLikeCommand command,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(postLike.Id, cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void RemoveGetByIdAsync(
			DeletePostLikeCommand command,
			PostLikeInclude include,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, command.IsPostLikeInclude(include), cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}

	extension(IPostCommandRepository repository)
	{
		public void SetupGetByIdAsync(
			AddPostLikeCommand command,
			PostInclude include,
			Post post,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, command.IsPostInclude(include), cancellationToken)
				.ReturnsTaskResponse(post);
		}

		public void RemoveGetByIdAsync(
			AddPostLikeCommand command,
			PostInclude include,
			Post post,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, command.IsPostInclude(include), cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void SetupExistsByIdAsync(
			DeletePostLikeCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ExistsByIdAsync(command.Id.Id, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void RemoveExistsByIdAsync(
			DeletePostLikeCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ExistsByIdAsync(command.Id.Id, cancellationToken)
				.ReturnsTaskResponse(false);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public void SetupGetByIdAsync(
			AddPostLikeCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.UserId, cancellationToken)
				.ReturnsTaskResponse(user);
		}

		public void RemoveGetByIdAsync(
			AddPostLikeCommand command,
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
		public void SetupGetByIdAsync(
			GetAllPostLikesQuery query,
			Post post,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(query.Filter.Id, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(post.ToResponse(query));
		}

		public void RemoveGetByIdAsync(
			GetAllPostLikesQuery query,
			Post post,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(query.Filter.Id, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void SetupExistsByIdAsync(
			GetPostLikeByIdQuery query,
			CancellationToken cancellationToken)
		{
			repository
				.ExistsByIdAsync(query.Id.Id, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void RemoveExistsByIdAsync(
			GetPostLikeByIdQuery query,
			CancellationToken cancellationToken)
		{
			repository
				.ExistsByIdAsync(query.Id.Id, cancellationToken)
				.ReturnsTaskResponse(false);
		}
	}

	extension(IUserQueryRepository repository)
	{
		public void SetupGetByIdAsync(
			GetAllPostLikesForUserQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(query.Filter.UserId, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(query));
		}

		public void RemoveGetByIdAsync(
			GetAllPostLikesForUserQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(query.Filter.UserId, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}

	extension(IPostLikeQueryRepository repository)
	{
		public void SetupGetAllAsync(
			GetAllPostLikesQuery query,
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			repository
				.GetAllAsync(query.Filter, query.CurrentUser, query.Sorting, query.Pagination, cancellationToken)
				.ReturnsTaskResponse(postLikes.ToResponse(query));
		}

		public void SetupGetTotalCountAsync(
			GetAllPostLikesQuery query,
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			repository
				.GetTotalCountAsync(query.Filter, cancellationToken)
				.ReturnsTaskResponse(postLikes.ToTotalCountResponse(query));
		}

		public void SetupGetAllForUserAsync(
			GetAllPostLikesForUserQuery query,
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			repository
				.GetAllForUserAsync(query.Filter, query.CurrentUser, query.Sorting, query.Pagination, cancellationToken)
				.ReturnsTaskResponse(postLikes.ToResponse(query));
		}

		public void SetupGetTotalCountForUserAsync(
			GetAllPostLikesForUserQuery query,
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			repository
				.GetTotalCountForUserAsync(query.Filter, cancellationToken)
				.ReturnsTaskResponse(postLikes.ToTotalCountResponse(query));
		}

		public void SetupGetByIdAsync(
			GetPostLikeByIdQuery query,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(query.Id, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(postLike.ToResponse(query));
		}

		public void RemoveGetByIdAsync(
			GetPostLikeByIdQuery query,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(query.Id, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}
}
