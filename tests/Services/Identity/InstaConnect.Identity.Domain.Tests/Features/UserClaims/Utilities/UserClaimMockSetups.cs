using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;

namespace InstaConnect.Identity.Domain.Tests.Features.UserClaims.Utilities;

public static class UserClaimMockSetups
{
	extension(IDateTimeProvider dateTimeProvider)
	{
		public void SetupGetOffsetUtcNow(UserClaim userClaim)
		{
			dateTimeProvider
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
				.Create(
					command.Id,
					command.Claim)
				.ReturnsResponse(userClaim.To(command));
		}
	}

	extension(IUserClaimCommandRepository repository)
	{
		public void SetupGetById(
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(userClaim.Id, cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void SetupGetById(
			DeleteUserClaimCommand command,
			UserClaimInclude include,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, UserClaimMatcher.IsUserClaimInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(userClaim);
		}

		public void SetupGetByIdExists(
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(userClaim.Id, cancellationToken)
				.ReturnsTaskResponse(userClaim);
		}

		public void RemoveGetById(
			DeleteUserClaimCommand command,
			UserClaimInclude include,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, UserClaimMatcher.IsUserClaimInclude(command, include), cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public void SetupGetById(
			AddUserClaimCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, cancellationToken)
				.ReturnsTaskResponse(user);
		}

		public void RemoveGetById(
			AddUserClaimCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(command.Id, cancellationToken)
				.ReturnsTaskResponse(null);
		}

		public void SetupExistsById(
			DeleteUserClaimCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ExistsByIdAsync(command.Id.Id, cancellationToken)
				.ReturnsTaskResponse(true);
		}

		public void RemoveExistsById(
			DeleteUserClaimCommand command,
			CancellationToken cancellationToken)
		{
			repository
				.ExistsByIdAsync(command.Id.Id, cancellationToken)
				.ReturnsTaskResponse(false);
		}
	}

	extension(IUserQueryRepository repository)
	{
		public void SetupGetById(
			GetAllUserClaimsQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(query.Filter.Id, query.Current, cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(query));
		}

		public void RemoveGetById(
			GetAllUserClaimsQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(query.Filter.Id, query.Current, cancellationToken)
				.ReturnsTaskResponse(null);
		}
	}

	extension(IUserClaimQueryRepository repository)
	{
		public void SetupGetAllQuery(
			GetAllUserClaimsQuery query,
			ICollection<UserClaim> userClaims,
			CancellationToken cancellationToken)
		{
			repository
				.GetAllAsync(query.Filter, query.Current, query.Sorting, query.Pagination, cancellationToken)
				.ReturnsTaskResponse(userClaims.ToResponse(query));
		}

		public void SetupGetTotalCount(
			GetAllUserClaimsQuery query,
			ICollection<UserClaim> userClaims,
			CancellationToken cancellationToken)
		{
			repository
				.GetTotalCountAsync(query.Filter, cancellationToken)
				.ReturnsTaskResponse(userClaims.ToTotalCountResponse(query));
		}
	}
}
