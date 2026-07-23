using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Domain.Features.Messaging.Abstractions;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Follows.Domain.Tests.Features.Users.Utilities;
using InstaConnect.Follows.Events.Features.Follows;

namespace InstaConnect.Follows.Domain.Tests.Features.Follows.Utilities;

public static class FollowEquals
{
	extension(FollowId response)
	{
		public bool Matches(
		AddFollowCommand command,
		Follow follow)
		{
			return response.Matches(follow.Id);
		}
	}

	extension(FollowInclude p)
	{
		public bool Matches(DeleteFollowCommand command, FollowInclude include)
		{
			return p.Matches(include);
		}
	}

	extension(FollowAddedEventRequest r)
	{
		public bool Matches(AddFollowCommand command, Follow entity)
		{
			return command.FollowerId.Matches(r.Follow.FollowerId) &&
				   command.FollowingId.Matches(r.Follow.FollowingId) &&
				   entity.Follower.Matches(r.Follow.Follower) &&
				   entity.Following.Matches(r.Follow.Following) &&
				   entity.CreatedAtUtc == r.Follow.CreatedAtUtc;
		}
	}

	extension(FollowDeletedEventRequest r)
	{
		public bool Matches(DeleteFollowCommand command, Follow entity)
		{
			return command.Id.Matches(r.Follow.FollowerId, r.Follow.FollowingId) &&
				   entity.Follower.Matches(r.Follow.Follower) &&
				   entity.Following.Matches(r.Follow.Following) &&
				   entity.CreatedAtUtc == r.Follow.CreatedAtUtc;
		}
	}

	extension(FollowAddedNotificationRequest r)
	{
		public bool Matches(AddFollowCommand command, Follow entity)
		{
			return command.FollowerId.Matches(r.Follow.FollowerId) &&
				   command.FollowingId.Matches(r.Follow.FollowingId) &&
				   entity.Follower.Matches(r.Follow.Follower) &&
				   entity.Following.Matches(r.Follow.Following) &&
				   entity.CreatedAtUtc == r.Follow.CreatedAtUtc;
		}
	}

	extension(Follow follow)
	{
		public bool Matches(AddFollowCommand command)
		{
			return follow.Id.Matches(command.FollowerId.Id, command.FollowingId.Id);
		}

		public bool Matches(DeleteFollowCommand command)
		{
			return follow.Id.Matches(command.Id);
		}

		public bool MatchesFilter(FollowsFilterQuery query)
		{
			return follow.Id.FollowerId.Matches(query.FollowerId) &&
				   follow.Following != null &&
				   follow.Following.Name.Value.StartsWithOrdinalIgnoreCase(query.FollowingName.Value);
		}

		public bool MatchesFilter(FollowsForFollowingFilterQuery query)
		{
			return follow.Id.FollowingId.Matches(query.FollowingId) &&
				   follow.Follower != null &&
				   follow.Follower.Name.Value.StartsWithOrdinalIgnoreCase(query.FollowerName.Value);
		}
	}

	extension(FollowResponse? response)
	{
		public bool MatchesFull<TQuery>(TQuery request, Follow? follow)
		where TQuery : ICurrentUserableQuery
		{
			return response != null &&
				   follow != null &&
				   follow.Id.Matches(response.Id) &&
				   response.IsFollowedByCurrentUser == follow.Id.FollowerId.Matches(request.CurrentUser.Id) &&
				   follow.CreatedAtUtc == response.CreatedAtUtc &&
				   response.Following.MatchesFull(follow.Following) &&
				   response.Follower.MatchesFull(follow.Follower);
		}

		public bool MatchesWithoutFollowing<TQuery>(TQuery request, Follow? follow)
			where TQuery : ICurrentUserableQuery
		{
			return response != null &&
				   follow != null &&
				   follow.Id.Matches(response.Id) &&
				   response.IsFollowedByCurrentUser == follow.Id.FollowerId.Matches(request.CurrentUser.Id) &&
				   follow.CreatedAtUtc == response.CreatedAtUtc &&
				   response.Following == null &&
				   response.Follower.MatchesFull(follow.Follower);
		}

		public bool MatchesWithoutFollower<TQuery>(TQuery request, Follow? follow)
			where TQuery : ICurrentUserableQuery
		{
			return response != null &&
				   follow != null &&
				   follow.Id.Matches(response.Id) &&
				   response.IsFollowedByCurrentUser == follow.Id.FollowerId.Matches(request.CurrentUser.Id) &&
				   follow.CreatedAtUtc == response.CreatedAtUtc &&
				   response.Following.MatchesFull(follow.Following) &&
				   response.Follower == null;
		}

