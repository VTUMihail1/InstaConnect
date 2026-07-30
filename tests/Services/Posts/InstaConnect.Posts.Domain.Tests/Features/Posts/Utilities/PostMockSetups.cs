using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Domain.Features.Guids.Abstractions;

namespace InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;

public static class PostMockSetups
{
	extension(IGuidProvider guidProvider)
	{
		public void SetupNewStringGuid(Post post)
		{
			guidProvider
				.ClearCalls()
				.NewStringGuid()
				.ReturnsResponse(post.Id.Id);
		}
	}

	extension(IDateTimeProvider dateTimeProvider)
	{
		public void SetupGetOffsetUtcNow(Post post)
		{
			dateTimeProvider
				.ClearCalls()
				.GetOffsetUtcNow()
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
				.ClearCalls()
				.Create(
					command.UserId,
					command.Title,
					command.Content)
				.ReturnsResponse(post.To(command));
		}
	}

	extension(IPostQueryRepository service)
	{
		public void SetupGetAllAsync(
		GetAllPostsQuery query,
		ICollection<Post> posts,
		CancellationToken cancellationToken)
		{
			service
				.ClearCalls()
				.GetAllAsync(query.Filter, query.CurrentUser, query.Sorting, query.Pagination, cancellationToken)
				.ReturnsTaskResponse(posts.ToResponse(query));
		}

		public void SetupGetTotalCountAsync(
		GetAllPostsQuery query,
		ICollection<Post> posts,
		CancellationToken cancellationToken)
		{
			service
				.ClearCalls()
				.GetTotalCountAsync(query.Filter, cancellationToken)
				.ReturnsTaskResponse(posts.ToTotalCountResponse(query));
		}

		public void SetupGetAllForUserAsync(
			GetAllPostsForUserQuery query,
			User user,
			ICollection<Post> posts,
			CancellationToken cancellationToken)
		{
			service
				.ClearCalls()
				.GetAllForUserAsync(query.Filter, query.CurrentUser, query.Sorting, query.Pagination, cancellationToken)
				.ReturnsTaskResponse(posts.ToResponse(query, user));
		}

		public void SetupGetTotalCountForUserAsync(
		GetAllPostsForUserQuery query,
		ICollection<Post> posts,
		CancellationToken cancellationToken)
		{
			service
				.ClearCalls()
				.GetTotalCountForUserAsync(query.Filter, cancellationToken)
				.ReturnsTaskResponse(posts.ToTotalCountResponse(query));
		}

		public void SetupGetByIdAsync(
			GetPostByIdQuery query,
			Post post,
			CancellationToken cancellationToken)
		{
			service
				.ClearCalls()
				.GetByIdAsync(query.Id, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(post.ToResponse(query));
		}

		public void RemoveGetByIdAsync(
			GetPostByIdQuery query,
			Post post,
			CancellationToken cancellationToken)
		{
			service
				.ClearCalls()
				.GetByIdAsync(query.Id, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}

	extension(IPostCommandRepository repository)
	{
		public void SetupGetByIdAsync(
			UpdatePostCommand command,
			PostInclude include,
			Post post,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.Id, PostDomainMatcher.IsPostInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(post);
		}

		public void SetupGetByIdAsync(
			DeletePostCommand command,
			PostInclude include,
			Post post,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.Id, PostDomainMatcher.IsPostInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(post);
		}

		public void RemoveGetByIdAsync(
			UpdatePostCommand command,
			PostInclude include,
			Post post,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.Id, PostDomainMatcher.IsPostInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void RemoveGetByIdAsync(
			DeletePostCommand command,
			PostInclude include,
			Post post,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.Id, PostDomainMatcher.IsPostInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}

	extension(IUserQueryRepository repository)
	{
		public void SetupGetByIdAsync(
			GetAllPostsForUserQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(query.Filter.UserId, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(query));
		}

		public void RemoveGetByIdAsync(
			GetAllPostsForUserQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(query.Filter.UserId, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public void SetupGetByIdAsync(
			AddPostCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.UserId, cancellationToken)
				.ReturnsTaskResponse(user);
		}

		public void RemoveGetByIdAsync(
			AddPostCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
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
			dateTimeProvider.ClearCalls().GetOffsetUtcNow().ReturnsResponse(post.UpdatedAtUtc);
		}
	}
}
