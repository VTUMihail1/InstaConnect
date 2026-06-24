using InstaConnect.Common.Presentation.Features.Messaging.Abstractions;
using InstaConnect.Posts.Presentation.Features.Users.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;

public static class PostMapper
{
	extension(Post post)
	{
		internal PostIdCommandResponse ToIdCommandResponse(
)
		{
			return new(post.Id.Id);
		}

		internal PostQueryResponse ToFullQueryResponse<TRequest>(
			TRequest request)
			where TRequest : ICurrentUserableApiRequest
		{
			return new(post.Id.Id,
					   post.UserId.Id,
					   post.Title,
					   post.Content,
					   post.User?.ToFullResponse(),
					   post.PostLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)),
					   post.CreatedAtUtc,
					   post.UpdatedAtUtc);
		}

		internal PostQueryResponse ToQueryResponseWithoutUser<TRequest>(
			TRequest request)
			where TRequest : ICurrentUserableApiRequest
		{
			return new(post.Id.Id,
					   post.UserId.Id,
					   post.Title,
					   post.Content,
					   null,
					   post.PostLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)),
					   post.CreatedAtUtc,
					   post.UpdatedAtUtc);
		}

		public AddPostCommandResponse ToResponse(
			AddPostApiRequest request)
		{
			return new(post.ToIdCommandResponse());
		}

		public UpdatePostCommandResponse ToResponse(
			UpdatePostApiRequest request)
		{
			return new(post.ToIdCommandResponse());
		}

		public GetPostByIdQueryResponse ToResponse(
			GetPostByIdApiRequest request)
		{
			return new(post.ToFullQueryResponse(request));
		}
	}

	extension(ICollection<Post> posts)
	{
		internal PostCollectionQueryResponse ToFullQueryResponse<TRequest>(
		User user,
		Func<Post, TRequest, bool> filter,
		Func<Post, TRequest, PostQueryResponse> transform,
		TRequest request)
		where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			var paginator = new Paginator();
			var totalCount = posts.Count(post => filter(post, request));

			return new(user.ToFullResponse(),
						posts.Filter(post => filter(post, request), request, post => transform(post, request)),
						request.Page,
						request.PageSize,
						totalCount,
						paginator.HasNextPage(request.Page, request.PageSize, totalCount),
						paginator.HasPreviousPage(request.Page));
		}

		internal PostCollectionQueryResponse ToQueryResponseWithoutUser<TRequest>(
			Func<Post, TRequest, bool> filter,
			Func<Post, TRequest, PostQueryResponse> transform,
			TRequest request)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			var paginator = new Paginator();
			var totalCount = posts.Count(post => filter(post, request));

			return new(null,
					   posts.Filter(post => filter(post, request), request, post => transform(post, request)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		public GetAllPostsQueryResponse ToResponse(
			GetAllPostsApiRequest request)
		{
			return new(posts.ToQueryResponseWithoutUser((post, request) => post.MatchesFilter(request),
												   (post, request) => post.ToFullQueryResponse(request),
												   request));
		}

		public GetAllPostsForUserQueryResponse ToResponse(
			User user,
			GetAllPostsForUserApiRequest request)
		{
			return new(posts.ToFullQueryResponse(user,
											(post, request) => post.MatchesFilter(request),
											(post, request) => post.ToQueryResponseWithoutUser(request),
											request));
		}
	}
}
