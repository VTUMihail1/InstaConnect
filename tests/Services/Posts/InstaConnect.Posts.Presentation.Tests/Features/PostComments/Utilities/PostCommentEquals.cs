using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Presentation.Features.Messaging.Abstractions;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;
using InstaConnect.Posts.Presentation.Features.Users.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;

public static class PostCommentEquals
{
	extension(GetAllPostCommentsQueryRequest query)
	{
		public bool Matches(GetAllPostCommentsApiRequest request)
		{
			return query.MatchesFilter(request) &&
				   query.MatchesSortable<GetAllPostCommentsQueryRequest, PostCommentsSortTerm, GetAllPostCommentsApiRequest>(request) &&
				   query.MatchesPaginatable(request) &&
				   query.MatchesCurrentUserable(request);
		}

		public bool MatchesFilter(GetAllPostCommentsApiRequest request)
		{
			return query.Id == request.Id &&
				   query.UserName == request.UserName;
		}
	}

	extension(GetAllPostCommentsForUserQueryRequest query)
	{
		public bool Matches(GetAllPostCommentsForUserApiRequest request)
		{
			return query.MatchesFilter(request) &&
				   query.MatchesSortable<GetAllPostCommentsForUserQueryRequest, PostCommentsForUserSortTerm, GetAllPostCommentsForUserApiRequest>(request) &&
				   query.MatchesPaginatable(request) &&
				   query.MatchesCurrentUserable(request);
		}

		public bool MatchesFilter(GetAllPostCommentsForUserApiRequest request)
		{
			return query.UserId == request.UserId;
		}
	}

	extension(GetPostCommentByIdQueryRequest query)
	{
		public bool Matches(GetPostCommentByIdApiRequest request)
		{
			return query.Id == request.Id &&
				   query.CommentId == request.CommentId &&
				   query.MatchesCurrentUserable(request);
		}
	}

	extension(AddPostCommentCommandRequest command)
	{
		public bool Matches(AddPostCommentApiRequest request)
		{
			return command.Id == request.Id &&
				   command.Content == request.Body.Content &&
				   command.UserId == request.UserId;
		}
	}

	extension(UpdatePostCommentCommandRequest command)
	{
		public bool Matches(UpdatePostCommentApiRequest request)
		{
			return command.Id == request.Id &&
				   command.CommentId == request.CommentId &&
				   command.Content == request.Body.Content &&
				   command.UserId == request.UserId;
		}
	}

	extension(DeletePostCommentCommandRequest command)
	{
		public bool Matches(DeletePostCommentApiRequest request)
		{
			return command.Id == request.Id &&
				   command.CommentId == request.CommentId &&
				   command.UserId == request.UserId;
		}
	}

	extension(AddPostCommentApiResponse response)
	{
		public bool Matches(
		PostComment postComment,
		AddPostCommentApiRequest request)
		{
			return response.Response.Matches(postComment.Id);
		}
	}

	extension(UpdatePostCommentApiResponse response)
	{
		public bool Matches(
		PostComment postComment,
		UpdatePostCommentApiRequest request)
		{
			return response.Response.Matches(postComment.Id);
		}
	}

	extension(GetPostCommentByIdApiResponse response)
	{
		public bool Matches(PostComment postComment, GetPostCommentByIdApiRequest request)
		{
			return response.Response.MatchesFull(postComment, request);
		}
	}

	extension(GetAllPostCommentsApiResponse response)
	{
		public bool Matches(
		Post post,
		ICollection<PostComment> postComments,
		GetAllPostCommentsApiRequest request)
		{
			return response.Response.MatchesWithoutUser(
					   (response, postComment) => response.MatchesWithoutPost(postComment, request),
					   postComment => postComment.MatchesFilter(request),
					   post,
					   postComments,
					   request);
		}

		public bool Matches(
			Post post,
			ICollection<PostComment> postComments,
			GetAllPostCommentsApiRequest request,
			ISortEnumTermTransformer<PostComment> termTransformer)
		{
			return response.Response.MatchesWithoutUser(
					   (response, postComment) => response.MatchesWithoutPost(postComment, request),
					   postComment => postComment.MatchesFilter(request),
					   post,
					   postComments,
					   request,
					   termTransformer);
		}
	}

	extension(GetAllPostCommentsForUserApiResponse response)
	{
		public bool Matches(
		User user,
		ICollection<PostComment> postComments,
		GetAllPostCommentsForUserApiRequest request)
		{
			return response.Response.MatchesWithoutPost(
					   (response, postComment) => response.MatchesWithoutUser(postComment, request),
					   postComment => postComment.MatchesFilter(request),
					   user,
					   postComments,
					   request);
		}

		public bool Matches(
			User user,
			ICollection<PostComment> postComments,
			GetAllPostCommentsForUserApiRequest request,
			ISortEnumTermTransformer<PostComment> termTransformer)
		{
			return response.Response.MatchesWithoutPost(
					   (response, postComment) => response.MatchesWithoutUser(postComment, request),
					   postComment => postComment.MatchesFilter(request),
					   user,
					   postComments,
					   request,
					   termTransformer);
		}
	}

	extension(PostComment postComment)
	{
		public bool Matches(AddPostCommentApiRequest request)
		{
			return postComment.Id.Id.Matches(request.Id) &&
				   postComment.UserId.Matches(request.UserId) &&
				   postComment.Content == request.Body.Content;
		}

