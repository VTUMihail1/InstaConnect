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

		internal PostCommentLikeQueryResponse ToQueryResponseWithoutPostComment()
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
		Func<TRequest, PostCommentLike, bool> filter,
		Func<TRequest, PostCommentLike, PostCommentLikeQueryResponse> transform,
		TRequest request)
		where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			var paginator = new Paginator();
			var totalCount = postCommentLikes.Count(postCommentLike => filter(request, postCommentLike));

			return new(postComment.ToFullQueryResponse(request),
					   null,
					   postCommentLikes.Filter(request, postCommentLike => filter(request, postCommentLike), postCommentLike => transform(request, postCommentLike)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		internal PostCommentLikeCollectionQueryResponse ToQueryResponseWithoutPostComment<TRequest>(
			User user,
			Func<TRequest, PostCommentLike, bool> filter,
			Func<TRequest, PostCommentLike, PostCommentLikeQueryResponse> transform,
			TRequest request)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			var paginator = new Paginator();
			var totalCount = postCommentLikes.Count(postCommentLike => filter(request, postCommentLike));

			return new(null,
					   user.ToFullQueryResponse(),
					   postCommentLikes.Filter(request, postCommentLike => filter(request, postCommentLike), postCommentLike => transform(request, postCommentLike)),
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
															  (request, postCommentLike) => postCommentLike.MatchesFilter(request),
															  (request, postCommentLike) => postCommentLike.ToQueryResponseWithoutPostComment(),
															  request));
		}

		public GetAllPostCommentLikesForUserQueryResponse ToResponse(
			User user,
			GetAllPostCommentLikesForUserApiRequest request)
		{
			return new(postCommentLikes.ToQueryResponseWithoutPostComment(user,
																	 (request, postCommentLike) => postCommentLike.MatchesFilter(request),
																	 (request, postCommentLike) => postCommentLike.ToQueryResponseWithoutUser(request),
																	 request));
		}
	}
}
