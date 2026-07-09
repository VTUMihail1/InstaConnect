using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Domain.Features.Guids.Abstractions;

namespace InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;

public static class PostMockSetups
{
	extension(IGuidProvider guidProvider)
	{
		public void SetupNewStringGuid(Post post)
		{
			guidProvider.NewStringGuid()
				.ReturnsResponse(post.Id.Id);
		}
	}

	extension(IDateTimeProvider dateTimeProvider)
	{
		public void SetupGetOffsetUtcNow(Post post)
		{
			dateTimeProvider.GetOffsetUtcNow()
				.ReturnsResponse(post.CreatedAtUtc);
		}
	}

	extension(IPostFactory factory)
	{
		public void SetupCreate(
			AddPostCommand command,
			Post post)
		{
			factory
				.Create(
					command.UserId,
					command.Title,
					command.Content)
				.ReturnsResponse(post.To(command));
		}
	}

	extension(IPostQueryRepository service)
	{
		public void SetupGetAllQuery(
		GetAllPostsQuery query,
		ICollection<Post> posts,
		CancellationToken cancellationToken)
		{
			service
				.GetAllAsync(query.Filter, query.CurrentUser, query.Sorting, query.Pagination, cancellationToken)
				.ReturnsTaskResponse(posts.ToResponse(query));
		}

		public void SetupGetTotalCount(
		GetAllPostsQuery query,
		ICollection<Post> posts,
		CancellationToken cancellationToken)
		{
			service
				.GetTotalCountAsync(query.Filter, cancellationToken)
				.ReturnsTaskResponse(posts.ToTotalCountResponse(query));
		}

		public void SetupGetAllForUserQuery(
			GetAllPostsForUserQuery query,
			User user,
			ICollection<Post> posts,
			CancellationToken cancellationToken)
		{
			service
				.GetAllForUserAsync(query.Filter, query.CurrentUser, query.Sorting, query.Pagination, cancellationToken)
				.ReturnsTaskResponse(posts.ToResponse(user, query));
		}

		public void SetupGetTotalCountForUser(
		GetAllPostsForUserQuery query,
		ICollection<Post> posts,
		CancellationToken cancellationToken)
		{
			service
				.GetTotalCountForUserAsync(query.Filter, cancellationToken)
				.ReturnsTaskResponse(posts.ToTotalCountResponse(query));
		}

		public void SetupGetById(
			GetPostByIdQuery query,
			Post post,
			CancellationToken cancellationToken)
		{
			service
				.GetByIdAsync(query.Id, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(post.ToResponse(query));
		}

		public void RemoveGetById(
			GetPostByIdQuery query,
			Post post,
			CancellationToken cancellationToken)
		{
			service
				.GetByIdAsync(query.Id, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}

	extension(IPostCommandRepository repository)
	{
		public void SetupGetById(
			UpdatePostCommand command,
			PostInclude include,
			Post post,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, PostMatcher.IsPostInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(post);
		}

		public void SetupGetById(
			DeletePostCommand command,
			PostInclude include,
			Post post,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, PostMatcher.IsPostInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(post);
		}

		public void RemoveGetById(
			UpdatePostCommand command,
			PostInclude include,
			Post post,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, PostMatcher.IsPostInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void RemoveGetById(
			DeletePostCommand command,
			PostInclude include,
			Post post,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, PostMatcher.IsPostInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}

	extension(IUserQueryRepository repository)
	{
		public void SetupGetById(
			GetAllPostsForUserQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(query.Filter.UserId, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(query));
		}

		public void RemoveGetById(
			GetAllPostsForUserQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(query.Filter.UserId, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public void SetupGetById(
			AddPostCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.UserId, cancellationToken)
				.ReturnsTaskResponse(user);
		}

		public void RemoveGetById(
			AddPostCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.UserId, cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}

	extension(IDateTimeProvider dateTimeProvider)
	{
		public void SetupGetOffsetUtcNow(
			UpdatePostCommand command,
			Post post)
		{
			dateTimeProvider.GetOffsetUtcNow().ReturnsResponse(post.UpdatedAtUtc);
		}
	}
}
