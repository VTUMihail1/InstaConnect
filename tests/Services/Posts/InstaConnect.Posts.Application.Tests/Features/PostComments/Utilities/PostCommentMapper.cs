using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Posts.Application.Features.Users.Abstractions;
using InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;

public static class PostCommentMapper
{
	extension(PostComment postComment)
	{
		internal PostCommentId ToIdResponse(
)
		{
			return postComment.Id;
		}

		internal PostCommentResponse ToFullResponse<TRequest>(
			TRequest request)
			where TRequest : ICurrentUserableQueryRequest
		{
			return new(postComment.Id,
					   postComment.UserId,
					   postComment.Content,
					   postComment.User?.ToFullResponse(),
					   postComment.Post?.ToFullResponse(request),
					   postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)),
					   postComment.CreatedAtUtc,
					   postComment.UpdatedAtUtc);
		}

		internal PostCommentResponse ToResponseWithoutUser<TRequest>(
			TRequest request)
			where TRequest : ICurrentUserableQueryRequest
		{
			return new(postComment.Id,
					   postComment.UserId,
					   postComment.Content,
					   null,
					   postComment.Post?.ToFullResponse(request),
					   postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)),
					   postComment.CreatedAtUtc,
					   postComment.UpdatedAtUtc);
		}

		internal PostCommentResponse ToResponseWithoutPost<TRequest>(
			TRequest request)
			where TRequest : ICurrentUserableQueryRequest
		{
			return new(postComment.Id,
					   postComment.UserId,
					   postComment.Content,
					   postComment.User?.ToFullResponse(),
					   null,
					   postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)),
					   postComment.CreatedAtUtc,
					   postComment.UpdatedAtUtc);
		}

		public PostCommentId ToResponse(
			AddPostCommentCommandRequest request)
		{
			return postComment.ToIdResponse();
		}

		public PostCommentId ToResponse(
			UpdatePostCommentCommandRequest request)
		{
			return postComment.ToIdResponse();
		}

		public PostCommentResponse ToResponse(
			GetPostCommentByIdQueryRequest request)
		{
			return postComment.ToFullResponse(request);
		}
	}

	extension(ICollection<PostComment> postComments)
	{
		internal PostCommentCollectionResponse ToResponseWithoutUser<TRequest>(
		Post post,
		Func<PostComment, TRequest, bool> filter,
		Func<PostComment, TRequest, PostCommentResponse> transform,
		TRequest request)
		where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			var paginator = new Paginator();
			var totalCount = postComments.Count(postComment => filter(postComment, request));

			return new(post.ToFullResponse(request),
					   null,
					   postComments.Filter(postComment => filter(postComment, request), request, postComment => transform(postComment, request)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		internal PostCommentCollectionResponse ToResponseWithoutPost<TRequest>(
			User user,
			Func<PostComment, TRequest, bool> filter,
			Func<PostComment, TRequest, PostCommentResponse> transform,
			TRequest request)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			var paginator = new Paginator();
			var totalCount = postComments.Count(postComment => filter(postComment, request));

			return new(null,
					   user.ToFullResponse(),
					   postComments.Filter(postComment => filter(postComment, request), request, postComment => transform(postComment, request)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		public PostCommentCollectionResponse ToResponse(
			Post post,
			GetAllPostCommentsQueryRequest request)
		{
			return postComments.ToResponseWithoutUser(post,
													  (postComment, request) => postComment.MatchesFilter(request),
													  (postComment, request) => postComment.ToResponseWithoutPost(request),
													  request);
		}

		public PostCommentCollectionResponse ToResponse(
			User user,
			GetAllPostCommentsForUserQueryRequest request)
		{
			return postComments.ToResponseWithoutPost(user,
													  (postComment, request) => postComment.MatchesFilter(request),
													  (postComment, request) => postComment.ToResponseWithoutUser(request),
													  request);
		}
	}
}
