using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Identity.Domain.Tests.Features.Users.Utilities;
using InstaConnect.Identity.Events.Features.UserClaims;

namespace InstaConnect.Identity.Domain.Tests.Features.UserClaims.Utilities;

public static class UserClaimEquals
{
	extension(UserClaimId response)
	{
		public bool Matches(
			AddUserClaimCommand command,
			UserClaim userClaim)
		{
			return response.Matches(userClaim.Id);
		}
	}

	extension(UserClaimInclude p)
	{
		public bool Matches(DeleteUserClaimCommand command, UserClaimInclude include)
		{
			return p.Matches(include);
		}
	}

	extension(UserClaimAddedEventRequest request)
	{
		public bool Matches(AddUserClaimCommand command, UserClaim entity)
		{
			return command.Id.Matches(request.UserClaim.Id) &&
				   command.Claim == request.UserClaim.Claim &&
				   entity.User.Matches(request.UserClaim.User) &&
				   entity.CreatedAtUtc == request.UserClaim.CreatedAtUtc;
		}
	}

	extension(UserClaimDeletedEventRequest request)
	{
		public bool Matches(DeleteUserClaimCommand command, UserClaim entity)
		{
			return entity.Id.Matches(command.Id) &&
				   entity.User.Matches(request.UserClaim.User) &&
				   entity.CreatedAtUtc == request.UserClaim.CreatedAtUtc;
		}
	}

	extension(UserClaim userClaim)
	{
		public bool Matches(AddUserClaimCommand command)
		{
			return userClaim.Id.Matches(command.Id.Id, command.Claim);
		}

		public bool Matches(DeleteUserClaimCommand command)
		{
			return userClaim.Id.Matches(command.Id);
		}

		public bool MatchesFilter(UserClaimsFilterQuery filter)
		{
			return userClaim.Id.Id.Matches(filter.Id);
		}
	}

	extension(UserClaimResponse? response)
	{
		public bool MatchesFull(UserClaim? userClaim)
		{
			return response != null &&
				   userClaim != null &&
				   userClaim.Id.Matches(response.Id) &&
				   response.User.MatchesFull(userClaim.User) &&
				   userClaim.CreatedAtUtc == response.CreatedAtUtc;
		}

		public bool MatchesWithoutUser(UserClaim? userClaim)
		{
			return response != null &&
				   userClaim != null &&
				   userClaim.Id.Matches(response.Id) &&
				   response.User == null &&
				   userClaim.CreatedAtUtc == response.CreatedAtUtc;
		}
	}

	extension(UserClaimCollectionResponse response)
	{
		public bool Matches(
			GetAllUserClaimsQuery query,
			User user,
			ICollection<UserClaim> userClaims)
		{
			return response.MatchesCollectionResponse(query.Pagination, userClaims.Count(userClaim => userClaim.MatchesFilter(query.Filter))) &&
				   response.User.MatchesFull(user) &&
				   response.UserClaims.MatchesCollection(query.Pagination,
				                                         userClaims,
														 response => response.Id,
														 userClaim => userClaim.Id,
														 (response, userClaim) => response.MatchesWithoutUser(userClaim),
														 userClaim => userClaim.MatchesFilter(query.Filter));
		}

		public bool Matches(
			GetAllUserClaimsQuery query,
			User user,
			ICollection<UserClaim> userClaims,
			ISortEnumTermTransformer<UserClaim> termTransformer)
		{
			return response.MatchesCollectionResponse(query.Pagination, userClaims.Count(userClaim => userClaim.MatchesFilter(query.Filter))) &&
				   response.User.MatchesFull(user) &&
				   response.UserClaims.MatchesSortedCollection(query.Pagination,
															   userClaims,
															   (response, userClaim) => response.MatchesWithoutUser(userClaim),
															   termTransformer,
															   userClaim => userClaim.MatchesFilter(query.Filter));
		}
	}
}