		public bool Matches(GetFollowByIdQuery query, Follow follow)
		{
			return response.MatchesFull(query, follow);
		}
	}

	extension(FollowCollectionResponse response)
	{
		public bool MatchesWithoutFollowing<TQuery>(
		TQuery request,
		Func<FollowResponse, Follow, bool> matches,
		Func<Follow, bool> matchesFilter,
		User follower,
		ICollection<Follow> follows)
		where TQuery : ICurrentUserableQuery, IPaginatableQuery<FollowsPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, follows.Count(matchesFilter)) &&
				   response.Following == null &&
				   response.Follower.MatchesFull(follower) &&
				   response.Follows.MatchesCollection(request.Pagination,
													follows,
													response => response.Id,
													follow => follow.Id,
													matches,
													matchesFilter);
		}

		public bool MatchesWithoutFollowing<TQuery>(
			TQuery request,
			Func<FollowResponse, Follow, bool> matches,
			Func<Follow, bool> matchesFilter,
			User follower,
			ICollection<Follow> follows,
			ISortEnumTermTransformer<Follow> termTransformer)
			where TQuery : ICurrentUserableQuery, IPaginatableQuery<FollowsPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, follows.Count(matchesFilter)) &&
				   response.Following == null &&
				   response.Follower.MatchesFull(follower) &&
				   response.Follows.MatchesSortedCollection(request.Pagination,
														  follows,
														  matches,
														  termTransformer,
														  matchesFilter);
		}

		public bool MatchesWithoutFollower<TQuery>(
			TQuery request,
			Func<FollowResponse, Follow, bool> matches,
			Func<Follow, bool> matchesFilter,
			User following,
			ICollection<Follow> follows)
			where TQuery : ICurrentUserableQuery, IPaginatableQuery<FollowsPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, follows.Count(matchesFilter)) &&
				   response.Following.MatchesFull(following) &&
				   response.Follower == null &&
				   response.Follows.MatchesCollection(request.Pagination,
													follows,
													response => response.Id,
													follow => follow.Id,
													matches,
													matchesFilter);
		}

		public bool MatchesWithoutFollower<TQuery>(
			TQuery request,
			Func<FollowResponse, Follow, bool> matches,
			Func<Follow, bool> matchesFilter,
			User following,
			ICollection<Follow> follows,
			ISortEnumTermTransformer<Follow> termTransformer)
			where TQuery : ICurrentUserableQuery, IPaginatableQuery<FollowsPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, follows.Count(matchesFilter)) &&
				   response.Following.MatchesFull(following) &&
				   response.Follower == null &&
				   response.Follows.MatchesSortedCollection(request.Pagination,
														  follows,
														  matches,
														  termTransformer,
														  matchesFilter);
		}

		public bool Matches(
		GetAllFollowsQuery query,
		User follower,
		ICollection<Follow> follows)
		{
			return response.MatchesWithoutFollowing(
					   query,
					   (response, follow) => response.MatchesWithoutFollower(query, follow),
					   follow => follow.MatchesFilter(query.Filter),
					   follower,
					   follows);
		}

		public bool Matches(
			GetAllFollowsQuery query,
			User follower,
			ICollection<Follow> follows,
			ISortEnumTermTransformer<Follow> termTransformer)
		{
			return response.MatchesWithoutFollowing(
					   query,
					   (response, follow) => response.MatchesWithoutFollower(query, follow),
					   follow => follow.MatchesFilter(query.Filter),
					   follower,
					   follows,
					   termTransformer);
		}

		public bool Matches(
		GetAllFollowsForFollowingQuery query,
		User following,
		ICollection<Follow> follows)
		{
			return response.MatchesWithoutFollower(
					   query,
					   (response, follow) => response.MatchesWithoutFollowing(query, follow),
					   follow => follow.MatchesFilter(query.Filter),
					   following,
					   follows);
		}

		public bool Matches(
			GetAllFollowsForFollowingQuery query,
			User following,
			ICollection<Follow> follows,
			ISortEnumTermTransformer<Follow> termTransformer)
		{
			return response.MatchesWithoutFollower(
					   query,
					   (response, follow) => response.MatchesWithoutFollowing(query, follow),
					   follow => follow.MatchesFilter(query.Filter),
					   following,
					   follows,
					   termTransformer);
		}
	}
}
