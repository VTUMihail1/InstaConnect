using InstaConnect.Common.Events.Features.Common.Abstractions;
using InstaConnect.Identity.Domain.Tests.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Features.UserClaims.Assertions;

public static class UserClaimMockAssertions
{
	extension(IUserClaimFactory factory)
	{
		public void ShouldReceiveOneCreate(
			AddUserClaimCommand command)
		{
			factory.ShouldHaveReceivedOne().Create(
				command.Id,
				command.Claim);
		}
	}

	extension(IUserClaimCommandRepository repository)
	{
		public async Task ShouldReceiveOneGetByIdAsync(
			AddUserClaimCommand command,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				userClaim.Id,
				cancellationToken);
		}

		public async Task ShouldReceiveOneGetByIdAsync(
			DeleteUserClaimCommand command,
			UserClaimInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				command.Id,
				UserClaimMatcher.IsUserClaimInclude(command, include),
				cancellationToken);
		}

		public async Task ShouldReceiveOneAddAsync(
			AddUserClaimCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().AddAsync(UserClaimMatcher.IsUserClaim(command), cancellationToken);
		}

		public async Task ShouldReceiveOneDeleteAsync(
			DeleteUserClaimCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().DeleteAsync(UserClaimMatcher.IsUserClaim(command), cancellationToken);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public async Task ShouldReceiveOneGetByIdAsync(
			AddUserClaimCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				command.Id,
				cancellationToken);
		}

		public async Task ShouldReceiveOneExistsByIdAsync(
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
		public async Task ShouldReceiveOneGetByIdAsync(
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
		public async Task ShouldReceiveOneGetAllAsync(
			GetAllUserClaimsQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetAllAsync(
				query.Filter,
				query.Current,
				query.Sorting,
				query.Pagination,
				cancellationToken);
		}

		public async Task ShouldReceiveOneGetTotalCountAsync(
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
		public async Task ShouldReceiveOnePublishAsync(
			AddUserClaimCommand command,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOne().PublishAsync(UserClaimMatcher.IsUserClaimAddedEventRequest(userClaim), cancellationToken);
		}

		public async Task ShouldReceiveOnePublishAsync(
			DeleteUserClaimCommand command,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOne().PublishAsync(UserClaimMatcher.IsUserClaimDeletedEventRequest(userClaim), cancellationToken);
		}
	}
}
