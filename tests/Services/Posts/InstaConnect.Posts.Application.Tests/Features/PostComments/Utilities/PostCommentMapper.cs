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
			return postComment.ToId();
		}

		public PostCommentId ToResponse(
			UpdatePostCommentCommandRequest request)
		{
			return postComment.ToId();
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
		Func<TRequest, PostComment, bool> filter,
		Func<TRequest, PostComment, PostCommentResponse> transform,
		TRequest request)
		where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			var paginator = new Paginator();
			var totalCount = postComments.Count(postComment => filter(request, postComment));

			return new(post.ToFullResponse(request),
					   null,
					   postComments.Filter(request, postComment => filter(request, postComment), postComment => transform(request, postComment)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		internal PostCommentCollectionResponse ToResponseWithoutPost<TRequest>(
			User user,
			Func<TRequest, PostComment, bool> filter,
			Func<TRequest, PostComment, PostCommentResponse> transform,
			TRequest request)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			var paginator = new Paginator();
			var totalCount = postComments.Count(postComment => filter(request, postComment));

			return new(null,
					   user.ToFullResponse(),
					   postComments.Filter(request, postComment => filter(request, postComment), postComment => transform(request, postComment)),
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
													  (request, postComment) => postComment.MatchesFilter(request),
													  (request, postComment) => postComment.ToResponseWithoutPost(request),
													  request);
		}

		public PostCommentCollectionResponse ToResponse(
			User user,
			GetAllPostCommentsForUserQueryRequest request)
		{
			return postComments.ToResponseWithoutPost(user,
													  (request, postComment) => postComment.MatchesFilter(request),
													  (request, postComment) => postComment.ToResponseWithoutUser(request),
													  request);
		}
	}
}
