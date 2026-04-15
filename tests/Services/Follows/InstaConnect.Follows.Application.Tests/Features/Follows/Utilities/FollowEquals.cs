using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Application.Tests.Utilities;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Follows.Application.Features.Follows.Models;
using InstaConnect.Follows.Application.Features.Users.Abstractions;
using InstaConnect.Follows.Application.Tests.Features.Follows.Utilities;
using InstaConnect.Follows.Application.Tests.Features.Users.Utilities;

namespace InstaConnect.Follows.Application.Tests.Features.Follows.Utilities;

public static class FollowEquals
{
    extension(GetAllFollowsQuery query)
    {
        public bool Matches(GetAllFollowsQueryRequest request)
        {
            return query.MatchesFilter(request) &&
                   query.MatchesSortable<GetAllFollowsQuery, FollowsSortTerm, FollowsSortingQuery, GetAllFollowsQueryRequest>(request) &&
                   query.MatchesPaginatable<GetAllFollowsQuery, FollowsPaginationQuery, GetAllFollowsQueryRequest>(request) &&
                   query.MatchesCurrentUserable(request);
        }

        public bool MatchesFilter(GetAllFollowsQueryRequest request)
        {
            return query.Filter.FollowerId.Matches(request.FollowerId) &&
                   query.Filter.FollowingName.Matches(request.FollowingName);
        }
    }

    extension(GetAllFollowsForFollowingQuery query)
    {
        public bool Matches(GetAllFollowsForFollowingQueryRequest request)
        {
            return query.MatchesFilter(request) &&
                   query.MatchesSortable<GetAllFollowsForFollowingQuery, FollowsForFollowingSortTerm, FollowsForFollowingSortingQuery, GetAllFollowsForFollowingQueryRequest>(request) &&
                   query.MatchesPaginatable<GetAllFollowsForFollowingQuery, FollowsPaginationQuery, GetAllFollowsForFollowingQueryRequest>(request) &&
                   query.MatchesCurrentUserable(request);
        }

        public bool MatchesFilter(GetAllFollowsForFollowingQueryRequest request)
        {
            return query.Filter.FollowingId.Matches(request.FollowingId) &&
                   query.Filter.FollowerName.Matches(request.FollowerName);
        }
    }

    extension(GetFollowByIdQuery query)
    {
        public bool Matches(GetFollowByIdQueryRequest request)
        {
            return query.Id.Matches(request.FollowerId, request.FollowingId) &&
                   query.MatchesCurrentUserable(request);
        }
    }

    extension(AddFollowCommand command)
    {
        public bool Matches(AddFollowCommandRequest request)
        {
            return command.FollowerId.Matches(request.FollowerId) &&
                   command.FollowingId.Matches(request.FollowingId);
        }
    }

    extension(DeleteFollowCommand command)
    {
        public bool Matches(DeleteFollowCommandRequest request)
        {
            return command.Id.Matches(request.FollowerId, request.FollowingId);
        }
    }

    extension(AddFollowCommandResponse response)
    {
        public bool Matches(
        Follow follow,
        AddFollowCommandRequest request)
        {
            return response.Id.Matches(follow.Id);
        }
    }

    extension(GetFollowByIdQueryResponse response)
    {
        public bool Matches(Follow follow, GetFollowByIdQueryRequest request)
        {
            return response.Follow.MatchesFull(follow, request);
        }
    }

    extension(GetAllFollowsQueryResponse response)
    {
        public bool Matches(
        User follower,
        ICollection<Follow> follows,
        GetAllFollowsQueryRequest request)
        {
            return response.FollowCollection.MatchesWithoutFollowing(
                       (response, follow) => response.MatchesWithoutFollower(follow, request),
                       follow => follow.MatchesFilter(request),
                       follower,
                       follows,
                       request);
        }

        public bool Matches(
            User follower,
            ICollection<Follow> follows,
            GetAllFollowsQueryRequest request,
            ISortEnumTermTransformer<Follow> termTransformer)
        {
            return response.FollowCollection.MatchesWithoutFollowing(
                       (response, follow) => response.MatchesWithoutFollower(follow, request),
                       follow => follow.MatchesFilter(request),
                       follower,
                       follows,
                       request,
                       termTransformer);
        }
    }

    extension(GetAllFollowsForFollowingQueryResponse response)
    {
        public bool Matches(
        User following,
        ICollection<Follow> follows,
        GetAllFollowsForFollowingQueryRequest request)
        {
            return response.FollowCollection.MatchesWithoutFollower(
                       (response, follow) => response.MatchesWithoutFollowing(follow, request),
                       follow => follow.MatchesFilter(request),
                       following,
                       follows,
                       request);
        }

        public bool Matches(
            User following,
            ICollection<Follow> follows,
            GetAllFollowsForFollowingQueryRequest request,
            ISortEnumTermTransformer<Follow> termTransformer)
        {
            return response.FollowCollection.MatchesWithoutFollower(
                       (response, follow) => response.MatchesWithoutFollowing(follow, request),
                       follow => follow.MatchesFilter(request),
                       following,
                       follows,
                       request,
                       termTransformer);
        }
    }

    extension(Follow follow)
    {
        public bool Matches(AddFollowCommandRequest request)
        {
            return follow.Id.Matches(request.FollowerId, request.FollowingId);
        }

