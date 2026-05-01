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
		internal PostCommentLikeIdCommandResponse ToIdResponse(
)
		{
			return new(postCommentLike.Id.CommentId.Id.Id, postCommentLike.Id.CommentId.CommentId, postCommentLike.Id.UserId.Id);
		}

		internal PostCommentLikeQueryResponse ToFullResponse<TRequest>(
			TRequest request)
			where TRequest : ICurrentUserableApiRequest
		{
			return new(postCommentLike.Id.CommentId.Id.Id,
					   postCommentLike.Id.CommentId.CommentId,
					   postCommentLike.Id.UserId.Id,
					   postCommentLike.User?.ToFullResponse(),
					   postCommentLike.PostComment?.ToFullResponse(request),
					   postCommentLike.CreatedAtUtc);
		}

		internal PostCommentLikeQueryResponse ToResponseWithoutUser<TRequest>(
			TRequest request)
			where TRequest : ICurrentUserableApiRequest
		{
			return new(postCommentLike.Id.CommentId.Id.Id,
					   postCommentLike.Id.CommentId.CommentId,
					   postCommentLike.Id.UserId.Id,
					   null,
					   postCommentLike.PostComment?.ToFullResponse(request),
					   postCommentLike.CreatedAtUtc);
		}

		internal PostCommentLikeQueryResponse ToResponseWithoutPostComment<TRequest>(
			TRequest request)
			where TRequest : ICurrentUserableApiRequest
		{
			return new(postCommentLike.Id.CommentId.Id.Id,
					   postCommentLike.Id.CommentId.CommentId,
					   postCommentLike.Id.UserId.Id,
					   postCommentLike.User?.ToFullResponse(),
					   null,
					   postCommentLike.CreatedAtUtc);
		}

		public AddPostCommentLikeCommandResponse ToResponse(
			AddPostCommentLikeApiRequest request)
		{
			return new(postCommentLike.ToIdResponse());
		}

		public GetPostCommentLikeByIdQueryResponse ToResponse(
			GetPostCommentLikeByIdApiRequest request)
		{
			return new(postCommentLike.ToFullResponse(request));
		}
	}

	extension(ICollection<PostCommentLike> postCommentLikes)
	{
		internal PostCommentLikeCollectionQueryResponse ToResponseWithoutUser<TRequest>(
		PostComment postComment,
		Func<PostCommentLike, TRequest, bool> filter,
		Func<PostCommentLike, TRequest, PostCommentLikeQueryResponse> transform,
		TRequest request)
		where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			var paginator = new Paginator();
			var totalCount = postCommentLikes.Count(postCommentLike => filter(postCommentLike, request));

			return new(postComment.ToFullResponse(request),
					   null,
					   postCommentLikes.Filter(postCommentLike => filter(postCommentLike, request), request, postCommentLike => transform(postCommentLike, request)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		internal PostCommentLikeCollectionQueryResponse ToResponseWithoutPostComment<TRequest>(
			User user,
			Func<PostCommentLike, TRequest, bool> filter,
			Func<PostCommentLike, TRequest, PostCommentLikeQueryResponse> transform,
			TRequest request)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			var paginator = new Paginator();
			var totalCount = postCommentLikes.Count(postCommentLike => filter(postCommentLike, request));

			return new(null,
					   user.ToFullResponse(),
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
			return new(postCommentLikes.ToResponseWithoutUser(postComment,
															  (postCommentLike, request) => postCommentLike.MatchesFilter(request),
															  (postCommentLike, request) => postCommentLike.ToResponseWithoutPostComment(request),
															  request));
		}

		public GetAllPostCommentLikesForUserQueryResponse ToResponse(
			User user,
			GetAllPostCommentLikesForUserApiRequest request)
		{
			return new(postCommentLikes.ToResponseWithoutPostComment(user,
																	 (postCommentLike, request) => postCommentLike.MatchesFilter(request),
																	 (postCommentLike, request) => postCommentLike.ToResponseWithoutUser(request),
																	 request));
		}
	}
}
