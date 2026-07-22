using InstaConnect.Common.Presentation.Features.Messaging.Abstractions;
using InstaConnect.Follows.Presentation.Features.Users.Abstractions;
using InstaConnect.Follows.Presentation.Tests.Features.Follows.Utilities;
using InstaConnect.Follows.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Follows.Presentation.Tests.Features.Follows.Utilities;

public static class FollowMapper
{
	extension(Follow follow)
	{
		internal FollowIdCommandResponse ToIdCommandResponse(
)
		{
			return new(follow.Id.FollowerId.Id, follow.Id.FollowingId.Id);
		}

		internal FollowQueryResponse ToFullQueryResponse<TRequest>(
			TRequest request)
			where TRequest : ICurrentUserableApiRequest
		{
			return new(follow.Id.FollowerId.Id,
					   follow.Id.FollowingId.Id,
					   follow.Follower?.ToFullQueryResponse(),
					   follow.Following?.ToFullQueryResponse(),
					   follow.Id.FollowerId.Matches(request.CurrentUserId),
					   follow.CreatedAtUtc);
		}

		internal FollowQueryResponse ToQueryResponseWithoutFollower<TRequest>(
			TRequest request)
			where TRequest : ICurrentUserableApiRequest
		{
			return new(follow.Id.FollowerId.Id,
					   follow.Id.FollowingId.Id,
					   null,
					   follow.Following?.ToFullQueryResponse(),
					   follow.Id.FollowerId.Matches(request.CurrentUserId),
					   follow.CreatedAtUtc);
		}

		internal FollowQueryResponse ToQueryResponseWithoutFollowing<TRequest>(
			TRequest request)
			where TRequest : ICurrentUserableApiRequest
		{
			return new(follow.Id.FollowerId.Id,
					   follow.Id.FollowingId.Id,
					   follow.Follower?.ToFullQueryResponse(),
					   null,
					   follow.Id.FollowerId.Matches(request.CurrentUserId),
					   follow.CreatedAtUtc);
		}

		public AddFollowCommandResponse ToResponse(
			AddFollowApiRequest request)
		{
			return new(follow.ToIdCommandResponse());
		}

		public GetFollowByIdQueryResponse ToResponse(
			GetFollowByIdApiRequest request)
		{
			return new(follow.ToFullQueryResponse(request));
		}
	}

	extension(ICollection<Follow> follows)
	{
		internal FollowCollectionQueryResponse ToQueryResponseWithoutFollowing<TRequest>(
		User follower,
		Func<Follow, TRequest, bool> filter,
		Func<Follow, TRequest, FollowQueryResponse> transform,
		TRequest request)
		where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			var paginator = new Paginator();
			var totalCount = follows.Count(follow => filter(follow, request));

			return new(follower.ToFullQueryResponse(),
					   null,
					   follows.Filter(request, follow => filter(follow, request), follow => transform(follow, request)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		internal FollowCollectionQueryResponse ToQueryResponseWithoutFollower<TRequest>(
			User following,
			Func<Follow, TRequest, bool> filter,
			Func<Follow, TRequest, FollowQueryResponse> transform,
			TRequest request)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			var paginator = new Paginator();
			var totalCount = follows.Count(follow => filter(follow, request));

			return new(null,
					   following.ToFullQueryResponse(),
					   follows.Filter(request, follow => filter(follow, request), follow => transform(follow, request)),
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
			return new(follows.ToQueryResponseWithoutFollowing(follower,
													   (follow, request) => follow.MatchesFilter(request),
													   (follow, request) => follow.ToQueryResponseWithoutFollower(request),
													   request));
		}

		public GetAllFollowsForFollowingQueryResponse ToResponse(
			User following,
			GetAllFollowsForFollowingApiRequest request)
		{
			return new(follows.ToQueryResponseWithoutFollower(following,
													   (follow, request) => follow.MatchesFilter(request),
													   (follow, request) => follow.ToQueryResponseWithoutFollowing(request),
													   request));
		}
	}
}
