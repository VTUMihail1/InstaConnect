using InstaConnect.Common.Events.Features.Common.Abstractions;
using InstaConnect.Follows.Domain.Tests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Domain.Tests.Features.Follows.Assertions;

public static class FollowMockAssertions
{
	extension(IFollowFactory factory)
	{
		public void ShouldReceiveOneCreate(
			AddFollowCommand command)
		{
			factory.ShouldHaveReceivedOne().Create(
				command.FollowerId,
				command.FollowingId);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public async Task ShouldReceiveOneGetByFollowerIdAsync(
			AddFollowCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				command.FollowerId,
				cancellationToken);
		}

		public async Task ShouldReceiveOneGetByFollowingIdAsync(
			AddFollowCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				command.FollowingId,
				cancellationToken);
		}
	}

	extension(IFollowCommandRepository repository)
	{
		public async Task ShouldReceiveOneExistsByIdAsync(
			AddFollowCommand command,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().ExistsByIdAsync(
				follow.Id,
				cancellationToken);
		}

		public async Task ShouldReceiveOneGetByIdAsync(
			DeleteFollowCommand command,
			FollowInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				command.Id,
				FollowMatcher.IsFollowInclude(command, include),
				cancellationToken);
		}

		public async Task ShouldReceiveOneAddAsync(
			AddFollowCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().AddAsync(FollowMatcher.IsFollow(command), cancellationToken);
		}

		public async Task ShouldReceiveOneDeleteAsync(
			DeleteFollowCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().DeleteAsync(FollowMatcher.IsFollow(command), cancellationToken);
		}
	}

	extension(IUserQueryRepository repository)
	{
		public async Task ShouldReceiveOneGetByIdAsync(
			GetAllFollowsQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				query.Filter.FollowerId,
				query.CurrentUser,
				cancellationToken);
		}

		public async Task ShouldReceiveOneGetByIdAsync(
			GetAllFollowsForFollowingQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				query.Filter.FollowingId,
				query.CurrentUser,
				cancellationToken);
		}
	}

	extension(IFollowQueryRepository repository)
	{
		public async Task ShouldReceiveOneGetAllAsync(
			GetAllFollowsQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetAllAsync(
				query.Filter,
				query.CurrentUser,
				query.Sorting,
				query.Pagination,
				cancellationToken);
		}

		public async Task ShouldReceiveOneGetTotalCountAsync(
			GetAllFollowsQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetTotalCountAsync(
				query.Filter,
				cancellationToken);
		}

		public async Task ShouldReceiveOneGetAllForFollowingAsync(
			GetAllFollowsForFollowingQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetAllForFollowingAsync(
				query.Filter,
				query.CurrentUser,
				query.Sorting,
				query.Pagination,
				cancellationToken);
		}

		public async Task ShouldReceiveOneGetTotalCountForFollowingAsync(
			GetAllFollowsForFollowingQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetTotalCountForFollowingAsync(
				query.Filter,
				cancellationToken);
		}

		public async Task ShouldReceiveOneGetByIdAsync(
			GetFollowByIdQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				query.Id,
				query.CurrentUser,
				cancellationToken);
		}
	}

	extension(IFollowNotificationService notificationService)
	{
		public async Task ShouldReceiveOneAddedAsync(
			AddFollowCommand command,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await notificationService.ShouldHaveReceivedOne().AddedAsync(FollowMatcher.IsFollowAddedNotificationRequest(follow), cancellationToken);
		}
	}

	extension(IEventPublisher eventPublisher)
	{
		public async Task ShouldReceiveOnePublishAsync(
			AddFollowCommand command,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOne().PublishAsync(FollowMatcher.IsFollowAddedEventRequest(command, follow), cancellationToken);
		}

		public async Task ShouldReceiveOnePublishAsync(
			DeleteFollowCommand command,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOne().PublishAsync(FollowMatcher.IsFollowDeletedEventRequest(command, follow), cancellationToken);
		}
	}
}
