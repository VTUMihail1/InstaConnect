using InstaConnect.Common.Presentation.Features.Messaging.Abstractions;
using InstaConnect.Follows.Presentation.Features.Users.Abstractions;
using InstaConnect.Follows.Presentation.Tests.Features.Follows.Utilities;
using InstaConnect.Follows.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Follows.Presentation.Tests.Features.Follows.Utilities;

public static class FollowMapper
{
    extension(Follow follow)
    {
        internal FollowIdCommandResponse ToIdResponse(
)
        {
            return new(follow.Id.FollowerId.Id, follow.Id.FollowingId.Id);
        }

        internal FollowQueryResponse ToFullResponse<TRequest>(
            TRequest request)
            where TRequest : ICurrentUserableApiRequest
        {
            return new(follow.Id.FollowerId.Id,
                       follow.Id.FollowingId.Id,
                       follow.Follower?.ToFullResponse(),
                       follow.Following?.ToFullResponse(),
                       follow.Id.FollowerId.Matches(request.CurrentUserId),
                       follow.CreatedAtUtc);
        }

        internal FollowQueryResponse ToResponseWithoutFollower<TRequest>(
            TRequest request)
            where TRequest : ICurrentUserableApiRequest
        {
            return new(follow.Id.FollowerId.Id,
                       follow.Id.FollowingId.Id,
                       null,
                       follow.Following?.ToFullResponse(),
                       follow.Id.FollowerId.Matches(request.CurrentUserId),
                       follow.CreatedAtUtc);
        }

        internal FollowQueryResponse ToResponseWithoutFollowing<TRequest>(
            TRequest request)
            where TRequest : ICurrentUserableApiRequest
        {
            return new(follow.Id.FollowerId.Id,
                       follow.Id.FollowingId.Id,
                       follow.Follower?.ToFullResponse(),
                       null,
                       follow.Id.FollowerId.Matches(request.CurrentUserId),
                       follow.CreatedAtUtc);
        }

        public AddFollowCommandResponse ToResponse(
            AddFollowApiRequest request)
        {
            return new(follow.ToIdResponse());
        }

        public GetFollowByIdQueryResponse ToResponse(
            GetFollowByIdApiRequest request)
        {
            return new(follow.ToFullResponse(request));
        }
    }

    extension(ICollection<Follow> follows)
    {
        internal FollowCollectionQueryResponse ToResponseWithoutFollowing<TRequest>(
        User follower,
        Func<Follow, TRequest, bool> filter,
        Func<Follow, TRequest, FollowQueryResponse> transform,
        TRequest request)
        where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
        {
            var paginator = new Paginator();
            var totalCount = follows.Count(follow => filter(follow, request));

            return new(follower.ToFullResponse(),
                       null,
                       follows.Filter(follow => filter(follow, request), request, follow => transform(follow, request)),
                       request.Page,
                       request.PageSize,
                       totalCount,
                       paginator.HasNextPage(request.Page, request.PageSize, totalCount),
                       paginator.HasPreviousPage(request.Page));
        }

        internal FollowCollectionQueryResponse ToResponseWithoutFollower<TRequest>(
            User following,
            Func<Follow, TRequest, bool> filter,
            Func<Follow, TRequest, FollowQueryResponse> transform,
            TRequest request)
            where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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

        public GetAllFollowsQueryResponse ToResponse(
            User follower,
            GetAllFollowsApiRequest request)
        {
            return new(follows.ToResponseWithoutFollowing(follower,
                                                       (follow, request) => follow.MatchesFilter(request),
                                                       (follow, request) => follow.ToResponseWithoutFollower(request),
                                                       request));
        }

        public GetAllFollowsForFollowingQueryResponse ToResponse(
            User following,
            GetAllFollowsForFollowingApiRequest request)
        {
            return new(follows.ToResponseWithoutFollower(following,
                                                       (follow, request) => follow.MatchesFilter(request),
                                                       (follow, request) => follow.ToResponseWithoutFollowing(request),
                                                       request));
        }
    }
}
