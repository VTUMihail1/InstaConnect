using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Identity.Domain.Tests.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Features.UserClaims.Assertions;

public static class UserClaimMockAssertions
{
	extension(IUserClaimFactory factory)
	{
		public void ShouldHaveReceivedOneCreate(
			AddUserClaimCommand command)
		{
			factory.ShouldHaveReceivedOne().Create(
				command.Id,
				command.Claim);
		}
	}

	extension(IUserClaimCommandRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetByIdAsync(
			AddUserClaimCommand command,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				userClaim.Id,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			DeleteUserClaimCommand command,
			UserClaimInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				command.Id,
				include,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAddAsync(
			AddUserClaimCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().AddAsync(command.IsUserClaim(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeleteUserClaimCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().DeleteAsync(command.IsUserClaim(), cancellationToken);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetByIdAsync(
			AddUserClaimCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				command.Id,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneExistsByIdAsync(
			DeleteUserClaimCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().ExistsByIdAsync(
				command.Id.Id,
				cancellationToken);
		}
	}

	extension(IUserQueryRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetAllUserClaimsQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				query.Filter.Id,
				query.Current,
				cancellationToken);
		}
	}

	extension(IUserClaimQueryRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetAllAsync(
			GetAllUserClaimsQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetAllAsync(
				query.Filter,
				query.Sorting,
				query.Pagination,
				query.Current,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetTotalCountAsync(
			GetAllUserClaimsQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetTotalCountAsync(
				query.Filter,
				cancellationToken);
		}
	}

	extension(IEventPublisher eventPublisher)
	{
		public async Task ShouldHaveReceivedOnePublishAsync(
			AddUserClaimCommand command,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOne().PublishAsync(command.IsUserClaimAddedEventRequest(userClaim), cancellationToken);
		}

		public async Task ShouldHaveReceivedOnePublishAsync(
			DeleteUserClaimCommand command,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOne().PublishAsync(command.IsUserClaimDeletedEventRequest(userClaim), cancellationToken);
		}
	}
}
