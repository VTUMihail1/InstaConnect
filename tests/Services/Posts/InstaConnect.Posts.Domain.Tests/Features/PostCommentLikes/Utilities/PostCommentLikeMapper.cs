using InstaConnect.Posts.Domain.Features.Users.Models.Responses;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Domain.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeMapper
{
	extension(User user)
	{
		public UserResponse ToResponse(
			GetAllPostCommentLikesForUserQuery query)
		{
			return user.ToFullResponse();
		}
	}

	extension(PostComment postComment)
	{
		public PostCommentResponse ToResponse(
			GetAllPostCommentLikesQuery query)
		{
			return postComment.ToFullResponse(query);
		}
	}

	extension(PostCommentLike postCommentLike)
	{
		internal PostCommentLikeResponse ToFullResponse<T>(
			T request)
			where T : ICurrentUserableQuery
		{
			return new(postCommentLike.Id,
					   postCommentLike.User?.ToFullResponse(),
					   postCommentLike.PostComment?.ToFullResponse(request),
					   postCommentLike.CreatedAtUtc);
		}

		internal PostCommentLikeResponse ToResponseWithoutUser<T>(
			T request)
			where T : ICurrentUserableQuery
		{
			return new(postCommentLike.Id,
					   null,
					   postCommentLike.PostComment?.ToFullResponse(request),
					   postCommentLike.CreatedAtUtc);
		}

		internal PostCommentLikeResponse ToResponseWithoutPostComment<T>(
			T request)
			where T : ICurrentUserableQuery
		{
			return new(postCommentLike.Id,
					   postCommentLike.User?.ToFullResponse(),
					   null,
					   postCommentLike.CreatedAtUtc);
		}

		public PostCommentLike To(AddPostCommentLikeCommand command)
		{
			return new(
				new(command.CommentId, command.UserId),
				postCommentLike.CreatedAtUtc);
		}

		public PostCommentLikeId ToResponse(
			AddPostCommentLikeCommand command)
		{
			return postCommentLike.ToId();
		}

		public PostCommentLikeResponse ToResponse(
			GetPostCommentLikeByIdQuery query)
		{
			return postCommentLike.ToFullResponse(query);
		}
	}

	extension(ICollection<PostCommentLike> postCommentLikes)
	{
		public ICollection<PostCommentLikeResponse> ToResponse(
			GetAllPostCommentLikesQuery query)
		{
			return postCommentLikes.Filter<PostCommentLike, GetAllPostCommentLikesQuery, PostCommentLikesPaginationQuery, PostCommentLikeResponse>(postCommentLike => postCommentLike.MatchesFilter(query), query, postCommentLike => postCommentLike.ToResponseWithoutPostComment(query));
		}

		public ICollection<PostCommentLikeResponse> ToResponse(
			GetAllPostCommentLikesForUserQuery query)
		{
			return postCommentLikes.Filter<PostCommentLike, GetAllPostCommentLikesForUserQuery, PostCommentLikesPaginationQuery, PostCommentLikeResponse>(postCommentLike => postCommentLike.MatchesFilter(query), query, postCommentLike => postCommentLike.ToResponseWithoutUser(query));
		}

		public long ToTotalCountResponse(
			GetAllPostCommentLikesQuery query)
		{
			return postCommentLikes.Count(postCommentLike => postCommentLike.MatchesFilter(query));
		}

		public long ToTotalCountResponse(
			GetAllPostCommentLikesForUserQuery query)
		{
			return postCommentLikes.Count(postCommentLike => postCommentLike.MatchesFilter(query));
		}
	}
}
