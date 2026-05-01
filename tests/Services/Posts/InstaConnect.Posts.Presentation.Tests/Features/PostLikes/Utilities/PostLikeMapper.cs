using InstaConnect.Common.Presentation.Features.Messaging.Abstractions;
using InstaConnect.Posts.Presentation.Features.Users.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;

public static class PostLikeMapper
{
	extension(PostLike postLike)
	{
		internal PostLikeIdCommandResponse ToIdResponse(
)
		{
			return new(postLike.Id.Id.Id, postLike.Id.UserId.Id);
		}

		internal PostLikeQueryResponse ToFullResponse<TRequest>(
			TRequest request)
			where TRequest : ICurrentUserableApiRequest
		{
			return new(postLike.Id.Id.Id,
					   postLike.Id.UserId.Id,
					   postLike.User?.ToFullResponse(),
					   postLike.Post?.ToFullResponse(request),
					   postLike.CreatedAtUtc);
		}

		internal PostLikeQueryResponse ToResponseWithoutUser<TRequest>(
			TRequest request)
			where TRequest : ICurrentUserableApiRequest
		{
			return new(postLike.Id.Id.Id,
					   postLike.Id.UserId.Id,
					   null,
					   postLike.Post?.ToFullResponse(request),
					   postLike.CreatedAtUtc);
		}

		internal PostLikeQueryResponse ToResponseWithoutPost<TRequest>(
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
			return new(postLike.ToIdResponse());
		}

		public GetPostLikeByIdQueryResponse ToResponse(
			GetPostLikeByIdApiRequest request)
		{
			return new(postLike.ToFullResponse(request));
		}
	}

	extension(ICollection<PostLike> postLikes)
	{
		internal PostLikeCollectionQueryResponse ToResponseWithoutUser<TRequest>(
		Post post,
		Func<PostLike, TRequest, bool> filter,
		Func<PostLike, TRequest, PostLikeQueryResponse> transform,
		TRequest request)
		where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			var paginator = new Paginator();
			var totalCount = postLikes.Count(postLike => filter(postLike, request));

			return new(post.ToFullResponse(request),
					   null,
					   postLikes.Filter(postLike => filter(postLike, request), request, postLike => transform(postLike, request)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		internal PostLikeCollectionQueryResponse ToResponseWithoutPost<TRequest>(
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
			return new(postLikes.ToResponseWithoutUser(post,
													   (postLike, request) => postLike.MatchesFilter(request),
													   (postLike, request) => postLike.ToResponseWithoutPost(request),
													   request));
		}

		public GetAllPostLikesForUserQueryResponse ToResponse(
			User user,
			GetAllPostLikesForUserApiRequest request)
		{
			return new(postLikes.ToResponseWithoutPost(user,
													   (postLike, request) => postLike.MatchesFilter(request),
													   (postLike, request) => postLike.ToResponseWithoutUser(request),
													   request));
		}
	}
}
