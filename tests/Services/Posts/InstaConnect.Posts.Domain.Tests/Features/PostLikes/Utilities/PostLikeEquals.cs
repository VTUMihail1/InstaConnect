using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Domain.Features.Messaging.Abstractions;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Domain.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Events.Features.PostLikes;

namespace InstaConnect.Posts.Domain.Tests.Features.PostLikes.Utilities;

public static class PostLikeEquals
{
	extension(PostLikeId response)
	{
		public bool Matches(
		PostLike postLike,
		AddPostLikeCommand command)
		{
			return response.Matches(postLike.Id);
		}
	}

	extension(PostLikeAddedEventRequest request)
	{
		public bool Matches(AddPostLikeCommand command, PostLike entity)
		{
			return command.Id.Matches(request.PostLike.Id) &&
				   command.UserId.Matches(request.PostLike.UserId) &&
				   entity.User != null && entity.User.Matches(request.PostLike.User) &&
				   entity.Post != null && entity.Post.Matches(request.PostLike.Post) &&
				   entity.CreatedAtUtc == request.PostLike.CreatedAtUtc;
		}
	}

	extension(PostLikeDeletedEventRequest request)
	{
		public bool Matches(DeletePostLikeCommand command, PostLike entity)
		{
			return entity.Id.Matches(command.Id) &&
				   entity.User != null && entity.User.Matches(request.PostLike.User) &&
				   entity.Post != null && entity.Post.Matches(request.PostLike.Post) &&
				   entity.CreatedAtUtc == request.PostLike.CreatedAtUtc;
		}
	}

	extension(PostLike postLike)
	{
		public bool Matches(AddPostLikeCommand command)
		{
			return postLike.Id.Matches(command.Id.Id, command.UserId.Id);
		}

		public bool Matches(DeletePostLikeCommand command)
		{
			return postLike.Id.Matches(command.Id);
		}

		public bool MatchesFilter(PostLikesFilterQuery query)
		{
			return postLike.Id.Id.Matches(query.Id) &&
				   postLike.User != null &&
				   postLike.User.Name.Value.StartsWithOrdinalIgnoreCase(query.UserName.Value);
		}

		public bool MatchesFilter(PostLikesForUserFilterQuery query)
		{
			return postLike.Id.UserId.Matches(query.UserId);
		}
	}

	extension(PostInclude p)
	{
		public bool Matches(AddPostLikeCommand command, PostInclude include)
		{
			return p.Matches(include);
		}
	}

	extension(PostLikeInclude p)
	{
		public bool Matches(DeletePostLikeCommand command, PostLikeInclude include)
		{
			return p.Matches(include);
		}
	}

	extension(PostLikeResponse? response)
	{
		public bool MatchesFull<T>(PostLike? postLike, T request)
		where T : ICurrentUserableQuery
		{
			return response != null &&
				   postLike != null &&
				   postLike.Id.Matches(response.Id) &&
				   postLike.CreatedAtUtc == response.CreatedAtUtc &&
				   response.User.MatchesFull(postLike.User) &&
				   response.Post.MatchesFull(postLike.Post, request);
		}

		public bool MatchesWithoutUser<T>(PostLike? postLike, T request)
			where T : ICurrentUserableQuery
		{
			return response != null &&
				   postLike != null &&
				   postLike.Id.Matches(response.Id) &&
				   postLike.CreatedAtUtc == response.CreatedAtUtc &&
				   response.User == null &&
				   response.Post.MatchesFull(postLike.Post, request);
		}

		public bool MatchesWithoutPost<T>(PostLike? postLike, T request)
			where T : ICurrentUserableQuery
		{
			return response != null &&
				   postLike != null &&
				   postLike.Id.Matches(response.Id) &&
				   postLike.CreatedAtUtc == response.CreatedAtUtc &&
				   response.User.MatchesFull(postLike.User) &&
				   response.Post == null;
		}

		public bool Matches(PostLike postLike, GetPostLikeByIdQuery query)
		{
			return response.MatchesFull(postLike, query);
		}
	}

