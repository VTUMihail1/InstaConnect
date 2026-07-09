using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;

namespace InstaConnect.Follows.Domain.Tests.Features.Follows.Utilities;

public static class FollowMockSetups
{
	extension(IDateTimeProvider dateTimeProvider)
	{
		public void SetupNewGuid(Follow follow)
		{
			dateTimeProvider.GetOffsetUtcNow()
				.ReturnsResponse(follow.CreatedAtUtc);
		}
	}

	extension(IFollowFactory factory)
	{
		public void SetupCreate(
			AddFollowCommand command,
			Follow follow)
		{
			factory
				.Create(
					command.FollowerId,
					command.FollowingId)
				.ReturnsResponse(follow.To(command));
		}
	}

	extension(IUserCommandRepository repository)
	{
		public void SetupGetByFollowerId(
			AddFollowCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.FollowerId, cancellationToken)
				.ReturnsTaskResponse(user);
		}

		public void SetupGetByFollowingId(
			AddFollowCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.FollowingId, cancellationToken)
				.ReturnsTaskResponse(user);
		}

		public void RemoveGetByFollowerId(
			AddFollowCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.FollowerId, cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void RemoveGetByFollowingId(
			AddFollowCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.FollowingId, cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}

	extension(IFollowCommandRepository repository)
	{
		public void SetupExistsById(
			Follow follow,
			CancellationToken cancellationToken)
		{
			repository
				.ExistsByIdAsync(follow.Id, cancellationToken)
				.ReturnsTaskResponse(false);
		}

		public void SetupExistsByIdExists(
			Follow follow,
			CancellationToken cancellationToken)
		{
			repository
				.ExistsByIdAsync(follow.Id, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void SetupGetById(
			DeleteFollowCommand command,
			FollowInclude include,
			Follow follow,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, FollowMatcher.IsFollowInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(follow);
		}

		public void RemoveGetById(
			DeleteFollowCommand command,
			FollowInclude include,
			Follow follow,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, FollowMatcher.IsFollowInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}

	extension(IUserQueryRepository repository)
	{
		public void SetupGetById(
			GetAllFollowsQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(query.Filter.FollowerId, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(query));
		}

		public void SetupGetById(
			GetAllFollowsForFollowingQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(query.Filter.FollowingId, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(query));
		}

		public void RemoveGetById(
			GetAllFollowsQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(query.Filter.FollowerId, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void RemoveGetById(
			GetAllFollowsForFollowingQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(query.Filter.FollowingId, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}

	extension(IFollowQueryRepository repository)
	{
		public void SetupGetAllQuery(
			GetAllFollowsQuery query,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			repository
				.GetAllAsync(query.Filter, query.CurrentUser, query.Sorting, query.Pagination, cancellationToken)
				.ReturnsTaskResponse(follows.ToResponse(query));
		}

		public void SetupGetTotalCount(
			GetAllFollowsQuery query,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			repository
				.GetTotalCountAsync(query.Filter, cancellationToken)
				.ReturnsTaskResponse(follows.ToTotalCountResponse(query));
		}

		public void SetupGetAllForFollowingQuery(
			GetAllFollowsForFollowingQuery query,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			repository
				.GetAllForFollowingAsync(query.Filter, query.CurrentUser, query.Sorting, query.Pagination, cancellationToken)
				.ReturnsTaskResponse(follows.ToResponse(query));
		}

		public void SetupGetTotalCountForFollowing(
			GetAllFollowsForFollowingQuery query,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			repository
				.GetTotalCountForFollowingAsync(query.Filter, cancellationToken)
				.ReturnsTaskResponse(follows.ToTotalCountResponse(query));
		}

		public void SetupGetById(
			GetFollowByIdQuery query,
			Follow follow,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(query.Id, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(follow.ToResponse(query));
		}

		public void RemoveGetById(
			GetFollowByIdQuery query,
			Follow follow,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(query.Id, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}
}
