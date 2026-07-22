using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Posts.Application.Features.Users.Abstractions;
using InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeMapper
{
	extension(PostCommentLike postCommentLike)
	{
		internal PostCommentLikeResponse ToFullResponse<TRequest>(TRequest request)
			where TRequest : ICurrentUserableQueryRequest
		{
			return new(postCommentLike.Id,
					   postCommentLike.User?.ToFullResponse(),
					   postCommentLike.PostComment?.ToFullResponse(request),
					   postCommentLike.CreatedAtUtc);
		}

		internal PostCommentLikeResponse ToResponseWithoutUser<TRequest>(TRequest request)
			where TRequest : ICurrentUserableQueryRequest
		{
			return new(postCommentLike.Id,
					   null,
					   postCommentLike.PostComment?.ToFullResponse(request),
					   postCommentLike.CreatedAtUtc);
		}

		internal PostCommentLikeResponse ToResponseWithoutPostComment()
		{
			return new(postCommentLike.Id,
					   postCommentLike.User?.ToFullResponse(),
					   null,
					   postCommentLike.CreatedAtUtc);
		}

		public PostCommentLikeId ToResponse(AddPostCommentLikeCommandRequest request)
		{
			return postCommentLike.ToId();
		}

		public PostCommentLikeResponse ToResponse(GetPostCommentLikeByIdQueryRequest request)
		{
			return postCommentLike.ToFullResponse(request);
		}
	}

	extension(ICollection<PostCommentLike> postCommentLikes)
	{
		internal PostCommentLikeCollectionResponse ToResponseWithoutUser<TRequest>(
			PostComment postComment,
			Func<TRequest, PostCommentLike, bool> filter,
			Func<TRequest, PostCommentLike, PostCommentLikeResponse> transform,
			TRequest request)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			var paginator = new Paginator();
			var totalCount = postCommentLikes.Count(postCommentLike => filter(request, postCommentLike));

			return new(postComment.ToFullResponse(request),
					   null,
					   postCommentLikes.Filter(request, postCommentLike => filter(request, postCommentLike), postCommentLike => transform(request, postCommentLike)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		internal PostCommentLikeCollectionResponse ToResponseWithoutPostComment<TRequest>(
			User user,
			Func<TRequest, PostCommentLike, bool> filter,
			Func<TRequest, PostCommentLike, PostCommentLikeResponse> transform,
			TRequest request)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			var paginator = new Paginator();
			var totalCount = postCommentLikes.Count(postCommentLike => filter(request, postCommentLike));

			return new(null,
					   user.ToFullResponse(),
					   postCommentLikes.Filter(request, postCommentLike => filter(request, postCommentLike), postCommentLike => transform(request, postCommentLike)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		public PostCommentLikeCollectionResponse ToResponse(
			PostComment postComment,
			GetAllPostCommentLikesQueryRequest request)
		{
			return postCommentLikes.ToResponseWithoutUser(postComment,
														  (request, postCommentLike) => postCommentLike.MatchesFilter(request),
														  (request, postCommentLike) => postCommentLike.ToResponseWithoutPostComment(),
														  request);
		}

		public PostCommentLikeCollectionResponse ToResponse(
			User user,
			GetAllPostCommentLikesForUserQueryRequest request)
		{
			return postCommentLikes.ToResponseWithoutPostComment(user,
																 (request, postCommentLike) => postCommentLike.MatchesFilter(request),
																 (request, postCommentLike) => postCommentLike.ToResponseWithoutUser(request),
																 request);
		}
	}
}
