using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Domain.Features.Messaging.Abstractions;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Domain.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeEquals
{
	extension(PostCommentLikeId response)
	{
		public bool Matches(
		PostCommentLike postCommentLike,
		AddPostCommentLikeCommand command)
		{
			return response.Matches(postCommentLike.Id);
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

	extension(PostCommentLikeResponse? response)
	{
		public bool MatchesFull<T>(PostCommentLike? postCommentLike, T request)
		where T : ICurrentUserableQuery
		{
			return response != null &&
				   postCommentLike != null &&
				   postCommentLike.Id.Matches(response.Id) &&
				   postCommentLike.CreatedAtUtc == response.CreatedAtUtc &&
				   response.User.MatchesFull(postCommentLike.User) &&
				   response.PostComment.MatchesFull(postCommentLike.PostComment, request);
		}

		public bool MatchesWithoutUser<T>(PostCommentLike? postCommentLike, T request)
			where T : ICurrentUserableQuery
		{
			return response != null &&
				   postCommentLike != null &&
				   postCommentLike.Id.Matches(response.Id) &&
				   postCommentLike.CreatedAtUtc == response.CreatedAtUtc &&
				   response.User == null &&
				   response.PostComment.MatchesFull(postCommentLike.PostComment, request);
		}

		public bool MatchesWithoutPostComment<T>(PostCommentLike? postCommentLike, T request)
			where T : ICurrentUserableQuery
		{
			return response != null &&
				   postCommentLike != null &&
				   postCommentLike.Id.Matches(response.Id) &&
				   postCommentLike.CreatedAtUtc == response.CreatedAtUtc &&
				   response.User.MatchesFull(postCommentLike.User) &&
				   response.PostComment == null;
		}

		public bool Matches(PostCommentLike postCommentLike, GetPostCommentLikeByIdQuery query)
		{
			return response.MatchesFull(postCommentLike, query);
		}
	}

	extension(PostCommentLikeCollectionResponse response)
	{
		public bool MatchesWithoutUser<T>(
		Func<PostCommentLikeResponse, PostCommentLike, bool> matches,
		Func<PostCommentLike, bool> matchesFilter,
		PostComment postComment,
		ICollection<PostCommentLike> postCommentLikes,
		T request)
		where T : ICurrentUserableQuery, IPaginatableQuery<PostCommentLikesPaginationQuery>
		{
			return response.MatchesCollectionResponse(postCommentLikes.Count(matchesFilter), request.Pagination) &&
				   response.User == null &&
				   response.PostComment.MatchesFull(postComment, request) &&
				   response.PostCommentLikes.MatchesCollection(postCommentLikes,
													response => response.Id,
													postCommentLike => postCommentLike.Id,
													matches,
													request.Pagination,
													matchesFilter);
		}

		public bool MatchesWithoutUser<T>(
			Func<PostCommentLikeResponse, PostCommentLike, bool> matches,
			Func<PostCommentLike, bool> matchesFilter,
			PostComment postComment,
			ICollection<PostCommentLike> postCommentLikes,
			T request,
			ISortEnumTermTransformer<PostCommentLike> termTransformer)
			where T : ICurrentUserableQuery, IPaginatableQuery<PostCommentLikesPaginationQuery>
		{
			return response.MatchesCollectionResponse(postCommentLikes.Count(matchesFilter), request.Pagination) &&
				   response.User == null &&
				   response.PostComment.MatchesFull(postComment, request) &&
				   response.PostCommentLikes.MatchesSortedCollection(postCommentLikes,
														  matches,
														  termTransformer,
														  request.Pagination,
														  matchesFilter);
		}

		public bool MatchesWithoutPostComment<T>(
			Func<PostCommentLikeResponse, PostCommentLike, bool> matches,
			Func<PostCommentLike, bool> matchesFilter,
			User user,
			ICollection<PostCommentLike> postCommentLikes,
			T request)
			where T : ICurrentUserableQuery, IPaginatableQuery<PostCommentLikesPaginationQuery>
		{
			return response.MatchesCollectionResponse(postCommentLikes.Count(matchesFilter), request.Pagination) &&
				   response.User.MatchesFull(user) &&
				   response.PostComment == null &&
				   response.PostCommentLikes.MatchesCollection(postCommentLikes,
													response => response.Id,
													postCommentLike => postCommentLike.Id,
													matches,
													request.Pagination,
													matchesFilter);
		}

		public bool MatchesWithoutPostComment<T>(
			Func<PostCommentLikeResponse, PostCommentLike, bool> matches,
			Func<PostCommentLike, bool> matchesFilter,
			User user,
			ICollection<PostCommentLike> postCommentLikes,
			T request,
			ISortEnumTermTransformer<PostCommentLike> termTransformer)
			where T : ICurrentUserableQuery, IPaginatableQuery<PostCommentLikesPaginationQuery>
		{
			return response.MatchesCollectionResponse(postCommentLikes.Count(matchesFilter), request.Pagination) &&
				   response.User.MatchesFull(user) &&
				   response.PostComment == null &&
				   response.PostCommentLikes.MatchesSortedCollection(postCommentLikes,
														  matches,
														  termTransformer,
														  request.Pagination,
														  matchesFilter);
		}

		public bool Matches(
		PostComment postComment,
		ICollection<PostCommentLike> postCommentLikes,
		GetAllPostCommentLikesQuery query)
		{
			return response.MatchesWithoutUser(
					   (response, postCommentLike) => response.MatchesWithoutPostComment(postCommentLike, query),
					   postCommentLike => postCommentLike.MatchesFilter(query.Filter),
					   postComment,
					   postCommentLikes,
					   query);
		}

		public bool Matches(
			PostComment postComment,
			ICollection<PostCommentLike> postCommentLikes,
			GetAllPostCommentLikesQuery query,
			ISortEnumTermTransformer<PostCommentLike> termTransformer)
		{
			return response.MatchesWithoutUser(
					   (response, postCommentLike) => response.MatchesWithoutPostComment(postCommentLike, query),
					   postCommentLike => postCommentLike.MatchesFilter(query.Filter),
					   postComment,
					   postCommentLikes,
					   query,
					   termTransformer);
		}

		public bool Matches(
		User user,
		ICollection<PostCommentLike> postCommentLikes,
		GetAllPostCommentLikesForUserQuery query)
		{
			return response.MatchesWithoutPostComment(
					   (response, postCommentLike) => response.MatchesWithoutUser(postCommentLike, query),
					   postCommentLike => postCommentLike.MatchesFilter(query.Filter),
					   user,
					   postCommentLikes,
					   query);
		}

		public bool Matches(
			User user,
			ICollection<PostCommentLike> postCommentLikes,
			GetAllPostCommentLikesForUserQuery query,
			ISortEnumTermTransformer<PostCommentLike> termTransformer)
		{
			return response.MatchesWithoutPostComment(
					   (response, postCommentLike) => response.MatchesWithoutUser(postCommentLike, query),
					   postCommentLike => postCommentLike.MatchesFilter(query.Filter),
					   user,
					   postCommentLikes,
					   query,
					   termTransformer);
		}
	}
}
