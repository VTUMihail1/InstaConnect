using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Domain.Features.Messaging.Abstractions;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Domain.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Events.Features.Posts;

namespace InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;

public static class PostEquals
{
	extension(PostId response)
	{
		public bool Matches(
		Post post,
		AddPostCommand command)
		{
			return response.Matches(post.Id);
		}

		public bool Matches(
		Post post,
		UpdatePostCommand command)
		{
			return response.Matches(post.Id);
		}
	}

	extension(Post p)
	{
		public bool Matches(AddPostCommand command)
		{
			return p.UserId.Matches(command.UserId) &&
				   p.Title == command.Title &&
				   p.Content == command.Content;
		}

		public bool Matches(UpdatePostCommand command)
		{
			return p.Id.Matches(command.Id) &&
				   p.UserId.Matches(command.UserId) &&
				   p.Title == command.Title &&
				   p.Content == command.Content;
		}

		public bool Matches(DeletePostCommand command)
		{
			return p.Id.Matches(command.Id) &&
				   p.UserId.Matches(command.UserId);
		}

		public bool MatchesFilter(PostsFilterQuery query)
		{
			return p.User != null &&
				   p.User.Name.Value.StartsWithOrdinalIgnoreCase(query.UserName.Value) &&
				   p.Title.StartsWithOrdinalIgnoreCase(query.Title);
		}

		public bool MatchesFilter(PostsForUserFilterQuery query)
		{
			return p.UserId.Matches(query.UserId) &&
				   p.Title.StartsWithOrdinalIgnoreCase(query.Title);
		}
	}

	extension(PostInclude p)
	{
		public bool Matches(UpdatePostCommand command, PostInclude include)
		{
			return p.Matches(include);
		}

		public bool Matches(DeletePostCommand command, PostInclude include)
		{
			return p.Matches(include);
		}
	}

	extension(PostAddedEventRequest p)
	{
		public bool Matches(AddPostCommand command, Post post)
		{
			return post.Id.Matches(p.Post.Id) &&
				   command.UserId.Matches(p.Post.UserId) &&
				   post.User != null &&
				   post.User.Matches(p.Post.User) &&
				   command.Title == p.Post.Title &&
				   command.Content == p.Post.Content &&
				   post.CreatedAtUtc == p.Post.CreatedAtUtc &&
				   post.UpdatedAtUtc == p.Post.UpdatedAtUtc;
		}
	}

	extension(PostUpdatedEventRequest p)
	{
		public bool Matches(UpdatePostCommand command, Post post)
		{
			return command.Id.Matches(p.Post.Id) &&
				   command.UserId.Matches(p.Post.UserId) &&
				   post.User != null &&
				   post.User.Matches(p.Post.User) &&
				   command.Title == p.Post.Title &&
				   command.Content == p.Post.Content &&
				   post.CreatedAtUtc == p.Post.CreatedAtUtc &&
				   post.UpdatedAtUtc == p.Post.UpdatedAtUtc;
		}
	}

	extension(PostDeletedEventRequest p)
	{
		public bool Matches(DeletePostCommand command, Post post)
		{
			return post.Id.Matches(command.Id) &&
				   post.UserId.Matches(command.UserId) &&
				   post.User != null &&
				   post.User.Matches(p.Post.User) &&
				   post.Title == p.Post.Title &&
				   post.Content == p.Post.Content &&
				   post.CreatedAtUtc == p.Post.CreatedAtUtc &&
				   post.UpdatedAtUtc == p.Post.UpdatedAtUtc;
		}
	}