        public bool MatchesFilter(GetAllFollowsQueryRequest request)
        {
            return follow.Id.FollowerId.Id.EqualsOrdinalIgnoreCase(request.FollowerId) &&
                   follow.Following != null &&
                   follow.Following.Name.Value.StartsWithOrdinalIgnoreCase(request.FollowingName);
        }

        public bool MatchesFilter(GetAllFollowsForFollowingQueryRequest request)
        {
            return follow.Id.FollowingId.Id.EqualsOrdinalIgnoreCase(request.FollowingId) &&
                   follow.Follower != null &&
                   follow.Follower.Name.Value.StartsWithOrdinalIgnoreCase(request.FollowerName);
        }
    }

    extension(FollowIdCommandResponse response)
    {
        public bool Matches(FollowId id)
        {
            return id.Matches(response.FollowerId, response.FollowingId);
        }
    }

    extension(FollowQueryResponse? response)
    {
        public bool MatchesFull<TRequest>(Follow? follow, TRequest request)
        where TRequest : ICurrentUserableQueryRequest
        {
            return response != null &&
                   follow != null &&
                   follow.Id.Matches(response.FollowerId, response.FollowingId) &&
                   response.IsFollowedByCurrentUser == follow.Id.FollowerId.Matches(request.CurrentUserId) &&
                   follow.CreatedAtUtc == response.CreatedAtUtc &&
                   response.Following.MatchesFull(follow.Following) &&
                   response.Follower.MatchesFull(follow.Follower);
        }

        public bool MatchesWithoutFollowing<TRequest>(Follow? follow, TRequest request)
            where TRequest : ICurrentUserableQueryRequest
        {
            return response != null &&
                   follow != null &&
                   follow.Id.Matches(response.FollowerId, response.FollowingId) &&
                   response.IsFollowedByCurrentUser == follow.Id.FollowerId.Matches(request.CurrentUserId) &&
                   follow.CreatedAtUtc == response.CreatedAtUtc &&
                   response.Following == null &&
                   response.Follower.MatchesFull(follow.Follower);
        }

        public bool MatchesWithoutFollower<TRequest>(Follow? follow, TRequest request)
            where TRequest : ICurrentUserableQueryRequest
        {
            return response != null &&
                   follow != null &&
                   follow.Id.Matches(response.FollowerId, response.FollowingId) &&
                   response.IsFollowedByCurrentUser == follow.Id.FollowerId.Matches(request.CurrentUserId) &&
                   follow.CreatedAtUtc == response.CreatedAtUtc &&
                   response.Following.MatchesFull(follow.Following) &&
                   response.Follower == null;
        }
    }

    extension(FollowCollectionQueryResponse response)
    {
        public bool MatchesWithoutFollowing<TRequest>(
        Func<FollowQueryResponse, Follow, bool> matches,
        Func<Follow, bool> matchesFilter,
        User follower,
        ICollection<Follow> follows,
        TRequest request)
        where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
        {
            return response.MatchesCollectionResponse(follows.Count(matchesFilter), request) &&
                   response.Following == null &&
                   response.Follower.MatchesFull(follower) &&
                   response.Follows.MatchesCollection(follows,
                                                        response => new(new(response.FollowerId), new(response.FollowingId)),
                                                        follow => follow.Id,
                                                        matches,
                                                        request,
                                                        matchesFilter);
        }

        public bool MatchesWithoutFollowing<TRequest>(
            Func<FollowQueryResponse, Follow, bool> matches,
            Func<Follow, bool> matchesFilter,
            User follower,
            ICollection<Follow> follows,
            TRequest request,
            ISortEnumTermTransformer<Follow> termTransformer)
            where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
        {
            return response.MatchesCollectionResponse(follows.Count(matchesFilter), request) &&
                   response.Following == null &&
                   response.Follower.MatchesFull(follower) &&
                   response.Follows.MatchesSortedCollection(follows,
                                                              matches,
                                                              termTransformer,
                                                              request,
                                                              matchesFilter);
        }

        public bool MatchesWithoutFollower<TRequest>(
            Func<FollowQueryResponse, Follow, bool> matches,
            Func<Follow, bool> matchesFilter,
            User following,
            ICollection<Follow> follows,
            TRequest request)
            where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
        {
            return response.MatchesCollectionResponse(follows.Count(matchesFilter), request) &&
                   response.Following.MatchesFull(following) &&
                   response.Follower == null &&
                   response.Follows.MatchesCollection(follows,
                                                        response => new(new(response.FollowerId), new(response.FollowingId)),
                                                        follow => follow.Id,
                                                        matches,
                                                        request,
                                                        matchesFilter);
        }

        public bool MatchesWithoutFollower<TRequest>(
            Func<FollowQueryResponse, Follow, bool> matches,
            Func<Follow, bool> matchesFilter,
            User following,
            ICollection<Follow> follows,
            TRequest request,
            ISortEnumTermTransformer<Follow> termTransformer)
            where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
        {
            return response.MatchesCollectionResponse(follows.Count(matchesFilter), request) &&
                   response.Following.MatchesFull(following) &&
                   response.Follower == null &&
                   response.Follows.MatchesSortedCollection(follows,
                                                              matches,
                                                              termTransformer,
                                                              request,
                                                              matchesFilter);
        }
    }
}
