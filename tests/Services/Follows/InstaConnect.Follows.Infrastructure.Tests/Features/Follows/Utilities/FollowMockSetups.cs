using InstaConnect.Follows.Domain.Features.Follows.Models.Entities;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;
using InstaConnect.Follows.Domain.Features.Follows.Models.ValueObjects;
using InstaConnect.Follows.Domain.Features.Users.Models.Requests;
using InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

namespace InstaConnect.Follows.Infrastructure.Tests.Features.Follows.Utilities;

public static class FollowMockSetups
{
	extension(IFollowCollection collection)
	{
		public void SetupAggregateFluent(
			FollowId id,
			IFollowFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}

		public void SetupAggregateFluent(
			FollowId id,
			CurrentUserQuery currentUserQuery,
			IFollowFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}

		public void SetupAggregateFluent(
			FollowsFilterQuery filterQuery,
			FollowsSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IFollowFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}

		public void SetupAggregateFluent(
			FollowsFilterQuery filterQuery,
			IFollowFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}

		public void SetupAggregateFluent(
			FollowsForFollowingFilterQuery filterQuery,
			FollowsForFollowingSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IFollowFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}

		public void SetupAggregateFluent(
			FollowsForFollowingFilterQuery filterQuery,
			IFollowFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}
	}

	extension(IFollowFluent fluent)
	{
		public void SetupGetCountAsync(
			FollowsFilterQuery filterQuery,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			fluent.GetCountAsync(cancellationToken).ReturnsTaskResponse(follows.ToTotalCountResponse(filterQuery));
		}

		public void SetupGetCountAsync(
			FollowsForFollowingFilterQuery filterQuery,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			fluent.GetCountAsync(cancellationToken).ReturnsTaskResponse(follows.ToTotalCountResponse(filterQuery));
		}

		public void SetupAnyAsync(
			FollowId id,
			Follow? follow,
			CancellationToken cancellationToken)
		{
			fluent.AnyAsync(cancellationToken).ReturnsTaskResponse(follow != null);
		}

		public void SetupApplyIncludes(
			FollowId id,
			FollowInclude include)
		{
			fluent.ApplyIncludes(include).ReturnsResponse(fluent);
		}

		public void SetupApplyIncludes(
			FollowId id,
			CurrentUserQuery currentUserQuery,
			FollowInclude include)
		{
			fluent.ApplyIncludes(include).ReturnsResponse(fluent);
		}

		public void SetupApplyIncludes(
			FollowsFilterQuery filterQuery,
			FollowInclude include)
		{
			fluent.ApplyIncludes(include).ReturnsResponse(fluent);
		}

		public void SetupApplyIncludes(
			FollowsForFollowingFilterQuery filterQuery,
			FollowInclude include)
		{
			fluent.ApplyIncludes(include).ReturnsResponse(fluent);
		}

		public void SetupApplyIncludes(
			FollowsFilterQuery filterQuery,
			FollowsSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			FollowInclude include)
		{
			fluent.ApplyIncludes(include).ReturnsResponse(fluent);
		}

		public void SetupApplyIncludes(
			FollowsForFollowingFilterQuery filterQuery,
			FollowsForFollowingSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			FollowInclude include)
		{
			fluent.ApplyIncludes(include).ReturnsResponse(fluent);
		}

		public void SetupMatch(FollowId id)
		{
			fluent.Match(id).ReturnsResponse(fluent);
		}

		public void SetupMatch(
			FollowId id,
			CurrentUserQuery currentUserQuery)
		{
			fluent.Match(id).ReturnsResponse(fluent);
		}

		public void SetupMatch(FollowsFilterQuery filterQuery)
		{
			fluent.Match(filterQuery).ReturnsResponse(fluent);
		}

		public void SetupMatch(FollowsForFollowingFilterQuery filterQuery)
		{
			fluent.Match(filterQuery).ReturnsResponse(fluent);
		}

		public void SetupMatch(
			FollowsFilterQuery filterQuery,
			FollowsSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.Match(filterQuery).ReturnsResponse(fluent);
		}

		public void SetupMatch(
			FollowsForFollowingFilterQuery filterQuery,
			FollowsForFollowingSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.Match(filterQuery).ReturnsResponse(fluent);
		}

		public void SetupProjectToFullResponse(
			FollowId id,
			CurrentUserQuery currentUserQuery,
			IFollowResponseFluent responseFluent)
		{
			fluent.ProjectToFullResponse(currentUserQuery).ReturnsResponse(responseFluent);
		}

		public void SetupProjectToResponseWithoutFollower(
			FollowsFilterQuery filterQuery,
			FollowsSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IFollowResponseFluent responseFluent)
		{
			fluent.ProjectToResponseWithoutFollower(currentUserQuery).ReturnsResponse(responseFluent);
		}

		public void SetupProjectToResponseWithoutFollowing(
			FollowsForFollowingFilterQuery filterQuery,
			FollowsForFollowingSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IFollowResponseFluent responseFluent)
		{
			fluent.ProjectToResponseWithoutFollowing(currentUserQuery).ReturnsResponse(responseFluent);
		}

		public void SetupFirstOrDefaultAsync(
			FollowId id,
			Follow follow,
			CancellationToken cancellationToken)
		{
			fluent.FirstOrDefaultAsync(cancellationToken).ReturnsTaskResponse(follow);
		}
	}

	extension(IFollowResponseFluent fluent)
	{
		public void SetupApplySorting(
			FollowsFilterQuery filterQuery,
			FollowsSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ApplySorting(sortingQuery).ReturnsResponse(fluent);
		}

		public void SetupApplySorting(
			FollowsForFollowingFilterQuery filterQuery,
			FollowsForFollowingSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ApplySorting(sortingQuery).ReturnsResponse(fluent);
		}

		public void SetupApplyPagination(
			FollowsFilterQuery filterQuery,
			FollowsSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ApplyPagination(paginationQuery).ReturnsResponse(fluent);
		}

		public void SetupApplyPagination(
			FollowsForFollowingFilterQuery filterQuery,
			FollowsForFollowingSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ApplyPagination(paginationQuery).ReturnsResponse(fluent);
		}

		public void SetupToListAsync(
			FollowsFilterQuery filterQuery,
			FollowsSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			fluent.ToListAsync(cancellationToken).ReturnsTaskResponse(follows.ToResponse(filterQuery, paginationQuery, currentUserQuery));
		}

		public void SetupToListAsync(
			FollowsForFollowingFilterQuery filterQuery,
			FollowsForFollowingSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			fluent.ToListAsync(cancellationToken).ReturnsTaskResponse(follows.ToResponse(filterQuery, paginationQuery, currentUserQuery));
		}

		public void SetupFirstOrDefaultAsync(
			FollowId id,
			CurrentUserQuery currentUserQuery,
			Follow follow,
			CancellationToken cancellationToken)
		{
			fluent.FirstOrDefaultAsync(cancellationToken).ReturnsTaskResponse(follow.ToResponse(id, currentUserQuery));
		}
	}
}
