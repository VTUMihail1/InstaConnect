using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Presentation.Features.Messaging.Abstractions;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Presentation.Features.Users.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Events.Features.PostLikes;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;

public static class PostLikeEquals
{
	extension(PostLikeAddedEventRequest r)
	{
		public bool Matches(AddPostLikeApiRequest request, PostLike entity)
		{
			return request.Id.EqualsOrdinalIgnoreCase(r.PostLike.Id) &&
				   request.UserId.EqualsOrdinalIgnoreCase(r.PostLike.UserId) &&
				   entity.User != null && entity.User.Matches(r.PostLike.User) &&
				   entity.Post != null && entity.Post.Matches(r.PostLike.Post) &&
				   entity.CreatedAtUtc == r.PostLike.CreatedAtUtc;
		}
	}

	extension(PostLikeDeletedEventRequest r)
	{
		public bool Matches(DeletePostLikeApiRequest request, PostLike entity)
		{
			return request.Id.EqualsOrdinalIgnoreCase(r.PostLike.Id) &&
				   request.UserId.EqualsOrdinalIgnoreCase(r.PostLike.UserId) &&
				   entity.User != null && entity.User.Matches(r.PostLike.User) &&
				   entity.Post != null && entity.Post.Matches(r.PostLike.Post) &&
				   entity.CreatedAtUtc == r.PostLike.CreatedAtUtc;
		}
	}

	extension(GetAllPostLikesQueryRequest query)
	{
		public bool Matches(GetAllPostLikesApiRequest request)
		{
			return query.MatchesFilter(request) &&
				   query.MatchesSortable<GetAllPostLikesQueryRequest, PostLikesSortTerm, GetAllPostLikesApiRequest>(request) &&
				   query.MatchesPaginatable(request) &&
				   query.MatchesCurrentUserable(request);
		}

		public bool MatchesFilter(GetAllPostLikesApiRequest request)
		{
			return query.Id == request.Id &&
				   query.UserName == request.UserName;
		}
	}

	extension(GetAllPostLikesForUserQueryRequest query)
	{
		public bool Matches(GetAllPostLikesForUserApiRequest request)
		{
			return query.MatchesFilter(request) &&
				   query.MatchesSortable<GetAllPostLikesForUserQueryRequest, PostLikesForUserSortTerm, GetAllPostLikesForUserApiRequest>(request) &&
				   query.MatchesPaginatable(request) &&
				   query.MatchesCurrentUserable(request);
		}

		public bool MatchesFilter(GetAllPostLikesForUserApiRequest request)
		{
			return query.UserId == request.UserId;
		}
	}

	extension(GetPostLikeByIdQueryRequest query)
	{
		public bool Matches(GetPostLikeByIdApiRequest request)
		{
			return query.Id == request.Id &&
				   query.UserId == request.UserId &&
				   query.MatchesCurrentUserable(request);
		}
	}

	extension(AddPostLikeCommandRequest command)
	{
		public bool Matches(AddPostLikeApiRequest request)
		{
			return command.Id == request.Id &&
				   command.UserId == request.UserId;
		}
	}

	extension(DeletePostLikeCommandRequest command)
	{
		public bool Matches(DeletePostLikeApiRequest request)
		{
			return command.Id == request.Id &&
				   command.UserId == request.UserId;
		}
	}

	extension(AddPostLikeApiResponse response)
	{
		public bool Matches(
		AddPostLikeApiRequest request,
		PostLike postLike)
		{
			return response.Response.Matches(postLike.Id);
		}
	}

	extension(GetPostLikeByIdApiResponse response)
	{
		public bool Matches(GetPostLikeByIdApiRequest request, PostLike postLike)
		{
			return response.Response.MatchesFull(request, postLike);
		}
	}

	extension(GetAllPostLikesApiResponse response)
	{
		public bool Matches(
		GetAllPostLikesApiRequest request,
		Post post,
		ICollection<PostLike> postLikes)
		{
			return response.Response.MatchesWithoutUser(
					   request,
					   (response, postLike) => response.MatchesWithoutPost(request, postLike),
					   postLike => postLike.MatchesFilter(request),
					   post,
					   postLikes);
		}

		public bool Matches(
			GetAllPostLikesApiRequest request,
			Post post,
			ICollection<PostLike> postLikes,
			ISortEnumTermTransformer<PostLike> termTransformer)
		{
			return response.Response.MatchesWithoutUser(
					   request,
					   (response, postLike) => response.MatchesWithoutPost(request, postLike),
					   postLike => postLike.MatchesFilter(request),
					   post,
					   postLikes,
					   termTransformer);
		}
	}

	extension(GetAllPostLikesForUserApiResponse response)
	{
		public bool Matches(
		GetAllPostLikesForUserApiRequest request,
		User user,
		ICollection<PostLike> postLikes)
		{
			return response.Response.MatchesWithoutPost(
					   request,
					   (response, postLike) => response.MatchesWithoutUser(request, postLike),
					   postLike => postLike.MatchesFilter(request),
					   user,
					   postLikes);
		}

