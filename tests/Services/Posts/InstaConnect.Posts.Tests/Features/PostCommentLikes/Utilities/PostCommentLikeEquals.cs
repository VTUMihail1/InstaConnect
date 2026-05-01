using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.ValueObjects;
using InstaConnect.Posts.Events.Features.PostCommentLikes;
using InstaConnect.Posts.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeEquals
{
	extension(PostCommentLikeAddedEventRequest request)
	{
		public bool Matches(PostCommentLike entity)
		{
			return entity.Matches(request.PostCommentLike);
		}
	}

	extension(PostCommentLikeDeletedEventRequest request)
	{
		public bool Matches(PostCommentLike entity)
		{
			return entity.Matches(request.PostCommentLike);
		}
	}

	extension(PostCommentLikeEventRequest r)
	{
		public bool Matches(PostCommentLikeEventRequest request)
		{
			return r.Id == request.Id &&
				   r.CommentId == request.CommentId &&
				   r.UserId == request.UserId &&
				   r.User.Matches(request.User) &&
				   r.PostComment.Matches(request.PostComment) &&
				   r.CreatedAtUtc == request.CreatedAtUtc;
		}
	}

	extension(PostCommentLike entity)
	{
		public bool Matches(PostCommentLikeEventRequest request)
		{
			return entity.Id.Matches(request.Id, request.CommentId, request.UserId) &&
				   entity.User != null && entity.User.Matches(request.User) &&
				   entity.PostComment != null && entity.PostComment.Matches(request.PostComment) &&
				   entity.CreatedAtUtc == request.CreatedAtUtc;
		}
	}

	extension(PostCommentLikeId p)
	{
		public bool Matches(string id, string commentId, string userId)
		{
			return p.CommentId.Matches(id, commentId) &&
				   p.UserId.Matches(userId);
		}
	}
}
