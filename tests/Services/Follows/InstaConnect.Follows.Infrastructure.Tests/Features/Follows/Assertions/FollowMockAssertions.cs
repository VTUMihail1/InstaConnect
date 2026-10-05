using InstaConnect.Follows.Domain.Features.Follows.Models.Entities;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;
using InstaConnect.Follows.Domain.Features.Follows.Models.ValueObjects;
using InstaConnect.Follows.Domain.Features.Users.Models.Requests;
using InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

namespace InstaConnect.Follows.Infrastructure.Tests.Features.Follows.Assertions;

public static class FollowMockAssertions
{
	extension(IFollowCollection collection)
	{
		public void ShouldHaveReceivedOneAggregateFluent(FollowId id)
		{
			collection.ShouldHaveReceivedOne().AggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(
			FollowId id,
			CurrentUserQuery currentUserQuery)
		{
			collection.ShouldHaveReceivedOne().AggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(FollowsFilterQuery filterQuery)
		{
			collection.ShouldHaveReceivedOne().AggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(FollowsForFollowingFilterQuery filterQuery)
		{
			collection.ShouldHaveReceivedOne().AggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(
			FollowsFilterQuery filterQuery,
			FollowsSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			collection.ShouldHaveReceivedOne().AggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(
			FollowsForFollowingFilterQuery filterQuery,
			FollowsForFollowingSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			collection.ShouldHaveReceivedOne().AggregateFluent();
		}

		public async Task ShouldHaveReceivedOneAddAsync(
			Follow follow,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().AddAsync(follow, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			Follow follow,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().DeleteAsync(follow, cancellationToken);
		}
	}

	extension(IFollowFluent fluent)
	{
		public void ShouldHaveReceivedOneMatch(FollowsFilterQuery filterQuery)
		{
			fluent.ShouldHaveReceivedOne().Match(filterQuery);
		}

		public void ShouldHaveReceivedOneMatch(FollowsForFollowingFilterQuery filterQuery)
		{
			fluent.ShouldHaveReceivedOne().Match(filterQuery);
		}

		public void ShouldHaveReceivedOneMatch(
			FollowsFilterQuery filterQuery,
			FollowsSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOne().Match(filterQuery);
		}

		public void ShouldHaveReceivedOneMatch(
			FollowsForFollowingFilterQuery filterQuery,
			FollowsForFollowingSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOne().Match(filterQuery);
		}

		public void ShouldHaveReceivedOneMatch(FollowId id)
		{
			fluent.ShouldHaveReceivedOne().Match(id);
		}

		public void ShouldHaveReceivedOneMatch(
			FollowId id,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOne().Match(id);
		}

		public void ShouldHaveReceivedOneApplyIncludes(
			FollowId id,
			FollowInclude include)
		{
			fluent.ShouldHaveReceivedOne().ApplyIncludes(include);
		}

		public void ShouldHaveReceivedOneApplyIncludes(
			FollowId id,
			CurrentUserQuery currentUserQuery,
			FollowInclude include)
		{
			fluent.ShouldHaveReceivedOne().ApplyIncludes(include);
		}

		public void ShouldHaveReceivedOneApplyIncludes(
			FollowsFilterQuery filterQuery,
			FollowInclude include)
		{
			fluent.ShouldHaveReceivedOne().ApplyIncludes(include);
		}

		public void ShouldHaveReceivedOneApplyIncludes(
			FollowsForFollowingFilterQuery filterQuery,
			FollowInclude include)
		{
			fluent.ShouldHaveReceivedOne().ApplyIncludes(include);
		}

		public void ShouldHaveReceivedOneApplyIncludes(
			FollowsFilterQuery filterQuery,
			FollowsSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			FollowInclude include)
		{
			fluent.ShouldHaveReceivedOne().ApplyIncludes(include);
		}

		public void ShouldHaveReceivedOneApplyIncludes(
			FollowsForFollowingFilterQuery filterQuery,
			FollowsForFollowingSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			FollowInclude include)
		{
			fluent.ShouldHaveReceivedOne().ApplyIncludes(include);
		}

		public void ShouldHaveReceivedOneProjectToFullResponse(
			FollowId id,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOne().ProjectToFullResponse(currentUserQuery);
		}

		public void ShouldHaveReceivedOneProjectToResponseWithoutFollower(
			FollowsFilterQuery filterQuery,
			FollowsSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOne().ProjectToResponseWithoutFollower(currentUserQuery);
		}

		public void ShouldHaveReceivedOneProjectToResponseWithoutFollowing(
			FollowsForFollowingFilterQuery filterQuery,
			FollowsForFollowingSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOne().ProjectToResponseWithoutFollowing(currentUserQuery);
		}

		public async Task ShouldHaveReceivedOneAnyAsync(
			FollowId id,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOne().AnyAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetCountAsync(
			FollowsFilterQuery filterQuery,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOne().GetCountAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetCountAsync(
			FollowsForFollowingFilterQuery filterQuery,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOne().GetCountAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneFirstOrDefaultAsync(
			FollowId id,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOne().FirstOrDefaultAsync(cancellationToken);
		}
	}

	extension(IFollowResponseFluent fluent)
	{
		public void ShouldHaveReceivedOneApplySorting(
			FollowsFilterQuery filterQuery,
			FollowsSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOne().ApplySorting(sortingQuery);
		}

		public void ShouldHaveReceivedOneApplySorting(
			FollowsForFollowingFilterQuery filterQuery,
			FollowsForFollowingSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOne().ApplySorting(sortingQuery);
		}

		public void ShouldHaveReceivedOneApplyPagination(
			FollowsFilterQuery filterQuery,
			FollowsSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOne().ApplyPagination(paginationQuery);
		}

		public void ShouldHaveReceivedOneApplyPagination(
			FollowsForFollowingFilterQuery filterQuery,
			FollowsForFollowingSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOne().ApplyPagination(paginationQuery);
		}

		public async Task ShouldHaveReceivedOneFirstOrDefaultAsync(
			FollowId id,
			CurrentUserQuery currentUserQuery,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOne().FirstOrDefaultAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneToListAsync(
			FollowsFilterQuery filterQuery,
			FollowsSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOne().ToListAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneToListAsync(
			FollowsForFollowingFilterQuery filterQuery,
			FollowsForFollowingSortingQuery sortingQuery,
			FollowsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOne().ToListAsync(cancellationToken);
		}
	}
}
