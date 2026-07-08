using InstaConnect.Posts.Domain.Features.Users.Models.Responses;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Domain.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Features.PostLikes.Utilities;

public static class PostLikeMapper
{
	extension(User user)
	{
		public UserResponse ToResponse(
			GetAllPostLikesForUserQuery query)
		{
			return user.ToFullResponse();
		}
	}

	extension(Post post)
	{
		public PostResponse ToResponse(
			GetAllPostLikesQuery query)
		{
			return post.ToFullResponse(query);
		}
	}

	extension(PostLike postLike)
	{
		internal PostLikeResponse ToFullResponse<T>(
			T request)
			where T : ICurrentUserableQuery
		{
			return new(postLike.Id,
					   postLike.User?.ToFullResponse(),
					   postLike.Post?.ToFullResponse(request),
					   postLike.CreatedAtUtc);
		}

		internal PostLikeResponse ToResponseWithoutUser<T>(
			T request)
			where T : ICurrentUserableQuery
		{
			return new(postLike.Id,
					   null,
					   postLike.Post?.ToFullResponse(request),
					   postLike.CreatedAtUtc);
		}

		internal PostLikeResponse ToResponseWithoutPost<T>(
			T request)
			where T : ICurrentUserableQuery
		{
			return new(postLike.Id,
					   postLike.User?.ToFullResponse(),
					   null,
					   postLike.CreatedAtUtc);
		}

		public PostLike To(AddPostLikeCommand command)
		{
			return new(
				new(command.Id, command.UserId),
				postLike.CreatedAtUtc);
		}

		public PostLikeId ToResponse(
			AddPostLikeCommand command)
		{
			return postLike.ToId();
		}

		public PostLikeResponse ToResponse(
			GetPostLikeByIdQuery query)
		{
			return postLike.ToFullResponse(query);
		}
	}

	extension(ICollection<PostLike> postLikes)
	{
		public ICollection<PostLikeResponse> ToResponse(
			GetAllPostLikesQuery query)
		{
			return postLikes.Filter<PostLike, GetAllPostLikesQuery, PostLikesPaginationQuery, PostLikeResponse>(postLike => postLike.MatchesFilter(query), query, postLike => postLike.ToResponseWithoutPost(query));
		}

		public ICollection<PostLikeResponse> ToResponse(
			GetAllPostLikesForUserQuery query)
		{
			return postLikes.Filter<PostLike, GetAllPostLikesForUserQuery, PostLikesPaginationQuery, PostLikeResponse>(postLike => postLike.MatchesFilter(query), query, postLike => postLike.ToResponseWithoutUser(query));
		}

		public long ToTotalCountResponse(
			GetAllPostLikesQuery query)
		{
			return postLikes.Count(postLike => postLike.MatchesFilter(query));
		}

		public long ToTotalCountResponse(
			GetAllPostLikesForUserQuery query)
		{
			return postLikes.Count(postLike => postLike.MatchesFilter(query));
		}
	}
}
