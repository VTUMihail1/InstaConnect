using InstaConnect.Posts.Domain.Features.Users.Models.Responses;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Domain.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Features.PostComments.Utilities;

public static class PostCommentMapper
{
	extension(User user)
	{
		public UserResponse ToResponse(
			GetAllPostCommentsForUserQuery query)
		{
			return user.ToFullResponse();
		}
	}

	extension(Post post)
	{
		public PostResponse ToResponse(
			GetAllPostCommentsQuery query)
		{
			return post.ToFullResponse(query);
		}
	}

	extension(PostComment postComment)
	{
		internal PostCommentResponse ToFullResponse<T>(
			T request)
			where T : ICurrentUserableQuery
		{
			return new(postComment.Id,
					   postComment.UserId,
					   postComment.Content,
					   postComment.User?.ToFullResponse(),
					   postComment.Post?.ToFullResponse(request),
					   postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUser.Id)),
					   postComment.CreatedAtUtc,
					   postComment.UpdatedAtUtc);
		}

		internal PostCommentResponse ToResponseWithoutUser<T>(
			T request)
			where T : ICurrentUserableQuery
		{
			return new(postComment.Id,
					   postComment.UserId,
					   postComment.Content,
					   null,
					   postComment.Post?.ToFullResponse(request),
					   postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUser.Id)),
					   postComment.CreatedAtUtc,
					   postComment.UpdatedAtUtc);
		}

		internal PostCommentResponse ToResponseWithoutPost<T>(
			T request)
			where T : ICurrentUserableQuery
		{
			return new(postComment.Id,
					   postComment.UserId,
					   postComment.Content,
					   postComment.User?.ToFullResponse(),
					   null,
					   postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUser.Id)),
					   postComment.CreatedAtUtc,
					   postComment.UpdatedAtUtc);
		}

		public PostComment To(AddPostCommentCommand command)
		{
			return new(postComment.Id,
					   command.Content,
					   command.UserId,
					   postComment.CreatedAtUtc,
					   postComment.UpdatedAtUtc);
		}

		public PostCommentId ToResponse(
			AddPostCommentCommand command)
		{
			return postComment.ToId();
		}

		public PostCommentId ToResponse(
			UpdatePostCommentCommand command)
		{
			return postComment.ToId();
		}

		public PostCommentResponse ToResponse(
			GetPostCommentByIdQuery query)
		{
			return postComment.ToFullResponse(query);
		}
	}

	extension(ICollection<PostComment> postComments)
	{
		public ICollection<PostCommentResponse> ToResponse(
			GetAllPostCommentsQuery query)
		{
			return postComments.Filter(postComment => postComment.MatchesFilter(query.Filter), query.Pagination, postComment => postComment.ToResponseWithoutPost(query));
		}

		public ICollection<PostCommentResponse> ToResponse(
			GetAllPostCommentsForUserQuery query)
		{
			return postComments.Filter(postComment => postComment.MatchesFilter(query.Filter), query.Pagination, postComment => postComment.ToResponseWithoutUser(query));
		}

		public long ToTotalCountResponse(
			GetAllPostCommentsQuery query)
		{
			return postComments.Count(postComment => postComment.MatchesFilter(query.Filter));
		}

		public long ToTotalCountResponse(
			GetAllPostCommentsForUserQuery query)
		{
			return postComments.Count(postComment => postComment.MatchesFilter(query.Filter));
		}
	}
}
