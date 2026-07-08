using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Domain.Features.Messaging.Abstractions;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Domain.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Events.Features.PostComments;

namespace InstaConnect.Posts.Domain.Tests.Features.PostComments.Utilities;

public static class PostCommentEquals
{
	extension(PostCommentId response)
	{
		public bool Matches(
		PostComment postComment,
		AddPostCommentCommand command)
		{
			return response.Matches(postComment.Id);
		}

		public bool Matches(
		PostComment postComment,
		UpdatePostCommentCommand command)
		{
			return response.Matches(postComment.Id);
		}
	}

	extension(PostComment postComment)
	{
		public bool Matches(AddPostCommentCommand command)
		{
			return postComment.Id.Id.Matches(command.Id) &&
				   postComment.UserId.Matches(command.UserId) &&
				   postComment.Content == command.Content;
		}

		public bool Matches(UpdatePostCommentCommand command)
		{
			return postComment.Id.Matches(command.Id) &&
				   postComment.UserId.Matches(command.UserId) &&
				   postComment.Content == command.Content;
		}

		public bool Matches(DeletePostCommentCommand command)
		{
			return postComment.Id.Matches(command.Id) &&
				   postComment.UserId.Matches(command.UserId);
		}

		public bool MatchesFilter(GetAllPostCommentsQuery query)
		{
			return postComment.Id.Id.Matches(query.Filter.Id) &&
				   postComment.User != null &&
				   postComment.User.Name.Value.StartsWithOrdinalIgnoreCase(query.Filter.UserName.Value);
		}

		public bool MatchesFilter(GetAllPostCommentsForUserQuery query)
		{
			return postComment.UserId.Matches(query.Filter.UserId);
		}
	}

	extension(PostCommentAddedEventRequest p)
	{
		public bool Matches(AddPostCommentCommand command, PostComment postComment)
		{
			return postComment.Id.Matches(p.PostComment.Id, p.PostComment.CommentId) &&
				   command.UserId.Matches(p.PostComment.UserId) &&
				   postComment.User != null &&
				   postComment.User.Matches(p.PostComment.User) &&
				   command.Content == p.PostComment.Content &&
				   postComment.CreatedAtUtc == p.PostComment.CreatedAtUtc &&
				   postComment.UpdatedAtUtc == p.PostComment.UpdatedAtUtc;
		}
	}

	extension(PostCommentUpdatedEventRequest p)
	{
		public bool Matches(UpdatePostCommentCommand command, PostComment postComment)
		{
			return command.Id.Matches(p.PostComment.Id, p.PostComment.CommentId) &&
				   command.UserId.Matches(p.PostComment.UserId) &&
				   postComment.User != null &&
				   postComment.User.Matches(p.PostComment.User) &&
				   command.Content == p.PostComment.Content &&
				   postComment.CreatedAtUtc == p.PostComment.CreatedAtUtc &&
				   postComment.UpdatedAtUtc == p.PostComment.UpdatedAtUtc;
		}
	}

	extension(PostCommentDeletedEventRequest p)
	{
		public bool Matches(DeletePostCommentCommand command, PostComment postComment)
		{
			return postComment.Id.Matches(command.Id) &&
				   postComment.UserId.Matches(command.UserId) &&
				   postComment.User != null &&
				   postComment.User.Matches(p.PostComment.User) &&
				   postComment.Content == p.PostComment.Content &&
				   postComment.CreatedAtUtc == p.PostComment.CreatedAtUtc &&
				   postComment.UpdatedAtUtc == p.PostComment.UpdatedAtUtc;
		}
	}

