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
		AddPostCommand command,
		Post post)
		{
			return response.Matches(post.Id);
		}

		public bool Matches(
		UpdatePostCommand command,
		Post post)
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
		public bool MatchesFull<TQuery>(TQuery request, Post? post)
		where TQuery : ICurrentUserableQuery
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

		public bool MatchesWithoutUser<TQuery>(TQuery request, Post? post)
			where TQuery : ICurrentUserableQuery
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

		public bool Matches(GetPostByIdQuery query, Post post)
		{
			return response.MatchesFull(query, post);
		}
	}

	extension(PostCollectionResponse response)
	{
		public bool MatchesFull<TQuery>(
		TQuery request,
		Func<PostResponse, Post, bool> matches,
		Func<Post, bool> matchesFilter,
		User user,
		ICollection<Post> posts)
		where TQuery : ICurrentUserableQuery, IPaginatableQuery<PostsPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, posts.Count(matchesFilter)) &&
				   response.User.MatchesFull(user) &&
				   response.Posts.MatchesCollection(request.Pagination,
				                                    posts,
													response => response.Id,
													post => post.Id,
													matches,
													matchesFilter);
		}

		public bool MatchesFull<TQuery>(
			TQuery request,
			Func<PostResponse, Post, bool> matches,
			Func<Post, bool> matchesFilter,
			User user,
			ICollection<Post> posts,
			ISortEnumTermTransformer<Post> termTransformer)
			where TQuery : ICurrentUserableQuery, IPaginatableQuery<PostsPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, posts.Count(matchesFilter)) &&
				   response.User.MatchesFull(user) &&
				   response.Posts.MatchesSortedCollection(request.Pagination,
														  posts,
														  matches,
														  termTransformer,
														  matchesFilter);
		}

		public bool MatchesWithoutUser<TQuery>(
			TQuery request,
			Func<PostResponse, Post, bool> matches,
			Func<Post, bool> matchesFilter,
			ICollection<Post> posts)
			where TQuery : ICurrentUserableQuery, IPaginatableQuery<PostsPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, posts.Count(matchesFilter)) &&
				   response.User == null &&
				   response.Posts.MatchesCollection(request.Pagination,
													posts,
													response => response.Id,
													post => post.Id,
													matches,
													matchesFilter);
		}

		public bool MatchesWithoutUser<TQuery>(
			TQuery request,
			Func<PostResponse, Post, bool> matches,
			Func<Post, bool> matchesFilter,
			ICollection<Post> posts,
			ISortEnumTermTransformer<Post> termTransformer)
			where TQuery : ICurrentUserableQuery, IPaginatableQuery<PostsPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, posts.Count(matchesFilter)) &&
				   response.User == null &&
				   response.Posts.MatchesSortedCollection(request.Pagination,
														  posts,
														  matches,
														  termTransformer,
														  matchesFilter);
		}

		public bool Matches(
		GetAllPostsQuery query,
		ICollection<Post> posts)
		{
			return response.MatchesWithoutUser(
					   query,
					   (response, post) => response.MatchesFull(query, post),
					   post => post.MatchesFilter(query.Filter),
					   posts);
		}

		public bool Matches(
			GetAllPostsQuery query,
			ICollection<Post> posts,
			ISortEnumTermTransformer<Post> termTransformer)
		{
			return response.MatchesWithoutUser(
					   query,
					   (response, post) => response.MatchesFull(query, post),
					   post => post.MatchesFilter(query.Filter),
					   posts,
					   termTransformer);
		}

		public bool Matches(
		GetAllPostsForUserQuery query,
		User user,
		ICollection<Post> posts)
		{
			return response.MatchesFull(
					   query,
					   (response, post) => response.MatchesWithoutUser(query, post),
					   post => post.MatchesFilter(query.Filter),
					   user,
					   posts);
		}

		public bool Matches(
			GetAllPostsForUserQuery query,
			User user,
			ICollection<Post> posts,
			ISortEnumTermTransformer<Post> termTransformer)
		{
			return response.MatchesFull(
					   query,
					   (response, post) => response.MatchesWithoutUser(query, post),
					   post => post.MatchesFilter(query.Filter),
					   user,
					   posts,
					   termTransformer);
		}
	}
}
