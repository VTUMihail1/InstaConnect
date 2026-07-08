using InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Domain.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Features.PostLikes.Utilities;

public static class PostLikeMockSetups
{
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
				.ReturnsResponse(postLike);
		}
	}

	extension(IPostLikeCommandRepository repository)
	{
		public void SetupGetById(
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(postLike.Id, cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void SetupGetById(
			DeletePostLikeCommand command,
			PostLikeInclude include,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, PostLikeMatcher.IsPostLikeInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(postLike.ToFull());
		}

		public void SetupGetByIdExists(
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(postLike.Id, cancellationToken)
				.ReturnsTaskResponse(postLike.ToFull());
		}

		public void RemoveGetById(
			DeletePostLikeCommand command,
			PostLikeInclude include,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, PostLikeMatcher.IsPostLikeInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}

	extension(IPostCommandRepository repository)
	{
		public void SetupGetById(
			AddPostLikeCommand command,
			PostInclude include,
			Post post,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, PostLikeMatcher.IsPostInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(post.ToFull());
		}

		public void RemoveGetById(
			AddPostLikeCommand command,
			PostInclude include,
			Post post,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, PostLikeMatcher.IsPostInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void SetupExistsById(
			DeletePostLikeCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ExistsByIdAsync(command.Id.Id, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void RemoveExistsById(
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
		public void SetupGetById(
			AddPostLikeCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.UserId, cancellationToken)
				.ReturnsTaskResponse(user.ToFull());
		}

		public void RemoveGetById(
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
		public void SetupGetById(
			GetAllPostLikesQuery query,
			Post post,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(query.Filter.Id, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(post.ToFullResponse(query));
		}

		public void RemoveGetById(
			GetAllPostLikesQuery query,
			Post post,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(query.Filter.Id, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void SetupExistsById(
			GetPostLikeByIdQuery query,
			CancellationToken cancellationToken)
		{
			repository
				.ExistsByIdAsync(query.Id.Id, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void RemoveExistsById(
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
		public void SetupGetById(
			GetAllPostLikesForUserQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(query.Filter.UserId, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(user.ToFullResponse());
		}

		public void RemoveGetById(
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
		public void SetupGetAllQuery(
			GetAllPostLikesQuery query,
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			repository
				.GetAllAsync(query.Filter, query.CurrentUser, query.Sorting, query.Pagination, cancellationToken)
				.ReturnsTaskResponse(postLikes.ToResponse(query));
		}

		public void SetupGetTotalCount(
			GetAllPostLikesQuery query,
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			repository
				.GetTotalCountAsync(query.Filter, cancellationToken)
				.ReturnsTaskResponse(postLikes.ToTotalCountResponse(query));
		}

		public void SetupGetAllForUserQuery(
			GetAllPostLikesForUserQuery query,
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			repository
				.GetAllForUserAsync(query.Filter, query.CurrentUser, query.Sorting, query.Pagination, cancellationToken)
				.ReturnsTaskResponse(postLikes.ToResponse(query));
		}

		public void SetupGetTotalCountForUser(
			GetAllPostLikesForUserQuery query,
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			repository
				.GetTotalCountForUserAsync(query.Filter, cancellationToken)
				.ReturnsTaskResponse(postLikes.ToTotalCountResponse(query));
		}

		public void SetupGetById(
			GetPostLikeByIdQuery query,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(query.Id, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(postLike.ToFullResponse(query));
		}

		public void RemoveGetById(
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
