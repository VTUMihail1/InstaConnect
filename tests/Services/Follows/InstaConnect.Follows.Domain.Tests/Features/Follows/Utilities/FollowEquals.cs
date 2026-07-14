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
		Follow follow,
		AddFollowCommand command)
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
				   entity.Follower != null && entity.Follower.Matches(r.Follow.Follower) &&
				   entity.Following != null && entity.Following.Matches(r.Follow.Following) &&
				   entity.CreatedAtUtc == r.Follow.CreatedAtUtc;
		}
	}

	extension(FollowDeletedEventRequest r)
	{
		public bool Matches(DeleteFollowCommand command, Follow entity)
		{
			return command.Id.Matches(r.Follow.FollowerId, r.Follow.FollowingId) &&
				   entity.Follower != null && entity.Follower.Matches(r.Follow.Follower) &&
				   entity.Following != null && entity.Following.Matches(r.Follow.Following) &&
				   entity.CreatedAtUtc == r.Follow.CreatedAtUtc;
		}
	}

	extension(FollowAddedNotificationRequest r)
	{
		public bool Matches(AddFollowCommand command, Follow entity)
		{
			return command.FollowerId.Matches(r.Follow.FollowerId) &&
				   command.FollowingId.Matches(r.Follow.FollowingId) &&
				   entity.Follower != null && entity.Follower.Matches(r.Follow.Follower) &&
				   entity.Following != null && entity.Following.Matches(r.Follow.Following) &&
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
		public bool MatchesFull<T>(Follow? follow, T request)
		where T : ICurrentUserableQuery
		{
			return response != null &&
				   follow != null &&
				   follow.Id.Matches(response.Id) &&
				   response.IsFollowedByCurrentUser == follow.Id.FollowerId.Matches(request.CurrentUser.Id) &&
				   follow.CreatedAtUtc == response.CreatedAtUtc &&
				   response.Following.MatchesFull(follow.Following) &&
				   response.Follower.MatchesFull(follow.Follower);
		}

		public bool MatchesWithoutFollowing<T>(Follow? follow, T request)
			where T : ICurrentUserableQuery
		{
			return response != null &&
				   follow != null &&
				   follow.Id.Matches(response.Id) &&
				   response.IsFollowedByCurrentUser == follow.Id.FollowerId.Matches(request.CurrentUser.Id) &&
				   follow.CreatedAtUtc == response.CreatedAtUtc &&
				   response.Following == null &&
				   response.Follower.MatchesFull(follow.Follower);
		}

		public bool MatchesWithoutFollower<T>(Follow? follow, T request)
			where T : ICurrentUserableQuery
		{
			return response != null &&
				   follow != null &&
				   follow.Id.Matches(response.Id) &&
				   response.IsFollowedByCurrentUser == follow.Id.FollowerId.Matches(request.CurrentUser.Id) &&
				   follow.CreatedAtUtc == response.CreatedAtUtc &&
				   response.Following.MatchesFull(follow.Following) &&
				   response.Follower == null;
		}

		public bool Matches(Follow follow, GetFollowByIdQuery query)
		{
			return response.MatchesFull(follow, query);
		}
	}

	extension(FollowCollectionResponse response)
	{
		public bool MatchesWithoutFollowing<T>(
		Func<FollowResponse, Follow, bool> matches,
		Func<Follow, bool> matchesFilter,
		User follower,
		ICollection<Follow> follows,
		T request)
		where T : ICurrentUserableQuery, IPaginatableQuery<FollowsPaginationQuery>
		{
			return response.MatchesCollectionResponse(follows.Count(matchesFilter), request.Pagination) &&
				   response.Following == null &&
				   response.Follower.MatchesFull(follower) &&
				   response.Follows.MatchesCollection(follows,
													response => response.Id,
													follow => follow.Id,
													matches,
													request.Pagination,
													matchesFilter);
		}

		public bool MatchesWithoutFollowing<T>(
			Func<FollowResponse, Follow, bool> matches,
			Func<Follow, bool> matchesFilter,
			User follower,
			ICollection<Follow> follows,
			T request,
			ISortEnumTermTransformer<Follow> termTransformer)
			where T : ICurrentUserableQuery, IPaginatableQuery<FollowsPaginationQuery>
		{
			return response.MatchesCollectionResponse(follows.Count(matchesFilter), request.Pagination) &&
				   response.Following == null &&
				   response.Follower.MatchesFull(follower) &&
				   response.Follows.MatchesSortedCollection(follows,
														  matches,
														  termTransformer,
														  request.Pagination,
														  matchesFilter);
		}

		public bool MatchesWithoutFollower<T>(
			Func<FollowResponse, Follow, bool> matches,
			Func<Follow, bool> matchesFilter,
			User following,
			ICollection<Follow> follows,
			T request)
			where T : ICurrentUserableQuery, IPaginatableQuery<FollowsPaginationQuery>
		{
			return response.MatchesCollectionResponse(follows.Count(matchesFilter), request.Pagination) &&
				   response.Following.MatchesFull(following) &&
				   response.Follower == null &&
				   response.Follows.MatchesCollection(follows,
													response => response.Id,
													follow => follow.Id,
													matches,
													request.Pagination,
													matchesFilter);
		}

		public bool MatchesWithoutFollower<T>(
			Func<FollowResponse, Follow, bool> matches,
			Func<Follow, bool> matchesFilter,
			User following,
			ICollection<Follow> follows,
			T request,
			ISortEnumTermTransformer<Follow> termTransformer)
			where T : ICurrentUserableQuery, IPaginatableQuery<FollowsPaginationQuery>
		{
			return response.MatchesCollectionResponse(follows.Count(matchesFilter), request.Pagination) &&
				   response.Following.MatchesFull(following) &&
				   response.Follower == null &&
				   response.Follows.MatchesSortedCollection(follows,
														  matches,
														  termTransformer,
														  request.Pagination,
														  matchesFilter);
		}

		public bool Matches(
		User follower,
		ICollection<Follow> follows,
		GetAllFollowsQuery query)
		{
			return response.MatchesWithoutFollowing(
					   (response, follow) => response.MatchesWithoutFollower(follow, query),
					   follow => follow.MatchesFilter(query.Filter),
					   follower,
					   follows,
					   query);
		}

		public bool Matches(
			User follower,
			ICollection<Follow> follows,
			GetAllFollowsQuery query,
			ISortEnumTermTransformer<Follow> termTransformer)
		{
			return response.MatchesWithoutFollowing(
					   (response, follow) => response.MatchesWithoutFollower(follow, query),
					   follow => follow.MatchesFilter(query.Filter),
					   follower,
					   follows,
					   query,
					   termTransformer);
		}

		public bool Matches(
		User following,
		ICollection<Follow> follows,
		GetAllFollowsForFollowingQuery query)
		{
			return response.MatchesWithoutFollower(
					   (response, follow) => response.MatchesWithoutFollowing(follow, query),
					   follow => follow.MatchesFilter(query.Filter),
					   following,
					   follows,
					   query);
		}

		public bool Matches(
			User following,
			ICollection<Follow> follows,
			GetAllFollowsForFollowingQuery query,
			ISortEnumTermTransformer<Follow> termTransformer)
		{
			return response.MatchesWithoutFollower(
					   (response, follow) => response.MatchesWithoutFollowing(follow, query),
					   follow => follow.MatchesFilter(query.Filter),
					   following,
					   follows,
					   query,
					   termTransformer);
		}
	}
}
