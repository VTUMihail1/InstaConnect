using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Posts.Domain.Features.PostComments.Models.ValueObjects;
using InstaConnect.Posts.Events.Features.PostComments;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostComments.Utilities;

public static class PostCommentEquals
{
	extension(PostCommentAddedEventRequest request)
	{
		public bool Matches(PostComment entity)
		{
			return entity.Matches(request.PostComment);
		}
	}

	extension(PostCommentUpdatedEventRequest request)
	{
		public bool Matches(PostComment entity)
		{
			return entity.Matches(request.PostComment);
		}
	}

	extension(PostCommentDeletedEventRequest request)
	{
		public bool Matches(PostComment entity)
		{
			return entity.Matches(request.PostComment);
		}
	}

	extension(PostCommentEventRequest r)
	{
		public bool Matches(PostCommentEventRequest request)
		{
			return r.Id == request.Id &&
				   r.CommentId == request.CommentId &&
				   r.UserId == request.UserId &&
				   r.Content == request.Content &&
				   r.User.Matches(request.User) &&
				   r.Post.Matches(request.Post) &&
				   r.CreatedAtUtc == request.CreatedAtUtc &&
				   r.UpdatedAtUtc == request.UpdatedAtUtc;
		}
	}

	extension(PostComment entity)
	{
		public bool Matches(PostCommentEventRequest request)
		{
			return entity.Id.Matches(request.Id, request.CommentId) &&
				   entity.Content == request.Content &&
				   entity.User != null && entity.User.Matches(request.User) &&
				   entity.Post != null && entity.Post.Matches(request.Post) &&
				   entity.CreatedAtUtc == request.CreatedAtUtc &&
				   entity.UpdatedAtUtc == request.UpdatedAtUtc;
		}
	}

	extension(PostCommentId p)
	{
		public bool Matches(string id, string commentId)
		{
			return p.Id.Matches(id) &&
				   p.CommentId.EqualsOrdinalIgnoreCase(commentId);
		}
	}
}
