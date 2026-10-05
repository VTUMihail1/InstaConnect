using InstaConnect.Identity.Domain.Features.UserClaims.Models.Entities;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Requests;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.ValueObjects;
using InstaConnect.Identity.Domain.Features.Users.Models.Requests;
using InstaConnect.Identity.Infrastructure.Features.UserClaims.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Tests.Features.UserClaims.Utilities;

public static class UserClaimMockSetups
{
	extension(IUserClaimCollection collection)
	{
		public void SetupAggregateFluent(
			UserClaimId id,
			IUserClaimFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}

		public void SetupAggregateFluent(
			UserClaimId id,
			CurrentUserQuery currentUserQuery,
			IUserClaimFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}

		public void SetupAggregateFluent(
			UserClaimsFilterQuery filterQuery,
			UserClaimsSortingQuery sortingQuery,
			UserClaimsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IUserClaimFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}

		public void SetupAggregateFluent(
			UserClaimsFilterQuery filterQuery,
			IUserClaimFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}
	}

	extension(IUserClaimFluent fluent)
	{
		public void SetupGetCountAsync(
			UserClaimsFilterQuery filterQuery,
			ICollection<UserClaim> userClaims,
			CancellationToken cancellationToken)
		{
			fluent.GetCountAsync(cancellationToken).ReturnsTaskResponse(userClaims.ToTotalCountResponse(filterQuery));
		}

		public void SetupAnyAsync(
			UserClaimId id,
			UserClaim? userClaim,
			CancellationToken cancellationToken)
		{
			fluent.AnyAsync(cancellationToken).ReturnsTaskResponse(userClaim != null);
		}

		public void SetupApplyIncludes(
			UserClaimId id,
			UserClaimInclude include)
		{
			fluent.ApplyIncludes(include).ReturnsResponse(fluent);
		}

		public void SetupMatch(UserClaimId id)
		{
			fluent.Match(id).ReturnsResponse(fluent);
		}

		public void SetupMatch(
			UserClaimId id,
			CurrentUserQuery currentUserQuery)
		{
			fluent.Match(id).ReturnsResponse(fluent);
		}

		public void SetupMatch(UserClaimsFilterQuery filterQuery)
		{
			fluent.Match(filterQuery).ReturnsResponse(fluent);
		}

		public void SetupMatch(
			UserClaimsFilterQuery filterQuery,
			UserClaimsSortingQuery sortingQuery,
			UserClaimsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.Match(filterQuery).ReturnsResponse(fluent);
		}

		public void SetupProjectToFullResponse(
			UserClaimId id,
			CurrentUserQuery currentUserQuery,
			IUserClaimResponseFluent responseFluent)
		{
			fluent.ProjectToFullResponse(currentUserQuery).ReturnsResponse(responseFluent);
		}

		public void SetupProjectToResponseWithoutUser(
			UserClaimsFilterQuery filterQuery,
			UserClaimsSortingQuery sortingQuery,
			UserClaimsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IUserClaimResponseFluent responseFluent)
		{
			fluent.ProjectToResponseWithoutUser(currentUserQuery).ReturnsResponse(responseFluent);
		}

		public void SetupFirstOrDefaultAsync(
			UserClaimId id,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			fluent.FirstOrDefaultAsync(cancellationToken).ReturnsTaskResponse(userClaim);
		}
	}

	extension(IUserClaimResponseFluent fluent)
	{
		public void SetupApplySorting(
			UserClaimsFilterQuery filterQuery,
			UserClaimsSortingQuery sortingQuery,
			UserClaimsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ApplySorting(sortingQuery).ReturnsResponse(fluent);
		}

		public void SetupApplyPagination(
			UserClaimsFilterQuery filterQuery,
			UserClaimsSortingQuery sortingQuery,
			UserClaimsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ApplyPagination(paginationQuery).ReturnsResponse(fluent);
		}

		public void SetupToListAsync(
			UserClaimsFilterQuery filterQuery,
			UserClaimsSortingQuery sortingQuery,
			UserClaimsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			ICollection<UserClaim> userClaims,
			CancellationToken cancellationToken)
		{
			fluent.ToListAsync(cancellationToken).ReturnsTaskResponse(userClaims.ToResponse(filterQuery, paginationQuery, currentUserQuery));
		}

		public void SetupFirstOrDefaultAsync(
			UserClaimId id,
			CurrentUserQuery currentUserQuery,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			fluent.FirstOrDefaultAsync(cancellationToken).ReturnsTaskResponse(userClaim.ToResponse(id, currentUserQuery));
		}
	}
}
