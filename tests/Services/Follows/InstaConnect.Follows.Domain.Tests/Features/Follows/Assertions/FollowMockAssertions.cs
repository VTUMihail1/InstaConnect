using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Follows.Domain.Tests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Domain.Tests.Features.Follows.Assertions;

public static class FollowMockAssertions
{
	extension(IFollowFactory factory)
	{
		public void ShouldHaveReceivedOneCreate(
			AddFollowCommand command)
		{
			factory.ShouldHaveReceivedOne().Create(
				command.FollowerId,
				command.FollowingId);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetByFollowerIdAsync(
			AddFollowCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				command.FollowerId,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByFollowingIdAsync(
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
		public async Task ShouldHaveReceivedOneExistsByIdAsync(
			AddFollowCommand command,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().ExistsByIdAsync(
				follow.Id,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			DeleteFollowCommand command,
			FollowInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				command.Id,
				include,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAddAsync(
			AddFollowCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().AddAsync(command.IsFollow(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeleteFollowCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().DeleteAsync(command.IsFollow(), cancellationToken);
		}
	}

	extension(IUserQueryRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetAllFollowsQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				query.Filter.FollowerId,
				query.CurrentUser,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
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
		public async Task ShouldHaveReceivedOneGetAllAsync(
			GetAllFollowsQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetAllAsync(
				query.Filter,
				query.Sorting,
				query.Pagination,
				query.CurrentUser,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetTotalCountAsync(
			GetAllFollowsQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetTotalCountAsync(
				query.Filter,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetAllForFollowingAsync(
			GetAllFollowsForFollowingQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetAllForFollowingAsync(
				query.Filter,
				query.Sorting,
				query.Pagination,
				query.CurrentUser,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetTotalCountForFollowingAsync(
			GetAllFollowsForFollowingQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetTotalCountForFollowingAsync(
				query.Filter,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
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
		public async Task ShouldHaveReceivedOneAddedAsync(
			AddFollowCommand command,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await notificationService.ShouldHaveReceivedOne().AddedAsync(command.IsFollowAddedNotificationRequest(follow), cancellationToken);
		}
	}

	extension(IEventPublisher eventPublisher)
	{
		public async Task ShouldHaveReceivedOnePublishAsync(
			AddFollowCommand command,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOne().PublishAsync(command.IsFollowAddedEventRequest(follow), cancellationToken);
		}

		public async Task ShouldHaveReceivedOnePublishAsync(
			DeleteFollowCommand command,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOne().PublishAsync(command.IsFollowDeletedEventRequest(follow), cancellationToken);
		}
	}
}
