using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;

namespace InstaConnect.Identity.Domain.Tests.Features.UserClaims.Utilities;

public static class UserClaimMockSetups
{
	extension(IDateTimeProvider dateTimeProvider)
	{
		public void SetupGetOffsetUtcNow(UserClaim userClaim)
		{
			dateTimeProvider
				.ClearCalls()
				.GetOffsetUtcNow()
				.ReturnsResponse(userClaim.CreatedAtUtc);
		}
	}

	extension(IUserClaimFactory factory)
	{
		public void SetupCreate(
			AddUserClaimCommand command,
			UserClaim userClaim)
		{
			factory
				.ClearCalls()
				.Create(
					command.Id,
					command.Claim)
				.ReturnsResponse(userClaim.To(command));
		}
	}

	extension(IUserClaimCommandRepository repository)
	{
		public void SetupGetByIdAsync(
			DeleteUserClaimCommand command,
			UserClaimInclude include,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.Id, UserClaimDomainMatcher.IsUserClaimInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(userClaim);
		}

		public void SetupGetByIdAsync(
			AddUserClaimCommand command,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(userClaim.Id, cancellationToken)
				.ReturnsTaskResponse(userClaim);
		}

		public void RemoveGetByIdAsync(
			AddUserClaimCommand command,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(userClaim.Id, cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void RemoveGetByIdAsync(
			DeleteUserClaimCommand command,
			UserClaimInclude include,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.Id, UserClaimDomainMatcher.IsUserClaimInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public void SetupGetByIdAsync(
			AddUserClaimCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.Id, cancellationToken)
				.ReturnsTaskResponse(user);
		}

		public void RemoveGetByIdAsync(
			AddUserClaimCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(command.Id, cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void SetupExistsByIdAsync(
			DeleteUserClaimCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.ExistsByIdAsync(command.Id.Id, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void RemoveExistsByIdAsync(
			DeleteUserClaimCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.ExistsByIdAsync(command.Id.Id, cancellationToken)
				.ReturnsTaskResponse(false);
		}
	}

	extension(IUserQueryRepository repository)
	{
		public void SetupGetByIdAsync(
			GetAllUserClaimsQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(query.Filter.Id, query.Current, cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(query));
		}

		public void RemoveGetByIdAsync(
			GetAllUserClaimsQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetByIdAsync(query.Filter.Id, query.Current, cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}

	extension(IUserClaimQueryRepository repository)
	{
		public void SetupGetAllAsync(
			GetAllUserClaimsQuery query,
			ICollection<UserClaim> userClaims,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetAllAsync(query.Filter, query.Current, query.Sorting, query.Pagination, cancellationToken)
				.ReturnsTaskResponse(userClaims.ToResponse(query));
		}

		public void SetupGetTotalCountAsync(
			GetAllUserClaimsQuery query,
			ICollection<UserClaim> userClaims,
			CancellationToken cancellationToken)
		{
			repository
				.ClearCalls()
				.GetTotalCountAsync(query.Filter, cancellationToken)
				.ReturnsTaskResponse(userClaims.ToTotalCountResponse(query));
		}
	}
}
