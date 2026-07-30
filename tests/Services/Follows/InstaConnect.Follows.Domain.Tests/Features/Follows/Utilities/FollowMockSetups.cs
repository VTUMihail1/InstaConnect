using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;

namespace InstaConnect.Follows.Domain.Tests.Features.Follows.Utilities;

public static class FollowMockSetups
{
	extension(IDateTimeProvider dateTimeProvider)
	{
		public void SetupGetOffsetUtcNow(Follow follow)
		{
			dateTimeProvider.ClearCalls().GetOffsetUtcNow()
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
				.ClearCalls()
				.Create(
					command.FollowerId,
					command.FollowingId)
				.ReturnsResponse(follow.To(command));
		}
	}

	extension(IUserCommandRepository repository)
	{
		public void SetupGetFollowerByIdAsync(
			AddFollowCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.FollowerId, cancellationToken)
				.ReturnsTaskResponse(user);
		}

		public void SetupGetFollowingByIdAsync(
			AddFollowCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.FollowingId, cancellationToken)
				.ReturnsTaskResponse(user);
		}

		public void RemoveGetFollowerByIdAsync(
			AddFollowCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.FollowerId, cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void RemoveGetFollowingByIdAsync(
			AddFollowCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.FollowingId, cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}

	extension(IFollowCommandRepository repository)
	{
		public void RemoveExistsByIdAsync(
			AddFollowCommand command,
			Follow follow,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.ExistsByIdAsync(follow.Id, cancellationToken)
				.ReturnsTaskResponse(false);
		}

		public void SetupExistsByIdAsync(
			AddFollowCommand command,
			Follow follow,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.ExistsByIdAsync(follow.Id, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void SetupGetByIdAsync(
			DeleteFollowCommand command,
			FollowInclude include,
			Follow follow,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.Id, FollowDomainMatcher.IsFollowInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(follow);
		}

		public void RemoveGetByIdAsync(
			DeleteFollowCommand command,
			FollowInclude include,
			Follow follow,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.Id, FollowDomainMatcher.IsFollowInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}

	extension(IUserQueryRepository repository)
	{
		public void SetupGetByIdAsync(
			GetAllFollowsQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(query.Filter.FollowerId, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(query));
		}

		public void SetupGetByIdAsync(
			GetAllFollowsForFollowingQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(query.Filter.FollowingId, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(query));
		}

		public void RemoveGetByIdAsync(
			GetAllFollowsQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(query.Filter.FollowerId, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void RemoveGetByIdAsync(
			GetAllFollowsForFollowingQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(query.Filter.FollowingId, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}

	extension(IFollowQueryRepository repository)
	{
		public void SetupGetAllAsync(
			GetAllFollowsQuery query,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetAllAsync(query.Filter, query.CurrentUser, query.Sorting, query.Pagination, cancellationToken)
				.ReturnsTaskResponse(follows.ToResponse(query));
		}

		public void SetupGetTotalCountAsync(
			GetAllFollowsQuery query,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetTotalCountAsync(query.Filter, cancellationToken)
				.ReturnsTaskResponse(follows.ToTotalCountResponse(query));
		}

		public void SetupGetAllForFollowingAsync(
			GetAllFollowsForFollowingQuery query,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetAllForFollowingAsync(query.Filter, query.CurrentUser, query.Sorting, query.Pagination, cancellationToken)
				.ReturnsTaskResponse(follows.ToResponse(query));
		}

		public void SetupGetTotalCountForFollowingAsync(
			GetAllFollowsForFollowingQuery query,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetTotalCountForFollowingAsync(query.Filter, cancellationToken)
				.ReturnsTaskResponse(follows.ToTotalCountResponse(query));
		}

		public void SetupGetByIdAsync(
			GetFollowByIdQuery query,
			Follow follow,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(query.Id, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(follow.ToResponse(query));
		}

		public void RemoveGetByIdAsync(
			GetFollowByIdQuery query,
			Follow follow,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(query.Id, query.CurrentUser, cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}
}
