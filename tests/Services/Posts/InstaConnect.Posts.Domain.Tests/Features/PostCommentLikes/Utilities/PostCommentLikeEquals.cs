using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Domain.Features.Messaging.Abstractions;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Domain.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Events.Features.PostCommentLikes;

namespace InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeEquals
{
	extension(PostCommentLikeId response)
	{
		public bool Matches(
		AddPostCommentLikeCommand command,
		PostCommentLike postCommentLike)
		{
			return response.Matches(postCommentLike.Id);
		}
	}

	extension(PostCommentLikeAddedEventRequest request)
	{
		public bool Matches(AddPostCommentLikeCommand command, PostCommentLike entity)
		{
			return command.CommentId.Id.Matches(request.PostCommentLike.Id) &&
				   command.CommentId.CommentId == request.PostCommentLike.CommentId &&
				   command.UserId.Matches(request.PostCommentLike.UserId) &&
				   entity.User != null && entity.User.Matches(request.PostCommentLike.User) &&
				   entity.PostComment != null && entity.PostComment.Matches(request.PostCommentLike.PostComment) &&
				   entity.CreatedAtUtc == request.PostCommentLike.CreatedAtUtc;
		}
	}

	extension(PostCommentLikeDeletedEventRequest request)
	{
		public bool Matches(DeletePostCommentLikeCommand command, PostCommentLike entity)
		{
			return entity.Id.Matches(command.Id) &&
				   entity.User != null && entity.User.Matches(request.PostCommentLike.User) &&
				   entity.PostComment != null && entity.PostComment.Matches(request.PostCommentLike.PostComment) &&
				   entity.CreatedAtUtc == request.PostCommentLike.CreatedAtUtc;
		}
	}

	extension(PostCommentLike postCommentLike)
	{
		public bool Matches(AddPostCommentLikeCommand command)
		{
			return postCommentLike.Id.Matches(command.CommentId.Id.Id, command.CommentId.CommentId, command.UserId.Id);
		}

		public bool Matches(DeletePostCommentLikeCommand command)
		{
			return postCommentLike.Id.Matches(command.Id);
		}

		public bool MatchesFilter(PostCommentLikesFilterQuery query)
		{
			return postCommentLike.Id.CommentId.Matches(query.CommentId) &&
				   postCommentLike.User != null &&
				   postCommentLike.User.Name.Value.StartsWithOrdinalIgnoreCase(query.UserName.Value);
		}

		public bool MatchesFilter(PostCommentLikesForUserFilterQuery query)
		{
			return postCommentLike.Id.UserId.Matches(query.UserId);
		}
	}

	extension(PostCommentInclude p)
	{
		public bool Matches(AddPostCommentLikeCommand command, PostCommentInclude include)
		{
			return p.Matches(include);
		}
	}

	extension(PostCommentLikeInclude p)
	{
		public bool Matches(DeletePostCommentLikeCommand command, PostCommentLikeInclude include)
		{
			return p.Matches(include);
		}
	}

	extension(PostCommentLikeResponse? response)
	{
		public bool MatchesFull<T>(T request, PostCommentLike? postCommentLike)
		where T : ICurrentUserableQuery
		{
			return response != null &&
				   postCommentLike != null &&
				   postCommentLike.Id.Matches(response.Id) &&
				   postCommentLike.CreatedAtUtc == response.CreatedAtUtc &&
				   response.User.MatchesFull(postCommentLike.User) &&
				   response.PostComment.MatchesFull(request, postCommentLike.PostComment);
		}

		public bool MatchesWithoutUser<T>(T request, PostCommentLike? postCommentLike)
			where T : ICurrentUserableQuery
		{
			return response != null &&
				   postCommentLike != null &&
				   postCommentLike.Id.Matches(response.Id) &&
				   postCommentLike.CreatedAtUtc == response.CreatedAtUtc &&
				   response.User == null &&
				   response.PostComment.MatchesFull(request, postCommentLike.PostComment);
		}

		public bool MatchesWithoutPostComment<T>(T request, PostCommentLike? postCommentLike)
			where T : ICurrentUserableQuery
		{
			return response != null &&
				   postCommentLike != null &&
				   postCommentLike.Id.Matches(response.Id) &&
				   postCommentLike.CreatedAtUtc == response.CreatedAtUtc &&
				   response.User.MatchesFull(postCommentLike.User) &&
				   response.PostComment == null;
		}

		public bool Matches(GetPostCommentLikeByIdQuery query, PostCommentLike postCommentLike)
		{
			return response.MatchesFull(query, postCommentLike);
		}
	}

