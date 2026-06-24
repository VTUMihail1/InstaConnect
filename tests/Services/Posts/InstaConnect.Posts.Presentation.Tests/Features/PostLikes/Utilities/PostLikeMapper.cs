using InstaConnect.Common.Presentation.Features.Messaging.Abstractions;
using InstaConnect.Posts.Presentation.Features.Users.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;

public static class PostLikeMapper
{
	extension(PostLike postLike)
	{
		internal PostLikeIdCommandResponse ToIdCommandResponse(
)
		{
			return new(postLike.Id.Id.Id, postLike.Id.UserId.Id);
		}

		internal PostLikeQueryResponse ToFullQueryResponse<TRequest>(
			TRequest request)
			where TRequest : ICurrentUserableApiRequest
		{
			return new(postLike.Id.Id.Id,
					   postLike.Id.UserId.Id,
					   postLike.User?.ToFullResponse(),
					   postLike.Post?.ToFullQueryResponse(request),
					   postLike.CreatedAtUtc);
		}

		internal PostLikeQueryResponse ToQueryResponseWithoutUser<TRequest>(
			TRequest request)
			where TRequest : ICurrentUserableApiRequest
		{
			return new(postLike.Id.Id.Id,
					   postLike.Id.UserId.Id,
					   null,
					   postLike.Post?.ToFullQueryResponse(request),
					   postLike.CreatedAtUtc);
		}

		internal PostLikeQueryResponse ToQueryResponseWithoutPost<TRequest>(
			TRequest request)
			where TRequest : ICurrentUserableApiRequest
		{
			return new(postLike.Id.Id.Id,
					   postLike.Id.UserId.Id,
					   postLike.User?.ToFullResponse(),
					   null,
					   postLike.CreatedAtUtc);
		}

		public AddPostLikeCommandResponse ToResponse(
			AddPostLikeApiRequest request)
		{
			return new(postLike.ToIdCommandResponse());
		}

		public GetPostLikeByIdQueryResponse ToResponse(
			GetPostLikeByIdApiRequest request)
		{
			return new(postLike.ToFullQueryResponse(request));
		}
	}

	extension(ICollection<PostLike> postLikes)
	{
		internal PostLikeCollectionQueryResponse ToQueryResponseWithoutUser<TRequest>(
		Post post,
		Func<PostLike, TRequest, bool> filter,
		Func<PostLike, TRequest, PostLikeQueryResponse> transform,
		TRequest request)
		where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			var paginator = new Paginator();
			var totalCount = postLikes.Count(postLike => filter(postLike, request));

			return new(post.ToFullQueryResponse(request),
					   null,
					   postLikes.Filter(postLike => filter(postLike, request), request, postLike => transform(postLike, request)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		internal PostLikeCollectionQueryResponse ToQueryResponseWithoutPost<TRequest>(
			User user,
			Func<PostLike, TRequest, bool> filter,
			Func<PostLike, TRequest, PostLikeQueryResponse> transform,
			TRequest request)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			var paginator = new Paginator();
			var totalCount = postLikes.Count(postLike => filter(postLike, request));

			return new(null,
					   user.ToFullResponse(),
					   postLikes.Filter(postLike => filter(postLike, request), request, postLike => transform(postLike, request)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		public GetAllPostLikesQueryResponse ToResponse(
			Post post,
			GetAllPostLikesApiRequest request)
		{
			return new(postLikes.ToQueryResponseWithoutUser(post,
													   (postLike, request) => postLike.MatchesFilter(request),
													   (postLike, request) => postLike.ToQueryResponseWithoutPost(request),
													   request));
		}

		public GetAllPostLikesForUserQueryResponse ToResponse(
			User user,
			GetAllPostLikesForUserApiRequest request)
		{
			return new(postLikes.ToQueryResponseWithoutPost(user,
													   (postLike, request) => postLike.MatchesFilter(request),
													   (postLike, request) => postLike.ToQueryResponseWithoutUser(request),
													   request));
		}
	}
}
