using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Follows.Application.Features.Users.Abstractions;
using InstaConnect.Follows.Application.Tests.Features.Follows.Utilities;
using InstaConnect.Follows.Application.Tests.Features.Users.Utilities;

namespace InstaConnect.Follows.Application.Tests.Features.Follows.Utilities;

public static class FollowMapper
{
    extension(Follow follow)
    {
        internal FollowId ToIdResponse(
)
        {
            return follow.Id;
        }

        internal FollowResponse ToFullResponse<TRequest>(
            TRequest request)
            where TRequest : ICurrentUserableQueryRequest
        {
            return new(follow.Id,
                       follow.Follower?.ToFullResponse(),
                       follow.Following?.ToFullResponse(),
                       follow.Id.FollowerId.Matches(request.CurrentUserId),
                       follow.CreatedAtUtc);
        }

        internal FollowResponse ToResponseWithoutFollower<TRequest>(
            TRequest request)
            where TRequest : ICurrentUserableQueryRequest
        {
            return new(follow.Id,
                       null,
                       follow.Following?.ToFullResponse(),
                       follow.Id.FollowerId.Matches(request.CurrentUserId),
                       follow.CreatedAtUtc);
        }

        internal FollowResponse ToResponseWithoutFollowing<TRequest>(
            TRequest request)
            where TRequest : ICurrentUserableQueryRequest
        {
            return new(follow.Id,
                       follow.Follower?.ToFullResponse(),
                       null,
                       follow.Id.FollowerId.Matches(request.CurrentUserId),
                       follow.CreatedAtUtc);
        }

        public FollowId ToResponse(
            AddFollowCommandRequest request)
        {
            return follow.ToIdResponse();
        }

        public FollowResponse ToResponse(
            GetFollowByIdQueryRequest request)
        {
            return follow.ToFullResponse(request);
        }
    }

    extension(ICollection<Follow> follows)
    {
        internal FollowCollectionResponse ToResponseWithoutFollowing<TRequest>(
        User follower,
        Func<Follow, TRequest, bool> filter,
        Func<Follow, TRequest, FollowResponse> transform,
        TRequest request)
        where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
        {
            var paginator = new Paginator();
            var totalCount = follows.Count(follow => filter(follow, request));

            return new(follower?.ToFullResponse(),
                       null,
                       follows.Filter(follow => filter(follow, request), request, follow => transform(follow, request)),
                       request.Page,
                       request.PageSize,
                       totalCount,
                       paginator.HasNextPage(request.Page, request.PageSize, totalCount),
                       paginator.HasPreviousPage(request.Page));
        }

        internal FollowCollectionResponse ToResponseWithoutFollower<TRequest>(
            User following,
            Func<Follow, TRequest, bool> filter,
            Func<Follow, TRequest, FollowResponse> transform,
            TRequest request)
            where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
        {
            var paginator = new Paginator();
            var totalCount = follows.Count(follow => filter(follow, request));

            return new(null,
                       following.ToFullResponse(),
                       follows.Filter(follow => filter(follow, request), request, follow => transform(follow, request)),
                       request.Page,
                       request.PageSize,
                       totalCount,
                       paginator.HasNextPage(request.Page, request.PageSize, totalCount),
                       paginator.HasPreviousPage(request.Page));
        }

        public FollowCollectionResponse ToResponse(
            User follower,
            GetAllFollowsQueryRequest request)
        {
            return follows.ToResponseWithoutFollowing(
                follower,
                (follow, request) => follow.MatchesFilter(request),
                (follow, request) => follow.ToResponseWithoutFollower(request),
                request);
        }

        public FollowCollectionResponse ToResponse(
            User following,
            GetAllFollowsForFollowingQueryRequest request)
        {
            return follows.ToResponseWithoutFollower(
                following,
                (follow, request) => follow.MatchesFilter(request),
                (follow, request) => follow.ToResponseWithoutFollowing(request),
                request);
        }
    }
}
