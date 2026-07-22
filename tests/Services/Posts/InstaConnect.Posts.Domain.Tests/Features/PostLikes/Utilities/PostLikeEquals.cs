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
		AddPostLikeCommand command,
		PostLike postLike)
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
				   entity.User.Matches(request.PostLike.User) &&
				   entity.Post.Matches(request.PostLike.Post) &&
				   entity.CreatedAtUtc == request.PostLike.CreatedAtUtc;
		}
	}

	extension(PostLikeDeletedEventRequest request)
	{
		public bool Matches(DeletePostLikeCommand command, PostLike entity)
		{
			return command.Id.Matches(request.PostLike.Id, request.PostLike.UserId) &&
				   entity.User.Matches(request.PostLike.User) &&
				   entity.Post.Matches(request.PostLike.Post) &&
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
		public bool MatchesFull<TQuery>(TQuery request, PostLike? postLike)
		where TQuery : ICurrentUserableQuery
		{
			return response != null &&
				   postLike != null &&
				   postLike.Id.Matches(response.Id) &&
				   postLike.CreatedAtUtc == response.CreatedAtUtc &&
				   response.User.MatchesFull(postLike.User) &&
				   response.Post.MatchesFull(request, postLike.Post);
		}

		public bool MatchesWithoutUser<TQuery>(TQuery request, PostLike? postLike)
			where TQuery : ICurrentUserableQuery
		{
			return response != null &&
				   postLike != null &&
				   postLike.Id.Matches(response.Id) &&
				   postLike.CreatedAtUtc == response.CreatedAtUtc &&
				   response.User == null &&
				   response.Post.MatchesFull(request, postLike.Post);
		}

		public bool MatchesWithoutPost(PostLike? postLike)
		{
			return response != null &&
				   postLike != null &&
				   postLike.Id.Matches(response.Id) &&
				   postLike.CreatedAtUtc == response.CreatedAtUtc &&
				   response.User.MatchesFull(postLike.User) &&
				   response.Post == null;
		}

		public bool Matches(GetPostLikeByIdQuery query, PostLike postLike)
		{
			return response.MatchesFull(query, postLike);
		}
	}

	extension(PostLikeCollectionResponse response)
	{
		public bool MatchesWithoutUser<TQuery>(
		TQuery request,
		Func<PostLikeResponse, PostLike, bool> matches,
		Func<PostLike, bool> matchesFilter,
		Post post,
		ICollection<PostLike> postLikes)
		where TQuery : ICurrentUserableQuery, IPaginatableQuery<PostLikesPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, postLikes.Count(matchesFilter)) &&
				   response.User == null &&
				   response.Post.MatchesFull(request, post) &&
				   response.PostLikes.MatchesCollection(
													request.Pagination,
													postLikes,
													response => response.Id,
													postLike => postLike.Id,
													matches,
													matchesFilter);
		}

		public bool MatchesWithoutUser<TQuery>(
			TQuery request,
			Func<PostLikeResponse, PostLike, bool> matches,
			Func<PostLike, bool> matchesFilter,
			Post post,
			ICollection<PostLike> postLikes,
			ISortEnumTermTransformer<PostLike> termTransformer)
			where TQuery : ICurrentUserableQuery, IPaginatableQuery<PostLikesPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, postLikes.Count(matchesFilter)) &&
				   response.User == null &&
				   response.Post.MatchesFull(request, post) &&
				   response.PostLikes.MatchesSortedCollection(
														  request.Pagination,
														  postLikes,
														  matches,
														  termTransformer,
														  matchesFilter);
		}

		public bool MatchesWithoutPost<TQuery>(
			TQuery request,
			Func<PostLikeResponse, PostLike, bool> matches,
			Func<PostLike, bool> matchesFilter,
			User user,
			ICollection<PostLike> postLikes)
			where TQuery : ICurrentUserableQuery, IPaginatableQuery<PostLikesPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, postLikes.Count(matchesFilter)) &&
				   response.User.MatchesFull(user) &&
				   response.Post == null &&
				   response.PostLikes.MatchesCollection(
													request.Pagination,
													postLikes,
													response => response.Id,
													postLike => postLike.Id,
													matches,
													matchesFilter);
		}

		public bool MatchesWithoutPost<TQuery>(
			TQuery request,
			Func<PostLikeResponse, PostLike, bool> matches,
			Func<PostLike, bool> matchesFilter,
			User user,
			ICollection<PostLike> postLikes,
			ISortEnumTermTransformer<PostLike> termTransformer)
			where TQuery : ICurrentUserableQuery, IPaginatableQuery<PostLikesPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, postLikes.Count(matchesFilter)) &&
				   response.User.MatchesFull(user) &&
				   response.Post == null &&
				   response.PostLikes.MatchesSortedCollection(
														  request.Pagination,
														  postLikes,
														  matches,
														  termTransformer,
														  matchesFilter);
		}

		public bool Matches(
		GetAllPostLikesQuery query,
		Post post,
		ICollection<PostLike> postLikes)
		{
			return response.MatchesWithoutUser(
					   query,
					   (response, postLike) => response.MatchesWithoutPost(postLike),
					   postLike => postLike.MatchesFilter(query.Filter),
					   post,
					   postLikes);
		}

		public bool Matches(
			GetAllPostLikesQuery query,
			Post post,
			ICollection<PostLike> postLikes,
			ISortEnumTermTransformer<PostLike> termTransformer)
		{
			return response.MatchesWithoutUser(
					   query,
					   (response, postLike) => response.MatchesWithoutPost(postLike),
					   postLike => postLike.MatchesFilter(query.Filter),
					   post,
					   postLikes,
					   termTransformer);
		}

		public bool Matches(
		GetAllPostLikesForUserQuery query,
		User user,
		ICollection<PostLike> postLikes)
		{
			return response.MatchesWithoutPost(
					   query,
					   (response, postLike) => response.MatchesWithoutUser(query, postLike),
					   postLike => postLike.MatchesFilter(query.Filter),
					   user,
					   postLikes);
		}

		public bool Matches(
			GetAllPostLikesForUserQuery query,
			User user,
			ICollection<PostLike> postLikes,
			ISortEnumTermTransformer<PostLike> termTransformer)
		{
			return response.MatchesWithoutPost(
					   query,
					   (response, postLike) => response.MatchesWithoutUser(query, postLike),
					   postLike => postLike.MatchesFilter(query.Filter),
					   user,
					   postLikes,
					   termTransformer);
		}
	}
}