	extension(PostCommentResponse? response)
	{
		public bool MatchesFull<T>(PostComment? postComment, T request)
		where T : ICurrentUserableQuery
		{
			return response != null &&
				   postComment != null &&
				   postComment.Id.Matches(response.Id) &&
				   postComment.UserId.Matches(response.UserId) &&
				   postComment.Content == response.Content &&
				   response.IsLikedByCurrentUser == postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUser.Id)) &&
				   postComment.CreatedAtUtc == response.CreatedAtUtc &&
				   postComment.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.User.MatchesFull(postComment.User) &&
				   response.Post.MatchesFull(postComment.Post, request);
		}

		public bool MatchesWithoutUser<T>(PostComment? postComment, T request)
			where T : ICurrentUserableQuery
		{
			return response != null &&
				   postComment != null &&
				   postComment.Id.Matches(response.Id) &&
				   postComment.UserId.Matches(response.UserId) &&
				   postComment.Content == response.Content &&
				   response.IsLikedByCurrentUser == postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUser.Id)) &&
				   postComment.CreatedAtUtc == response.CreatedAtUtc &&
				   postComment.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.User == null &&
				   response.Post.MatchesFull(postComment.Post, request);
		}

		public bool MatchesWithoutPost<T>(PostComment? postComment, T request)
			where T : ICurrentUserableQuery
		{
			return response != null &&
				   postComment != null &&
				   postComment.Id.Matches(response.Id) &&
				   postComment.UserId.Matches(response.UserId) &&
				   postComment.Content == response.Content &&
				   response.IsLikedByCurrentUser == postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUser.Id)) &&
				   postComment.CreatedAtUtc == response.CreatedAtUtc &&
				   postComment.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.User.MatchesFull(postComment.User) &&
				   response.Post == null;
		}

		public bool Matches(PostComment postComment, GetPostCommentByIdQuery query)
		{
			return response.MatchesFull(postComment, query);
		}
	}

	extension(PostCommentCollectionResponse response)
	{
		public bool MatchesWithoutUser<T>(
		Func<PostCommentResponse, PostComment, bool> matches,
		Func<PostComment, bool> matchesFilter,
		Post post,
		ICollection<PostComment> postComments,
		T request)
		where T : ICurrentUserableQuery, IPaginatableQuery<PostCommentsPaginationQuery>
		{
			return response.MatchesCollectionResponse<PostCommentCollectionResponse, T, PostCommentsPaginationQuery>(postComments.Count(matchesFilter), request) &&
				   response.User == null &&
				   response.Post.MatchesFull(post, request) &&
				   response.PostComments.MatchesCollection<PostCommentResponse, PostComment, PostCommentId, T, PostCommentsPaginationQuery>(postComments,
													response => response.Id,
													postComment => postComment.Id,
													matches,
													request,
													matchesFilter);
		}

		public bool MatchesWithoutUser<T>(
			Func<PostCommentResponse, PostComment, bool> matches,
			Func<PostComment, bool> matchesFilter,
			Post post,
			ICollection<PostComment> postComments,
			T request,
			ISortEnumTermTransformer<PostComment> termTransformer)
			where T : ICurrentUserableQuery, IPaginatableQuery<PostCommentsPaginationQuery>
		{
			return response.MatchesCollectionResponse<PostCommentCollectionResponse, T, PostCommentsPaginationQuery>(postComments.Count(matchesFilter), request) &&
				   response.User == null &&
				   response.Post.MatchesFull(post, request) &&
				   response.PostComments.MatchesSortedCollection<PostCommentResponse, PostComment, T, PostCommentsPaginationQuery>(postComments,
														  matches,
														  termTransformer,
														  request,
														  matchesFilter);
		}

		public bool MatchesWithoutPost<T>(
			Func<PostCommentResponse, PostComment, bool> matches,
			Func<PostComment, bool> matchesFilter,
			User user,
			ICollection<PostComment> postComments,
			T request)
			where T : ICurrentUserableQuery, IPaginatableQuery<PostCommentsPaginationQuery>
		{
			return response.MatchesCollectionResponse<PostCommentCollectionResponse, T, PostCommentsPaginationQuery>(postComments.Count(matchesFilter), request) &&
				   response.User.MatchesFull(user) &&
				   response.Post == null &&
				   response.PostComments.MatchesCollection<PostCommentResponse, PostComment, PostCommentId, T, PostCommentsPaginationQuery>(postComments,
													response => response.Id,
													postComment => postComment.Id,
													matches,
													request,
													matchesFilter);
		}

		public bool MatchesWithoutPost<T>(
			Func<PostCommentResponse, PostComment, bool> matches,
			Func<PostComment, bool> matchesFilter,
			User user,
			ICollection<PostComment> postComments,
			T request,
			ISortEnumTermTransformer<PostComment> termTransformer)
			where T : ICurrentUserableQuery, IPaginatableQuery<PostCommentsPaginationQuery>
		{
			return response.MatchesCollectionResponse<PostCommentCollectionResponse, T, PostCommentsPaginationQuery>(postComments.Count(matchesFilter), request) &&
				   response.User.MatchesFull(user) &&
				   response.Post == null &&
				   response.PostComments.MatchesSortedCollection<PostCommentResponse, PostComment, T, PostCommentsPaginationQuery>(postComments,
														  matches,
														  termTransformer,
														  request,
														  matchesFilter);
		}

		public bool Matches(
		Post post,
		ICollection<PostComment> postComments,
		GetAllPostCommentsQuery query)
		{
			return response.MatchesWithoutUser(
					   (response, postComment) => response.MatchesWithoutPost(postComment, query),
					   postComment => postComment.MatchesFilter(query),
					   post,
					   postComments,
					   query);
		}

		public bool Matches(
			Post post,
			ICollection<PostComment> postComments,
			GetAllPostCommentsQuery query,
			ISortEnumTermTransformer<PostComment> termTransformer)
		{
			return response.MatchesWithoutUser(
					   (response, postComment) => response.MatchesWithoutPost(postComment, query),
					   postComment => postComment.MatchesFilter(query),
					   post,
					   postComments,
					   query,
					   termTransformer);
		}

		public bool Matches(
		User user,
		ICollection<PostComment> postComments,
		GetAllPostCommentsForUserQuery query)
		{
			return response.MatchesWithoutPost(
					   (response, postComment) => response.MatchesWithoutUser(postComment, query),
					   postComment => postComment.MatchesFilter(query),
					   user,
					   postComments,
					   query);
		}

		public bool Matches(
			User user,
			ICollection<PostComment> postComments,
			GetAllPostCommentsForUserQuery query,
			ISortEnumTermTransformer<PostComment> termTransformer)
		{
			return response.MatchesWithoutPost(
					   (response, postComment) => response.MatchesWithoutUser(postComment, query),
					   postComment => postComment.MatchesFilter(query),
					   user,
					   postComments,
					   query,
					   termTransformer);
		}
	}
}
