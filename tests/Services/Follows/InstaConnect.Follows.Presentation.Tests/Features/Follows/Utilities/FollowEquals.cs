using InstaConnect.Common.Presentation.Abstractions;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;
using InstaConnect.Follows.Presentation.Features.Users.Abstractions;
using InstaConnect.Follows.Presentation.Tests.Features.Follows.Utilities;
using InstaConnect.Follows.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Follows.Presentation.Tests.Features.Follows.Utilities;

public static class FollowEquals
{
    extension(GetAllFollowsQueryRequest query)
    {
        public bool Matches(GetAllFollowsApiRequest request)
        {
            return query.MatchesFilter(request) &&
                   query.MatchesSortable<GetAllFollowsQueryRequest, FollowsSortTerm, GetAllFollowsApiRequest>(request) &&
                   query.MatchesPaginatable(request) &&
                   query.MatchesCurrentUserable(request);
        }

        public bool MatchesFilter(GetAllFollowsApiRequest request)
        {
            return query.FollowerId == request.FollowerId &&
                   query.FollowingName == request.FollowingName;
        }
    }

    extension(GetAllFollowsForFollowingQueryRequest query)
    {
        public bool Matches(GetAllFollowsForFollowingApiRequest request)
        {
            return query.MatchesFilter(request) &&
                   query.MatchesSortable<GetAllFollowsForFollowingQueryRequest, FollowsForFollowingSortTerm, GetAllFollowsForFollowingApiRequest>(request) &&
                   query.MatchesPaginatable(request) &&
                   query.MatchesCurrentUserable(request);
        }

        public bool MatchesFilter(GetAllFollowsForFollowingApiRequest request)
        {
            return query.FollowingId == request.FollowingId &&
                   query.FollowerName == request.FollowerName;
        }
    }

    extension(GetFollowByIdQueryRequest query)
    {
        public bool Matches(GetFollowByIdApiRequest request)
        {
            return query.FollowerId == request.FollowerId &&
                   query.FollowingId == request.FollowingId &&
                   query.MatchesCurrentUserable(request);
        }
    }

    extension(AddFollowCommandRequest command)
    {
        public bool Matches(AddFollowApiRequest request)
        {
            return command.FollowerId == request.FollowerId &&
                   command.FollowingId == request.Body.FollowingId;
        }
    }

    extension(DeleteFollowCommandRequest command)
    {
        public bool Matches(DeleteFollowApiRequest request)
        {
            return command.FollowerId == request.FollowerId &&
                   command.FollowingId == request.FollowingId;
        }
    }

    extension(AddFollowApiResponse response)
    {
        public bool Matches(
        Follow follow,
        AddFollowApiRequest request)
        {
            return response.Id.Matches(follow.Id);
        }
    }

    extension(GetFollowByIdApiResponse response)
    {
        public bool Matches(Follow follow, GetFollowByIdApiRequest request)
        {
            return response.Follow.MatchesFull(follow, request);
        }
    }

    extension(GetAllFollowsApiResponse response)
    {
        public bool Matches(
        User follower,
        ICollection<Follow> follows,
        GetAllFollowsApiRequest request)
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
            GetAllFollowsApiRequest request,
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

    extension(GetAllFollowsForFollowingApiResponse response)
    {
        public bool Matches(
        User following,
        ICollection<Follow> follows,
        GetAllFollowsForFollowingApiRequest request)
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
            GetAllFollowsForFollowingApiRequest request,
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
        public bool Matches(AddFollowApiRequest request)
        {
            return follow.Id.Matches(request.FollowerId, request.Body.FollowingId);
        }

        public bool MatchesFilter(GetAllFollowsApiRequest request)
        {
            return follow.Id.FollowerId.Id.EqualsOrdinalIgnoreCase(request.FollowerId) &&
                   follow.Following != null &&
                   follow.Following.Name.Value.StartsWithOrdinalIgnoreCase(request.FollowingName);
        }

        public bool MatchesFilter(GetAllFollowsForFollowingApiRequest request)
        {
            return follow.Id.FollowingId.Id.EqualsOrdinalIgnoreCase(request.FollowingId) &&
                   follow.Follower != null &&
                   follow.Follower.Name.Value.StartsWithOrdinalIgnoreCase(request.FollowerName);
        }
    }

    extension(FollowIdApiResponse response)
    {
        public bool Matches(FollowId id)
        {
            return id.Matches(response.FollowerId, response.FollowingId);
        }
    }

    extension(FollowApiResponse? response)
    {
        public bool MatchesFull<TRequest>(Follow? follow, TRequest request)
        where TRequest : ICurrentUserableApiRequest
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
            where TRequest : ICurrentUserableApiRequest
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
            where TRequest : ICurrentUserableApiRequest
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

    extension(FollowCollectionApiResponse response)
    {
        public bool MatchesWithoutFollowing<TRequest>(
        Func<FollowApiResponse, Follow, bool> matches,
        Func<Follow, bool> matchesFilter,
        User follower,
        ICollection<Follow> follows,
        TRequest request)
        where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
            Func<FollowApiResponse, Follow, bool> matches,
            Func<Follow, bool> matchesFilter,
            User follower,
            ICollection<Follow> follows,
            TRequest request,
            ISortEnumTermTransformer<Follow> termTransformer)
            where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
            Func<FollowApiResponse, Follow, bool> matches,
            Func<Follow, bool> matchesFilter,
            User following,
            ICollection<Follow> follows,
            TRequest request)
            where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
            Func<FollowApiResponse, Follow, bool> matches,
            Func<Follow, bool> matchesFilter,
            User following,
            ICollection<Follow> follows,
            TRequest request,
            ISortEnumTermTransformer<Follow> termTransformer)
            where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