		public bool Matches(UpdatePostCommentApiRequest request)
		{
			return postComment.Id.Matches(request.Id, request.CommentId) &&
				   postComment.UserId.Matches(request.UserId) &&
				   postComment.Content == request.Body.Content;
		}

		public bool MatchesFilter(GetAllPostCommentsApiRequest request)
		{
			return postComment.Id.Id.Id.EqualsOrdinalIgnoreCase(request.Id) &&
				   postComment.User != null &&
				   postComment.User.Name.Value.StartsWithOrdinalIgnoreCase(request.UserName);
		}

		public bool MatchesFilter(GetAllPostCommentsForUserApiRequest request)
		{
			return postComment.UserId.Id.EqualsOrdinalIgnoreCase(request.UserId);
		}
	}

	extension(PostCommentIdApiResponse response)
	{
		public bool Matches(PostCommentId id)
		{
			return id.Matches(response.Id, response.CommentId);
		}
	}

	extension(PostCommentApiResponse? response)
	{
		public bool MatchesFull<TRequest>(PostComment? postComment, TRequest request)
		where TRequest : ICurrentUserableApiRequest
		{
			return response != null &&
				   postComment != null &&
				   postComment.Id.Matches(response.Id, response.CommentId) &&
				   postComment.UserId.Matches(response.UserId) &&
				   postComment.Content == response.Content &&
				   response.IsLikedByCurrentUser == postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)) &&
				   postComment.CreatedAtUtc == response.CreatedAtUtc &&
				   postComment.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.User.MatchesFull(postComment.User) &&
				   response.Post.MatchesFull(postComment.Post, request);
		}

		public bool MatchesWithoutUser<TRequest>(PostComment? postComment, TRequest request)
			where TRequest : ICurrentUserableApiRequest
		{
			return response != null &&
				   postComment != null &&
				   postComment.Id.Matches(response.Id, response.CommentId) &&
				   postComment.UserId.Matches(response.UserId) &&
				   postComment.Content == response.Content &&
				   response.IsLikedByCurrentUser == postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)) &&
				   postComment.CreatedAtUtc == response.CreatedAtUtc &&
				   postComment.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.User == null &&
				   response.Post.MatchesFull(postComment.Post, request);
		}

		public bool MatchesWithoutPost<TRequest>(PostComment? postComment, TRequest request)
			where TRequest : ICurrentUserableApiRequest
		{
			return response != null &&
				   postComment != null &&
				   postComment.Id.Matches(response.Id, response.CommentId) &&
				   postComment.UserId.Matches(response.UserId) &&
				   postComment.Content == response.Content &&
				   response.IsLikedByCurrentUser == postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)) &&
				   postComment.CreatedAtUtc == response.CreatedAtUtc &&
				   postComment.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.User.MatchesFull(postComment.User) &&
				   response.Post == null;
		}
	}

	extension(PostCommentCollectionApiResponse response)
	{
		public bool MatchesWithoutUser<TRequest>(
		Func<PostCommentApiResponse, PostComment, bool> matches,
		Func<PostComment, bool> matchesFilter,
		Post post,
		ICollection<PostComment> postComments,
		TRequest request)
		where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			return response.MatchesCollectionResponse(postComments.Count(matchesFilter), request) &&
				   response.User == null &&
				   response.Post.MatchesFull(post, request) &&
				   response.PostComments.MatchesCollection(postComments,
														response => new(new(response.Id), response.CommentId),
														postComment => postComment.Id,
														matches,
														request,
														matchesFilter);
		}

		public bool MatchesWithoutUser<TRequest>(
			Func<PostCommentApiResponse, PostComment, bool> matches,
			Func<PostComment, bool> matchesFilter,
			Post post,
			ICollection<PostComment> postComments,
			TRequest request,
			ISortEnumTermTransformer<PostComment> termTransformer)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			return response.MatchesCollectionResponse(postComments.Count(matchesFilter), request) &&
				   response.User == null &&
				   response.Post.MatchesFull(post, request) &&
				   response.PostComments.MatchesSortedCollection(postComments,
															  matches,
															  termTransformer,
															  request,
															  matchesFilter);
		}

		public bool MatchesWithoutPost<TRequest>(
			Func<PostCommentApiResponse, PostComment, bool> matches,
			Func<PostComment, bool> matchesFilter,
			User user,
			ICollection<PostComment> postComments,
			TRequest request)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			return response.MatchesCollectionResponse(postComments.Count(matchesFilter), request) &&
				   response.User.MatchesFull(user) &&
				   response.Post == null &&
				   response.PostComments.MatchesCollection(postComments,
														response => new(new(response.Id), response.CommentId),
														postComment => postComment.Id,
														matches,
														request,
														matchesFilter);
		}

		public bool MatchesWithoutPost<TRequest>(
			Func<PostCommentApiResponse, PostComment, bool> matches,
			Func<PostComment, bool> matchesFilter,
			User user,
			ICollection<PostComment> postComments,
			TRequest request,
			ISortEnumTermTransformer<PostComment> termTransformer)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			return response.MatchesCollectionResponse(postComments.Count(matchesFilter), request) &&
				   response.User.MatchesFull(user) &&
				   response.Post == null &&
				   response.PostComments.MatchesSortedCollection(postComments,
															  matches,
															  termTransformer,
															  request,
															  matchesFilter);
		}
	}
}
