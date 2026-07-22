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
		AddPostCommentCommand command,
		PostComment postComment)
		{
			return response.Matches(postComment.Id);
		}

		public bool Matches(
		UpdatePostCommentCommand command,
		PostComment postComment)
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

		public bool MatchesFilter(PostCommentsFilterQuery query)
		{
			return postComment.Id.Id.Matches(query.Id) &&
				   postComment.User != null &&
				   postComment.User.Name.Value.StartsWithOrdinalIgnoreCase(query.UserName.Value);
		}

		public bool MatchesFilter(PostCommentsForUserFilterQuery query)
		{
			return postComment.UserId.Matches(query.UserId);
		}
	}

	extension(PostInclude p)
	{
		public bool Matches(AddPostCommentCommand command, PostInclude include)
		{
			return p.Matches(include);
		}
	}

	extension(PostCommentInclude p)
	{
		public bool Matches(UpdatePostCommentCommand command, PostCommentInclude include)
		{
			return p.Matches(include);
		}

		public bool Matches(DeletePostCommentCommand command, PostCommentInclude include)
		{
			return p.Matches(include);
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

	extension(PostCommentDeletedEventRequest r)
	{
		public bool Matches(DeletePostCommentCommand command, PostComment postComment)
		{
			return command.Id.Matches(r.PostComment.Id, r.PostComment.CommentId) &&
				   command.UserId.Matches(r.PostComment.UserId) &&
				   postComment.User != null &&
				   postComment.User.Matches(r.PostComment.User) &&
				   postComment.Content == r.PostComment.Content &&
				   postComment.CreatedAtUtc == r.PostComment.CreatedAtUtc &&
				   postComment.UpdatedAtUtc == r.PostComment.UpdatedAtUtc;
		}
	}

	extension(PostCommentResponse? response)
	{
		public bool MatchesFull<T>(T request, PostComment? postComment)
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
				   response.Post.MatchesFull(request, postComment.Post);
		}

		public bool MatchesWithoutUser<T>(T request, PostComment? postComment)
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
				   response.Post.MatchesFull(request, postComment.Post);
		}

		public bool MatchesWithoutPost<T>(T request, PostComment? postComment)
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

		public bool Matches(GetPostCommentByIdQuery query, PostComment postComment)
		{
			return response.MatchesFull(query, postComment);
		}
	}

	extension(PostCommentCollectionResponse response)
	{
		public bool MatchesWithoutUser<T>(
		T request,
		Func<PostCommentResponse, PostComment, bool> matches,
		Func<PostComment, bool> matchesFilter,
		Post post,
		ICollection<PostComment> postComments)
		where T : ICurrentUserableQuery, IPaginatableQuery<PostCommentsPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, postComments.Count(matchesFilter)) &&
				   response.User == null &&
				   response.Post.MatchesFull(request, post) &&
				   response.PostComments.MatchesCollection(request.Pagination,
													postComments,
													response => response.Id,
													postComment => postComment.Id,
													matches,
													matchesFilter);
		}

		public bool MatchesWithoutUser<T>(
			T request,
			Func<PostCommentResponse, PostComment, bool> matches,
			Func<PostComment, bool> matchesFilter,
			Post post,
			ICollection<PostComment> postComments,
			ISortEnumTermTransformer<PostComment> termTransformer)
			where T : ICurrentUserableQuery, IPaginatableQuery<PostCommentsPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, postComments.Count(matchesFilter)) &&
				   response.User == null &&
				   response.Post.MatchesFull(request, post) &&
				   response.PostComments.MatchesSortedCollection(request.Pagination,
														  postComments,
														  matches,
														  termTransformer,
														  matchesFilter);
		}

		public bool MatchesWithoutPost<T>(
			T request,
			Func<PostCommentResponse, PostComment, bool> matches,
			Func<PostComment, bool> matchesFilter,
			User user,
			ICollection<PostComment> postComments)
			where T : ICurrentUserableQuery, IPaginatableQuery<PostCommentsPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, postComments.Count(matchesFilter)) &&
				   response.User.MatchesFull(user) &&
				   response.Post == null &&
				   response.PostComments.MatchesCollection(request.Pagination,
													postComments,
													response => response.Id,
													postComment => postComment.Id,
													matches,
													matchesFilter);
		}

		public bool MatchesWithoutPost<T>(
			T request,
			Func<PostCommentResponse, PostComment, bool> matches,
			Func<PostComment, bool> matchesFilter,
			User user,
			ICollection<PostComment> postComments,
			ISortEnumTermTransformer<PostComment> termTransformer)
			where T : ICurrentUserableQuery, IPaginatableQuery<PostCommentsPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, postComments.Count(matchesFilter)) &&
				   response.User.MatchesFull(user) &&
				   response.Post == null &&
				   response.PostComments.MatchesSortedCollection(request.Pagination,
														  postComments,
														  matches,
														  termTransformer,
														  matchesFilter);
		}

		public bool Matches(
		GetAllPostCommentsQuery query,
		Post post,
		ICollection<PostComment> postComments)
		{
			return response.MatchesWithoutUser(
					   query,
					   (response, postComment) => response.MatchesWithoutPost(query, postComment),
					   postComment => postComment.MatchesFilter(query.Filter),
					   post,
					   postComments);
		}

		public bool Matches(
			GetAllPostCommentsQuery query,
			Post post,
			ICollection<PostComment> postComments,
			ISortEnumTermTransformer<PostComment> termTransformer)
		{
			return response.MatchesWithoutUser(
					   query,
					   (response, postComment) => response.MatchesWithoutPost(query, postComment),
					   postComment => postComment.MatchesFilter(query.Filter),
					   post,
					   postComments,
					   termTransformer);
		}

		public bool Matches(
		GetAllPostCommentsForUserQuery query,
		User user,
		ICollection<PostComment> postComments)
		{
			return response.MatchesWithoutPost(
					   query,
					   (response, postComment) => response.MatchesWithoutUser(query, postComment),
					   postComment => postComment.MatchesFilter(query.Filter),
					   user,
					   postComments);
		}

		public bool Matches(
			GetAllPostCommentsForUserQuery query,
			User user,
			ICollection<PostComment> postComments,
			ISortEnumTermTransformer<PostComment> termTransformer)
		{
			return response.MatchesWithoutPost(
					   query,
					   (response, postComment) => response.MatchesWithoutUser(query, postComment),
					   postComment => postComment.MatchesFilter(query.Filter),
					   user,
					   postComments,
					   termTransformer);
		}
	}
}
