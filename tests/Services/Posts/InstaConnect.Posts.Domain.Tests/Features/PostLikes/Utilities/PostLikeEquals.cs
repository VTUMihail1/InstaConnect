using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Domain.Features.Messaging.Abstractions;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Domain.Tests.Features.Users.Utilities;

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

		public bool MatchesFilter(GetAllPostLikesQuery query)
		{
			return postLike.Id.Id.Matches(query.Filter.Id) &&
				   postLike.User != null &&
				   postLike.User.Name.Value.StartsWithOrdinalIgnoreCase(query.Filter.UserName.Value);
		}

		public bool MatchesFilter(GetAllPostLikesForUserQuery query)
		{
			return postLike.Id.UserId.Matches(query.Filter.UserId);
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
			return response.MatchesCollectionResponse<PostLikeCollectionResponse, T, PostLikesPaginationQuery>(postLikes.Count(matchesFilter), request) &&
				   response.User == null &&
				   response.Post.MatchesFull(post, request) &&
				   response.PostLikes.MatchesCollection<PostLikeResponse, PostLike, PostLikeId, T, PostLikesPaginationQuery>(postLikes,
													response => response.Id,
													postLike => postLike.Id,
													matches,
													request,
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
			return response.MatchesCollectionResponse<PostLikeCollectionResponse, T, PostLikesPaginationQuery>(postLikes.Count(matchesFilter), request) &&
				   response.User == null &&
				   response.Post.MatchesFull(post, request) &&
				   response.PostLikes.MatchesSortedCollection<PostLikeResponse, PostLike, T, PostLikesPaginationQuery>(postLikes,
														  matches,
														  termTransformer,
														  request,
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
			return response.MatchesCollectionResponse<PostLikeCollectionResponse, T, PostLikesPaginationQuery>(postLikes.Count(matchesFilter), request) &&
				   response.User.MatchesFull(user) &&
				   response.Post == null &&
				   response.PostLikes.MatchesCollection<PostLikeResponse, PostLike, PostLikeId, T, PostLikesPaginationQuery>(postLikes,
													response => response.Id,
													postLike => postLike.Id,
													matches,
													request,
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
			return response.MatchesCollectionResponse<PostLikeCollectionResponse, T, PostLikesPaginationQuery>(postLikes.Count(matchesFilter), request) &&
				   response.User.MatchesFull(user) &&
				   response.Post == null &&
				   response.PostLikes.MatchesSortedCollection<PostLikeResponse, PostLike, T, PostLikesPaginationQuery>(postLikes,
														  matches,
														  termTransformer,
														  request,
														  matchesFilter);
		}

		public bool Matches(
		Post post,
		ICollection<PostLike> postLikes,
		GetAllPostLikesQuery query)
		{
			return response.MatchesWithoutUser(
					   (response, postLike) => response.MatchesWithoutPost(postLike, query),
					   postLike => postLike.MatchesFilter(query),
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
					   postLike => postLike.MatchesFilter(query),
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
					   postLike => postLike.MatchesFilter(query),
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
					   postLike => postLike.MatchesFilter(query),
					   user,
					   postLikes,
					   query,
					   termTransformer);
		}
	}
}
