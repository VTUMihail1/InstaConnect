using InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Domain.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;

public static class PostMapper
{
	extension(Post post)
	{
		internal PostResponse ToFullResponse<T>(
			T request)
			where T : ICurrentUserableQuery
		{
			return new(post.Id,
					   post.UserId,
					   post.Title,
					   post.Content,
					   post.User?.ToFullResponse(),
					   post.PostLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUser.Id)),
					   post.CreatedAtUtc,
					   post.UpdatedAtUtc);
		}

		internal PostResponse ToResponseWithoutUser<T>(
			T request)
			where T : ICurrentUserableQuery
		{
			return new(post.Id,
					   post.UserId,
					   post.Title,
					   post.Content,
					   null,
					   post.PostLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUser.Id)),
					   post.CreatedAtUtc,
					   post.UpdatedAtUtc);
		}

		public Post ToFull(AddPostCommand command)
		{
			return new(post.Id,
					   command.Title,
					   command.Content,
					   command.UserId,
					   post.CreatedAtUtc,
					   post.UpdatedAtUtc);
		}

		public PostId ToResponse(
			AddPostCommand command)
		{
			return post.ToId();
		}

		public PostId ToResponse(
			UpdatePostCommand command)
		{
			return post.ToId();
		}

		public PostResponse ToResponse(
			GetPostByIdQuery query)
		{
			return post.ToFullResponse(query);
		}
	}

	extension(ICollection<Post> posts)
	{
		public ICollection<PostResponse> ToResponse(
			GetAllPostsQuery query)
		{
			return posts.Filter<Post, GetAllPostsQuery, PostsPaginationQuery, PostResponse>(post => post.MatchesFilter(query), query, post => post.ToFullResponse(query));
		}

		public ICollection<PostResponse> ToResponse(
			User user,
			GetAllPostsForUserQuery query)
		{
			return posts.Filter<Post, GetAllPostsForUserQuery, PostsPaginationQuery, PostResponse>(post => post.MatchesFilter(query), query, post => post.ToResponseWithoutUser(query));
		}

		public long ToTotalCountResponse(
			GetAllPostsQuery query)
		{
			return posts.Count(post => post.MatchesFilter(query));
		}

		public long ToTotalCountResponse(
			GetAllPostsForUserQuery query)
		{
			return posts.Count(post => post.MatchesFilter(query));
		}
	}
}