	extension(PostResponse? response)
	{
		public bool MatchesFull<T>(Post? post, T request)
		where T : ICurrentUserableQuery
		{
			return response != null &&
				   post != null &&
				   post.Id.Matches(response.Id) &&
				   post.UserId.Matches(response.UserId) &&
				   post.Title == response.Title &&
				   post.Content == response.Content &&
				   response.IsLikedByCurrentUser == post.PostLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUser.Id)) &&
				   post.CreatedAtUtc == response.CreatedAtUtc &&
				   post.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.User.MatchesFull(post.User);
		}

		public bool MatchesWithoutUser<T>(Post? post, T request)
			where T : ICurrentUserableQuery
		{
			return response != null &&
				   post != null &&
				   post.Id.Matches(response.Id) &&
				   post.UserId.Matches(response.UserId) &&
				   post.Title == response.Title &&
				   post.Content == response.Content &&
				   response.IsLikedByCurrentUser == post.PostLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUser.Id)) &&
				   post.CreatedAtUtc == response.CreatedAtUtc &&
				   post.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.User == null;
		}

		public bool Matches(Post post, GetPostByIdQuery query)
		{
			return response.MatchesFull(post, query);
		}
	}

	extension(PostCollectionResponse response)
	{
		public bool MatchesFull<T>(
		Func<PostResponse, Post, bool> matches,
		Func<Post, bool> matchesFilter,
		User user,
		ICollection<Post> posts,
		T request)
		where T : ICurrentUserableQuery, IPaginatableQuery<PostsPaginationQuery>
		{
			return response.MatchesCollectionResponse(posts.Count(matchesFilter), request.Pagination) &&
				   response.User.MatchesFull(user) &&
				   response.Posts.MatchesCollection(posts,
													response => response.Id,
													post => post.Id,
													matches,
													request.Pagination,
													matchesFilter);
		}

		public bool MatchesFull<T>(
			Func<PostResponse, Post, bool> matches,
			Func<Post, bool> matchesFilter,
			User user,
			ICollection<Post> posts,
			T request,
			ISortEnumTermTransformer<Post> termTransformer)
			where T : ICurrentUserableQuery, IPaginatableQuery<PostsPaginationQuery>
		{
			return response.MatchesCollectionResponse(posts.Count(matchesFilter), request.Pagination) &&
				   response.User.MatchesFull(user) &&
				   response.Posts.MatchesSortedCollection(posts,
														  matches,
														  termTransformer,
														  request.Pagination,
														  matchesFilter);
		}

		public bool MatchesWithoutUser<T>(
			Func<PostResponse, Post, bool> matches,
			Func<Post, bool> matchesFilter,
			ICollection<Post> posts,
			T request)
			where T : ICurrentUserableQuery, IPaginatableQuery<PostsPaginationQuery>
		{
			return response.MatchesCollectionResponse(posts.Count(matchesFilter), request.Pagination) &&
				   response.User == null &&
				   response.Posts.MatchesCollection(posts,
													response => response.Id,
													post => post.Id,
													matches,
													request.Pagination,
													matchesFilter);
		}

		public bool MatchesWithoutUser<T>(
			Func<PostResponse, Post, bool> matches,
			Func<Post, bool> matchesFilter,
			ICollection<Post> posts,
			T request,
			ISortEnumTermTransformer<Post> termTransformer)
			where T : ICurrentUserableQuery, IPaginatableQuery<PostsPaginationQuery>
		{
			return response.MatchesCollectionResponse(posts.Count(matchesFilter), request.Pagination) &&
				   response.User == null &&
				   response.Posts.MatchesSortedCollection(posts,
														  matches,
														  termTransformer,
														  request.Pagination,
														  matchesFilter);
		}

		public bool Matches(
		ICollection<Post> posts,
		GetAllPostsQuery query)
		{
			return response.MatchesWithoutUser(
					   (response, post) => response.MatchesFull(post, query),
					   post => post.MatchesFilter(query.Filter),
					   posts,
					   query);
		}

		public bool Matches(
			ICollection<Post> posts,
			GetAllPostsQuery query,
			ISortEnumTermTransformer<Post> termTransformer)
		{
			return response.MatchesWithoutUser(
					   (response, post) => response.MatchesFull(post, query),
					   post => post.MatchesFilter(query.Filter),
					   posts,
					   query,
					   termTransformer);
		}

		public bool Matches(
		User user,
		ICollection<Post> posts,
		GetAllPostsForUserQuery query)
		{
			return response.MatchesFull(
					   (response, post) => response.MatchesWithoutUser(post, query),
					   post => post.MatchesFilter(query.Filter),
					   user,
					   posts,
					   query);
		}

		public bool Matches(
			User user,
			ICollection<Post> posts,
			GetAllPostsForUserQuery query,
			ISortEnumTermTransformer<Post> termTransformer)
		{
			return response.MatchesFull(
					   (response, post) => response.MatchesWithoutUser(post, query),
					   post => post.MatchesFilter(query.Filter),
					   user,
					   posts,
					   query,
					   termTransformer);
		}
	}
}