	extension(PostCommentLikeCollectionResponse response)
	{
		public bool MatchesWithoutUser<T>(
		T request,
		Func<PostCommentLikeResponse, PostCommentLike, bool> matches,
		Func<PostCommentLike, bool> matchesFilter,
		PostComment postComment,
		ICollection<PostCommentLike> postCommentLikes)
		where T : ICurrentUserableQuery, IPaginatableQuery<PostCommentLikesPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, postCommentLikes.Count(matchesFilter)) &&
				   response.User == null &&
				   response.PostComment.MatchesFull(request, postComment) &&
				   response.PostCommentLikes.MatchesCollection(request.Pagination,
													postCommentLikes,
													response => response.Id,
													postCommentLike => postCommentLike.Id,
													matches,
													matchesFilter);
		}

		public bool MatchesWithoutUser<T>(
			T request,
			Func<PostCommentLikeResponse, PostCommentLike, bool> matches,
			Func<PostCommentLike, bool> matchesFilter,
			PostComment postComment,
			ICollection<PostCommentLike> postCommentLikes,
			ISortEnumTermTransformer<PostCommentLike> termTransformer)
			where T : ICurrentUserableQuery, IPaginatableQuery<PostCommentLikesPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, postCommentLikes.Count(matchesFilter)) &&
				   response.User == null &&
				   response.PostComment.MatchesFull(request, postComment) &&
				   response.PostCommentLikes.MatchesSortedCollection(request.Pagination,
														  postCommentLikes,
														  matches,
														  termTransformer,
														  matchesFilter);
		}

		public bool MatchesWithoutPostComment<T>(
			T request,
			Func<PostCommentLikeResponse, PostCommentLike, bool> matches,
			Func<PostCommentLike, bool> matchesFilter,
			User user,
			ICollection<PostCommentLike> postCommentLikes)
			where T : ICurrentUserableQuery, IPaginatableQuery<PostCommentLikesPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, postCommentLikes.Count(matchesFilter)) &&
				   response.User.MatchesFull(user) &&
				   response.PostComment == null &&
				   response.PostCommentLikes.MatchesCollection(request.Pagination,
													postCommentLikes,
													response => response.Id,
													postCommentLike => postCommentLike.Id,
													matches,
													matchesFilter);
		}

		public bool MatchesWithoutPostComment<T>(
			T request,
			Func<PostCommentLikeResponse, PostCommentLike, bool> matches,
			Func<PostCommentLike, bool> matchesFilter,
			User user,
			ICollection<PostCommentLike> postCommentLikes,
			ISortEnumTermTransformer<PostCommentLike> termTransformer)
			where T : ICurrentUserableQuery, IPaginatableQuery<PostCommentLikesPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, postCommentLikes.Count(matchesFilter)) &&
				   response.User.MatchesFull(user) &&
				   response.PostComment == null &&
				   response.PostCommentLikes.MatchesSortedCollection(request.Pagination,
														  postCommentLikes,
														  matches,
														  termTransformer,
														  matchesFilter);
		}

		public bool Matches(
		GetAllPostCommentLikesQuery query,
		PostComment postComment,
		ICollection<PostCommentLike> postCommentLikes)
		{
			return response.MatchesWithoutUser(
					   query,
					   (response, postCommentLike) => response.MatchesWithoutPostComment(query, postCommentLike),
					   postCommentLike => postCommentLike.MatchesFilter(query.Filter),
					   postComment,
					   postCommentLikes);
		}

		public bool Matches(
			GetAllPostCommentLikesQuery query,
			PostComment postComment,
			ICollection<PostCommentLike> postCommentLikes,
			ISortEnumTermTransformer<PostCommentLike> termTransformer)
		{
			return response.MatchesWithoutUser(
					   query,
					   (response, postCommentLike) => response.MatchesWithoutPostComment(query, postCommentLike),
					   postCommentLike => postCommentLike.MatchesFilter(query.Filter),
					   postComment,
					   postCommentLikes,
					   termTransformer);
		}

		public bool Matches(
		GetAllPostCommentLikesForUserQuery query,
		User user,
		ICollection<PostCommentLike> postCommentLikes)
		{
			return response.MatchesWithoutPostComment(
					   query,
					   (response, postCommentLike) => response.MatchesWithoutUser(query, postCommentLike),
					   postCommentLike => postCommentLike.MatchesFilter(query.Filter),
					   user,
					   postCommentLikes);
		}

		public bool Matches(
			GetAllPostCommentLikesForUserQuery query,
			User user,
			ICollection<PostCommentLike> postCommentLikes,
			ISortEnumTermTransformer<PostCommentLike> termTransformer)
		{
			return response.MatchesWithoutPostComment(
					   query,
					   (response, postCommentLike) => response.MatchesWithoutUser(query, postCommentLike),
					   postCommentLike => postCommentLike.MatchesFilter(query.Filter),
					   user,
					   postCommentLikes,
					   termTransformer);
		}
	}
}
