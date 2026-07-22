using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Models;
using InstaConnect.Posts.Application.Features.Users.Abstractions;
using InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Events.Features.PostCommentLikes;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeEquals
{
	extension(PostCommentLikeAddedEventRequest r)
	{
		public bool Matches(AddPostCommentLikeCommandRequest request, PostCommentLike entity)
		{
			return request.Id.EqualsOrdinalIgnoreCase(r.PostCommentLike.Id) &&
				   request.CommentId.EqualsOrdinalIgnoreCase(r.PostCommentLike.CommentId) &&
				   request.UserId.EqualsOrdinalIgnoreCase(r.PostCommentLike.UserId) &&
				   entity.User != null && entity.User.Matches(r.PostCommentLike.User) &&
				   entity.PostComment != null && entity.PostComment.Matches(r.PostCommentLike.PostComment) &&
				   entity.CreatedAtUtc == r.PostCommentLike.CreatedAtUtc;
		}
	}

	extension(PostCommentLikeDeletedEventRequest r)
	{
		public bool Matches(DeletePostCommentLikeCommandRequest request, PostCommentLike entity)
		{
			return request.Id.EqualsOrdinalIgnoreCase(r.PostCommentLike.Id) &&
				   request.CommentId.EqualsOrdinalIgnoreCase(r.PostCommentLike.CommentId) &&
				   request.UserId.EqualsOrdinalIgnoreCase(r.PostCommentLike.UserId) &&
				   entity.User != null && entity.User.Matches(r.PostCommentLike.User) &&
				   entity.PostComment != null && entity.PostComment.Matches(r.PostCommentLike.PostComment) &&
				   entity.CreatedAtUtc == r.PostCommentLike.CreatedAtUtc;
		}
	}

	extension(GetAllPostCommentLikesQuery query)
	{
		public bool Matches(GetAllPostCommentLikesQueryRequest request)
		{
			return query.MatchesFilter(request) &&
				   query.MatchesSortable<GetAllPostCommentLikesQuery, PostCommentLikesSortTerm, PostCommentLikesSortingQuery, GetAllPostCommentLikesQueryRequest>(request) &&
				   query.MatchesPaginatable<GetAllPostCommentLikesQuery, PostCommentLikesPaginationQuery, GetAllPostCommentLikesQueryRequest>(request) &&
				   query.MatchesCurrentUserable(request);
		}

		public bool MatchesFilter(GetAllPostCommentLikesQueryRequest request)
		{
			return query.Filter.CommentId.Matches(request.Id, request.CommentId) &&
				   query.Filter.UserName.Matches(request.UserName);
		}
	}

	extension(GetAllPostCommentLikesForUserQuery query)
	{
		public bool Matches(GetAllPostCommentLikesForUserQueryRequest request)
		{
			return query.MatchesFilter(request) &&
				   query.MatchesSortable<GetAllPostCommentLikesForUserQuery, PostCommentLikesForUserSortTerm, PostCommentLikesForUserSortingQuery, GetAllPostCommentLikesForUserQueryRequest>(request) &&
				   query.MatchesPaginatable<GetAllPostCommentLikesForUserQuery, PostCommentLikesPaginationQuery, GetAllPostCommentLikesForUserQueryRequest>(request) &&
				   query.MatchesCurrentUserable(request);
		}

		public bool MatchesFilter(GetAllPostCommentLikesForUserQueryRequest request)
		{
			return query.Filter.UserId.Matches(request.UserId);
		}
	}

	extension(GetPostCommentLikeByIdQuery query)
	{
		public bool Matches(GetPostCommentLikeByIdQueryRequest request)
		{
			return query.Id.Matches(request.Id, request.CommentId, request.UserId) &&
				   query.MatchesCurrentUserable(request);
		}
	}

	extension(AddPostCommentLikeCommand command)
	{
		public bool Matches(AddPostCommentLikeCommandRequest request)
		{
			return command.CommentId.Matches(request.Id, request.CommentId) &&
				   command.UserId.Matches(request.UserId);
		}
	}

	extension(DeletePostCommentLikeCommand command)
	{
		public bool Matches(DeletePostCommentLikeCommandRequest request)
		{
			return command.Id.Matches(request.Id, request.CommentId, request.UserId);
		}
	}

	extension(AddPostCommentLikeCommandResponse response)
	{
		public bool Matches(AddPostCommentLikeCommandRequest request, PostCommentLike postCommentLike)
		{
			return response.Response.Matches(postCommentLike.Id);
		}
	}

	extension(GetPostCommentLikeByIdQueryResponse response)
	{
		public bool Matches(GetPostCommentLikeByIdQueryRequest request, PostCommentLike postCommentLike)
		{
			return response.Response.MatchesFull(request, postCommentLike);
		}
	}

	extension(GetAllPostCommentLikesQueryResponse response)
	{
		public bool Matches(GetAllPostCommentLikesQueryRequest request, PostComment postComment, ICollection<PostCommentLike> postCommentLikes)
		{
			return response.Response.MatchesWithoutUser(
					   request,
					   (response, postCommentLike) => response.MatchesWithoutPostComment(request, postCommentLike),
					   postCommentLike => postCommentLike.MatchesFilter(request),
					   postComment,
					   postCommentLikes);
		}

		public bool Matches(GetAllPostCommentLikesQueryRequest request, PostComment postComment, ICollection<PostCommentLike> postCommentLikes, ISortEnumTermTransformer<PostCommentLike> termTransformer)
		{
			return response.Response.MatchesWithoutUser(
					   request,
					   (response, postCommentLike) => response.MatchesWithoutPostComment(request, postCommentLike),
					   postCommentLike => postCommentLike.MatchesFilter(request),
					   postComment,
					   postCommentLikes,
					   termTransformer);
		}
	}

	extension(GetAllPostCommentLikesForUserQueryResponse response)
	{
		public bool Matches(GetAllPostCommentLikesForUserQueryRequest request, User user, ICollection<PostCommentLike> postCommentLikes)
		{
			return response.Response.MatchesWithoutPostComment(
					   request,
					   (response, postCommentLike) => response.MatchesWithoutUser(request, postCommentLike),
					   postCommentLike => postCommentLike.MatchesFilter(request),
					   user,
					   postCommentLikes);
		}

		public bool Matches(GetAllPostCommentLikesForUserQueryRequest request, User user, ICollection<PostCommentLike> postCommentLikes, ISortEnumTermTransformer<PostCommentLike> termTransformer)
		{
			return response.Response.MatchesWithoutPostComment(
					   request,
					   (response, postCommentLike) => response.MatchesWithoutUser(request, postCommentLike),
					   postCommentLike => postCommentLike.MatchesFilter(request),
					   user,
					   postCommentLikes,
					   termTransformer);
		}
	}

	extension(PostCommentLike postCommentLike)
	{
		public bool Matches(AddPostCommentLikeCommandRequest request)
		{
			return postCommentLike.Id.Matches(request.Id, request.CommentId, request.UserId);
		}

		public bool MatchesFilter(GetAllPostCommentLikesQueryRequest request)
		{
			return postCommentLike.Id.CommentId.Matches(request.Id, request.CommentId) &&
				   postCommentLike.User != null &&
				   postCommentLike.User.Name.Value.StartsWithOrdinalIgnoreCase(request.UserName);
		}

		public bool MatchesFilter(GetAllPostCommentLikesForUserQueryRequest request)
		{
			return postCommentLike.Id.UserId.Matches(request.UserId);
		}
	}

	extension(PostCommentLikeIdCommandResponse response)
	{
		public bool Matches(PostCommentLikeId id)
		{
			return id.Matches(response.Id, response.CommentId, response.UserId);
		}
	}

	extension(PostCommentLikeQueryResponse? response)
	{
		public bool MatchesFull<TRequest>(TRequest request, PostCommentLike? postCommentLike)
			where TRequest : ICurrentUserableQueryRequest
		{
			return response != null &&
				   postCommentLike != null &&
				   postCommentLike.Id.Matches(response.Id, response.CommentId, response.UserId) &&
				   postCommentLike.CreatedAtUtc == response.CreatedAtUtc &&
				   response.User.MatchesFull(postCommentLike.User) &&
				   response.PostComment.MatchesFull(request, postCommentLike.PostComment);
		}

		public bool MatchesWithoutPostComment<TRequest>(TRequest request, PostCommentLike? postCommentLike)
			where TRequest : ICurrentUserableQueryRequest
		{
			return response != null &&
				   postCommentLike != null &&
				   postCommentLike.Id.Matches(response.Id, response.CommentId, response.UserId) &&
				   postCommentLike.CreatedAtUtc == response.CreatedAtUtc &&
				   response.User.MatchesFull(postCommentLike.User) &&
				   response.PostComment == null;
		}

		public bool MatchesWithoutUser<TRequest>(TRequest request, PostCommentLike? postCommentLike)
			where TRequest : ICurrentUserableQueryRequest
		{
			return response != null &&
				   postCommentLike != null &&
				   postCommentLike.Id.Matches(response.Id, response.CommentId, response.UserId) &&
				   postCommentLike.CreatedAtUtc == response.CreatedAtUtc &&
				   response.User == null &&
				   response.PostComment.MatchesFull(request, postCommentLike.PostComment);
		}
	}

	extension(PostCommentLikeCollectionQueryResponse response)
	{
		public bool MatchesWithoutUser<TRequest>(
			TRequest request,
			Func<PostCommentLikeQueryResponse, PostCommentLike, bool> matches,
			Func<PostCommentLike, bool> matchesFilter,
			PostComment postComment,
			ICollection<PostCommentLike> postCommentLikes)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			return response.MatchesCollectionResponse(request, postCommentLikes.Count(matchesFilter)) &&
				   response.User == null &&
				   response.PostComment.MatchesFull(request, postComment) &&
				   response.PostCommentLikes.MatchesCollection(request,
														postCommentLikes,
														response => new(new(new(response.Id), response.CommentId), new(response.UserId)),
														postCommentLike => postCommentLike.Id,
														matches,
														matchesFilter);
		}

		public bool MatchesWithoutUser<TRequest>(
			TRequest request,
			Func<PostCommentLikeQueryResponse, PostCommentLike, bool> matches,
			Func<PostCommentLike, bool> matchesFilter,
			PostComment postComment,
			ICollection<PostCommentLike> postCommentLikes,
			ISortEnumTermTransformer<PostCommentLike> termTransformer)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			return response.MatchesCollectionResponse(request, postCommentLikes.Count(matchesFilter)) &&
				   response.User == null &&
				   response.PostComment.MatchesFull(request, postComment) &&
				   response.PostCommentLikes.MatchesSortedCollection(request,
															  postCommentLikes,
															  matches,
															  termTransformer,
															  matchesFilter);
		}

		public bool MatchesWithoutPostComment<TRequest>(
			TRequest request,
			Func<PostCommentLikeQueryResponse, PostCommentLike, bool> matches,
			Func<PostCommentLike, bool> matchesFilter,
			User user,
			ICollection<PostCommentLike> postCommentLikes)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			return response.MatchesCollectionResponse(request, postCommentLikes.Count(matchesFilter)) &&
				   response.User.MatchesFull(user) &&
				   response.PostComment == null &&
				   response.PostCommentLikes.MatchesCollection(request,
														postCommentLikes,
														response => new(new(new(response.Id), response.CommentId), new(response.UserId)),
														postCommentLike => postCommentLike.Id,
														matches,
														matchesFilter);
		}

		public bool MatchesWithoutPostComment<TRequest>(
			TRequest request,
			Func<PostCommentLikeQueryResponse, PostCommentLike, bool> matches,
			Func<PostCommentLike, bool> matchesFilter,
			User user,
			ICollection<PostCommentLike> postCommentLikes,
			ISortEnumTermTransformer<PostCommentLike> termTransformer)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			return response.MatchesCollectionResponse(request, postCommentLikes.Count(matchesFilter)) &&
				   response.User.MatchesFull(user) &&
				   response.PostComment == null &&
				   response.PostCommentLikes.MatchesSortedCollection(request,
															  postCommentLikes,
															  matches,
															  termTransformer,
															  matchesFilter);
		}
	}
}
