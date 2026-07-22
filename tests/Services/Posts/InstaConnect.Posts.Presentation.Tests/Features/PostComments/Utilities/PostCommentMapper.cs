using InstaConnect.Common.Presentation.Features.Messaging.Abstractions;
using InstaConnect.Posts.Presentation.Features.Users.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;

public static class PostCommentMapper
{
	extension(PostComment postComment)
	{
		internal PostCommentIdCommandResponse ToIdCommandResponse(
)
		{
			return new(postComment.Id.Id.Id, postComment.Id.CommentId);
		}

		internal PostCommentQueryResponse ToFullQueryResponse<TRequest>(
			TRequest request)
			where TRequest : ICurrentUserableApiRequest
		{
			return new(postComment.Id.Id.Id,
					   postComment.Id.CommentId,
					   postComment.UserId.Id,
					   postComment.Content,
					   postComment.User?.ToFullQueryResponse(),
					   postComment.Post?.ToFullQueryResponse(request),
					   postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)),
					   postComment.CreatedAtUtc,
					   postComment.UpdatedAtUtc);
		}

		internal PostCommentQueryResponse ToQueryResponseWithoutUser<TRequest>(
			TRequest request)
			where TRequest : ICurrentUserableApiRequest
		{
			return new(postComment.Id.Id.Id,
					   postComment.Id.CommentId,
					   postComment.UserId.Id,
					   postComment.Content,
					   null,
					   postComment.Post?.ToFullQueryResponse(request),
					   postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)),
					   postComment.CreatedAtUtc,
					   postComment.UpdatedAtUtc);
		}

		internal PostCommentQueryResponse ToQueryResponseWithoutPost<TRequest>(
			TRequest request)
			where TRequest : ICurrentUserableApiRequest
		{
			return new(postComment.Id.Id.Id,
					   postComment.Id.CommentId,
					   postComment.UserId.Id,
					   postComment.Content,
					   postComment.User?.ToFullQueryResponse(),
					   null,
					   postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)),
					   postComment.CreatedAtUtc,
					   postComment.UpdatedAtUtc);
		}

		public AddPostCommentCommandResponse ToResponse(
			AddPostCommentApiRequest request)
		{
			return new(postComment.ToIdCommandResponse());
		}

		public UpdatePostCommentCommandResponse ToResponse(
			UpdatePostCommentApiRequest request)
		{
			return new(postComment.ToIdCommandResponse());
		}

		public GetPostCommentByIdQueryResponse ToResponse(
			GetPostCommentByIdApiRequest request)
		{
			return new(postComment.ToFullQueryResponse(request));
		}
	}

	extension(ICollection<PostComment> postComments)
	{
		internal PostCommentCollectionQueryResponse ToQueryResponseWithoutUser<TRequest>(
		Post post,
		Func<TRequest, PostComment, bool> filter,
		Func<TRequest, PostComment, PostCommentQueryResponse> transform,
		TRequest request)
		where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			var paginator = new Paginator();
			var totalCount = postComments.Count(postComment => filter(request, postComment));

			return new(post.ToFullQueryResponse(request),
					   null,
					   postComments.Filter(request, postComment => filter(request, postComment), postComment => transform(request, postComment)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		internal PostCommentCollectionQueryResponse ToQueryResponseWithoutPost<TRequest>(
			User user,
			Func<TRequest, PostComment, bool> filter,
			Func<TRequest, PostComment, PostCommentQueryResponse> transform,
			TRequest request)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			var paginator = new Paginator();
			var totalCount = postComments.Count(postComment => filter(request, postComment));

			return new(null,
					   user.ToFullQueryResponse(),
					   postComments.Filter(request, postComment => filter(request, postComment), postComment => transform(request, postComment)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		public GetAllPostCommentsQueryResponse ToResponse(
			Post post,
			GetAllPostCommentsApiRequest request)
		{
			return new(postComments.ToQueryResponseWithoutUser(post,
														  (request, postComment) => postComment.MatchesFilter(request),
														  (request, postComment) => postComment.ToQueryResponseWithoutPost(request),
														  request));
		}

		public GetAllPostCommentsForUserQueryResponse ToResponse(
			User user,
			GetAllPostCommentsForUserApiRequest request)
		{
			return new(postComments.ToQueryResponseWithoutPost(user,
														  (request, postComment) => postComment.MatchesFilter(request),
														  (request, postComment) => postComment.ToQueryResponseWithoutUser(request),
														  request));
		}
	}
}