		public bool Matches(
			GetAllPostLikesForUserApiRequest request,
			User user,
			ICollection<PostLike> postLikes,
			ISortEnumTermTransformer<PostLike> termTransformer)
		{
			return response.Response.MatchesWithoutPost(
					   request,
					   (response, postLike) => response.MatchesWithoutUser(request, postLike),
					   postLike => postLike.MatchesFilter(request),
					   user,
					   postLikes,
					   termTransformer);
		}
	}

	extension(PostLike postLike)
	{
		public bool Matches(AddPostLikeApiRequest request)
		{
			return postLike.Id.Matches(request.Id, request.UserId);
		}

		public bool MatchesFilter(GetAllPostLikesApiRequest request)
		{
			return postLike.Id.Id.Matches(request.Id) &&
				   postLike.User != null &&
				   postLike.User.Name.Value.StartsWithOrdinalIgnoreCase(request.UserName);
		}

		public bool MatchesFilter(GetAllPostLikesForUserApiRequest request)
		{
			return postLike.Id.UserId.Matches(request.UserId);
		}
	}

	extension(PostLikeIdApiResponse response)
	{
		public bool Matches(PostLikeId id)
		{
			return id.Matches(response.Id, response.UserId);
		}
	}

	extension(PostLikeApiResponse? response)
	{
		public bool MatchesFull<TRequest>(TRequest request, PostLike? postLike)
		where TRequest : ICurrentUserableApiRequest
		{
			return response != null &&
				   postLike != null &&
				   postLike.Id.Matches(response.Id, response.UserId) &&
				   postLike.CreatedAtUtc == response.CreatedAtUtc &&
				   response.User.MatchesFull(postLike.User) &&
				   response.Post.MatchesFull(request, postLike.Post);
		}

		public bool MatchesWithoutUser<TRequest>(TRequest request, PostLike? postLike)
			where TRequest : ICurrentUserableApiRequest
		{
			return response != null &&
				   postLike != null &&
				   postLike.Id.Matches(response.Id, response.UserId) &&
				   postLike.CreatedAtUtc == response.CreatedAtUtc &&
				   response.User == null &&
				   response.Post.MatchesFull(request, postLike.Post);
		}

		public bool MatchesWithoutPost<TRequest>(TRequest request, PostLike? postLike)
			where TRequest : ICurrentUserableApiRequest
		{
			return response != null &&
				   postLike != null &&
				   postLike.Id.Matches(response.Id, response.UserId) &&
				   postLike.CreatedAtUtc == response.CreatedAtUtc &&
				   response.User.MatchesFull(postLike.User) &&
				   response.Post == null;
		}
	}

	extension(PostLikeCollectionApiResponse response)
	{
		public bool MatchesWithoutUser<TRequest>(
		TRequest request,
		Func<PostLikeApiResponse, PostLike, bool> matches,
		Func<PostLike, bool> matchesFilter,
		Post post,
		ICollection<PostLike> postLikes)
		where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			return response.MatchesCollectionResponse(request, postLikes.Count(matchesFilter)) &&
				   response.User == null &&
				   response.Post.MatchesFull(request, post) &&
				   response.PostLikes.MatchesCollection(request,
														postLikes,
														response => new(new(response.Id), new(response.UserId)),
														postLike => postLike.Id,
														matches,
														matchesFilter);
		}

		public bool MatchesWithoutUser<TRequest>(
			TRequest request,
			Func<PostLikeApiResponse, PostLike, bool> matches,
			Func<PostLike, bool> matchesFilter,
			Post post,
			ICollection<PostLike> postLikes,
			ISortEnumTermTransformer<PostLike> termTransformer)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			return response.MatchesCollectionResponse(request, postLikes.Count(matchesFilter)) &&
				   response.User == null &&
				   response.Post.MatchesFull(request, post) &&
				   response.PostLikes.MatchesSortedCollection(request,
															  postLikes,
															  matches,
															  termTransformer,
															  matchesFilter);
		}

		public bool MatchesWithoutPost<TRequest>(
			TRequest request,
			Func<PostLikeApiResponse, PostLike, bool> matches,
			Func<PostLike, bool> matchesFilter,
			User user,
			ICollection<PostLike> postLikes)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			return response.MatchesCollectionResponse(request, postLikes.Count(matchesFilter)) &&
				   response.User.MatchesFull(user) &&
				   response.Post == null &&
				   response.PostLikes.MatchesCollection(request,
														postLikes,
														response => new(new(response.Id), new(response.UserId)),
														postLike => postLike.Id,
														matches,
														matchesFilter);
		}

		public bool MatchesWithoutPost<TRequest>(
			TRequest request,
			Func<PostLikeApiResponse, PostLike, bool> matches,
			Func<PostLike, bool> matchesFilter,
			User user,
			ICollection<PostLike> postLikes,
			ISortEnumTermTransformer<PostLike> termTransformer)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			return response.MatchesCollectionResponse(request, postLikes.Count(matchesFilter)) &&
				   response.User.MatchesFull(user) &&
				   response.Post == null &&
				   response.PostLikes.MatchesSortedCollection(request,
															  postLikes,
															  matches,
															  termTransformer,
															  matchesFilter);
		}
	}
}