	extension(PostLikeCollectionResponse response)
	{
		public bool MatchesWithoutUser<T>(
		Func<PostLikeResponse, PostLike, bool> matches,
		Func<PostLike, bool> matchesFilter,
		Post post,
		ICollection<PostLike> postLikes,
		T request)
		where T : ICurrentUserableQuery, IPaginatableQuery<PostLikesPaginationQuery>
		{
			return response.MatchesCollectionResponse(postLikes.Count(matchesFilter), request.Pagination) &&
				   response.User == null &&
				   response.Post.MatchesFull(post, request) &&
				   response.PostLikes.MatchesCollection(postLikes,
													response => response.Id,
													postLike => postLike.Id,
													matches,
													request.Pagination,
													matchesFilter);
		}

		public bool MatchesWithoutUser<T>(
			Func<PostLikeResponse, PostLike, bool> matches,
			Func<PostLike, bool> matchesFilter,
			Post post,
			ICollection<PostLike> postLikes,
			T request,
			ISortEnumTermTransformer<PostLike> termTransformer)
			where T : ICurrentUserableQuery, IPaginatableQuery<PostLikesPaginationQuery>
		{
			return response.MatchesCollectionResponse(postLikes.Count(matchesFilter), request.Pagination) &&
				   response.User == null &&
				   response.Post.MatchesFull(post, request) &&
				   response.PostLikes.MatchesSortedCollection(postLikes,
														  matches,
														  termTransformer,
														  request.Pagination,
														  matchesFilter);
		}

		public bool MatchesWithoutPost<T>(
			Func<PostLikeResponse, PostLike, bool> matches,
			Func<PostLike, bool> matchesFilter,
			User user,
			ICollection<PostLike> postLikes,
			T request)
			where T : ICurrentUserableQuery, IPaginatableQuery<PostLikesPaginationQuery>
		{
			return response.MatchesCollectionResponse(postLikes.Count(matchesFilter), request.Pagination) &&
				   response.User.MatchesFull(user) &&
				   response.Post == null &&
				   response.PostLikes.MatchesCollection(postLikes,
													response => response.Id,
													postLike => postLike.Id,
													matches,
													request.Pagination,
													matchesFilter);
		}

		public bool MatchesWithoutPost<T>(
			Func<PostLikeResponse, PostLike, bool> matches,
			Func<PostLike, bool> matchesFilter,
			User user,
			ICollection<PostLike> postLikes,
			T request,
			ISortEnumTermTransformer<PostLike> termTransformer)
			where T : ICurrentUserableQuery, IPaginatableQuery<PostLikesPaginationQuery>
		{
			return response.MatchesCollectionResponse(postLikes.Count(matchesFilter), request.Pagination) &&
				   response.User.MatchesFull(user) &&
				   response.Post == null &&
				   response.PostLikes.MatchesSortedCollection(postLikes,
														  matches,
														  termTransformer,
														  request.Pagination,
														  matchesFilter);
		}

		public bool Matches(
		Post post,
		ICollection<PostLike> postLikes,
		GetAllPostLikesQuery query)
		{
			return response.MatchesWithoutUser(
					   (response, postLike) => response.MatchesWithoutPost(postLike, query),
					   postLike => postLike.MatchesFilter(query.Filter),
					   post,
					   postLikes,
					   query);
		}

		public bool Matches(
			Post post,
			ICollection<PostLike> postLikes,
			GetAllPostLikesQuery query,
			ISortEnumTermTransformer<PostLike> termTransformer)
		{
			return response.MatchesWithoutUser(
					   (response, postLike) => response.MatchesWithoutPost(postLike, query),
					   postLike => postLike.MatchesFilter(query.Filter),
					   post,
					   postLikes,
					   query,
					   termTransformer);
		}

		public bool Matches(
		User user,
		ICollection<PostLike> postLikes,
		GetAllPostLikesForUserQuery query)
		{
			return response.MatchesWithoutPost(
					   (response, postLike) => response.MatchesWithoutUser(postLike, query),
					   postLike => postLike.MatchesFilter(query.Filter),
					   user,
					   postLikes,
					   query);
		}

		public bool Matches(
			User user,
			ICollection<PostLike> postLikes,
			GetAllPostLikesForUserQuery query,
			ISortEnumTermTransformer<PostLike> termTransformer)
		{
			return response.MatchesWithoutPost(
					   (response, postLike) => response.MatchesWithoutUser(postLike, query),
					   postLike => postLike.MatchesFilter(query.Filter),
					   user,
					   postLikes,
					   query,
					   termTransformer);
		}
	}
}
