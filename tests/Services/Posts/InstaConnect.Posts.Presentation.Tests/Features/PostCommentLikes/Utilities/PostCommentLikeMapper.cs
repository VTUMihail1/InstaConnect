using InstaConnect.Common.Presentation.Features.Messaging.Abstractions;
using InstaConnect.Posts.Presentation.Features.Users.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeMapper
{
	extension(PostCommentLike postCommentLike)
	{
		internal PostCommentLikeIdCommandResponse ToIdCommandResponse(
)
		{
			return new(postCommentLike.Id.CommentId.Id.Id, postCommentLike.Id.CommentId.CommentId, postCommentLike.Id.UserId.Id);
		}

		internal PostCommentLikeQueryResponse ToFullQueryResponse<TRequest>(
			TRequest request)
			where TRequest : ICurrentUserableApiRequest
		{
			return new(postCommentLike.Id.CommentId.Id.Id,
					   postCommentLike.Id.CommentId.CommentId,
					   postCommentLike.Id.UserId.Id,
					   postCommentLike.User?.ToFullQueryResponse(),
					   postCommentLike.PostComment?.ToFullQueryResponse(request),
					   postCommentLike.CreatedAtUtc);
		}

		internal PostCommentLikeQueryResponse ToQueryResponseWithoutUser<TRequest>(
			TRequest request)
			where TRequest : ICurrentUserableApiRequest
		{
			return new(postCommentLike.Id.CommentId.Id.Id,
					   postCommentLike.Id.CommentId.CommentId,
					   postCommentLike.Id.UserId.Id,
					   null,
					   postCommentLike.PostComment?.ToFullQueryResponse(request),
					   postCommentLike.CreatedAtUtc);
		}

		internal PostCommentLikeQueryResponse ToQueryResponseWithoutPostComment<TRequest>(
			TRequest request)
			where TRequest : ICurrentUserableApiRequest
		{
			return new(postCommentLike.Id.CommentId.Id.Id,
					   postCommentLike.Id.CommentId.CommentId,
					   postCommentLike.Id.UserId.Id,
					   postCommentLike.User?.ToFullQueryResponse(),
					   null,
					   postCommentLike.CreatedAtUtc);
		}

		public AddPostCommentLikeCommandResponse ToResponse(
			AddPostCommentLikeApiRequest request)
		{
			return new(postCommentLike.ToIdCommandResponse());
		}

		public GetPostCommentLikeByIdQueryResponse ToResponse(
			GetPostCommentLikeByIdApiRequest request)
		{
			return new(postCommentLike.ToFullQueryResponse(request));
		}
	}

	extension(ICollection<PostCommentLike> postCommentLikes)
	{
		internal PostCommentLikeCollectionQueryResponse ToQueryResponseWithoutUser<TRequest>(
		PostComment postComment,
		Func<PostCommentLike, TRequest, bool> filter,
		Func<PostCommentLike, TRequest, PostCommentLikeQueryResponse> transform,
		TRequest request)
		where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			var paginator = new Paginator();
			var totalCount = postCommentLikes.Count(postCommentLike => filter(postCommentLike, request));

			return new(postComment.ToFullQueryResponse(request),
					   null,
					   postCommentLikes.Filter(postCommentLike => filter(postCommentLike, request), request, postCommentLike => transform(postCommentLike, request)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		internal PostCommentLikeCollectionQueryResponse ToQueryResponseWithoutPostComment<TRequest>(
			User user,
			Func<PostCommentLike, TRequest, bool> filter,
			Func<PostCommentLike, TRequest, PostCommentLikeQueryResponse> transform,
			TRequest request)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			var paginator = new Paginator();
			var totalCount = postCommentLikes.Count(postCommentLike => filter(postCommentLike, request));

			return new(null,
					   user.ToFullQueryResponse(),
					   postCommentLikes.Filter(postCommentLike => filter(postCommentLike, request), request, postCommentLike => transform(postCommentLike, request)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		public GetAllPostCommentLikesQueryResponse ToResponse(
			PostComment postComment,
			GetAllPostCommentLikesApiRequest request)
		{
			return new(postCommentLikes.ToQueryResponseWithoutUser(postComment,
															  (postCommentLike, request) => postCommentLike.MatchesFilter(request),
															  (postCommentLike, request) => postCommentLike.ToQueryResponseWithoutPostComment(request),
															  request));
		}

		public GetAllPostCommentLikesForUserQueryResponse ToResponse(
			User user,
			GetAllPostCommentLikesForUserApiRequest request)
		{
			return new(postCommentLikes.ToQueryResponseWithoutPostComment(user,
																	 (postCommentLike, request) => postCommentLike.MatchesFilter(request),
																	 (postCommentLike, request) => postCommentLike.ToQueryResponseWithoutUser(request),
																	 request));
		}
	}
}
