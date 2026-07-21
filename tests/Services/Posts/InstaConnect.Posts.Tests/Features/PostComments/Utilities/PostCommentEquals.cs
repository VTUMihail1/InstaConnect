using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Posts.Domain.Features.PostComments.Models.ValueObjects;
using InstaConnect.Posts.Events.Features.PostComments;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostComments.Utilities;

public static class PostCommentEquals
{
	extension(PostComment? entity)
	{
		public bool Matches(PostCommentEventRequest request)
		{
			return entity != null &&
				   entity.Id.Matches(request.Id, request.CommentId) &&
				   entity.Content == request.Content &&
				   entity.User.Matches(request.User) &&
				   entity.Post.Matches(request.Post) &&
				   entity.CreatedAtUtc == request.CreatedAtUtc &&
				   entity.UpdatedAtUtc == request.UpdatedAtUtc;
		}
	}

	extension(PostComment entity)
	{
		public bool Matches(PostComment postComment)
		{
			return entity.Id.Matches(postComment.Id) &&
				   entity.Content == postComment.Content &&
				   entity.CreatedAtUtc == postComment.CreatedAtUtc &&
				   entity.UpdatedAtUtc == postComment.UpdatedAtUtc;
		}
	}

	extension(PostCommentId p)
	{
		public bool Matches(PostCommentId id)
		{
			return p.Matches(id.Id.Id, id.CommentId);
		}

		public bool Matches(string id, string commentId)
		{
			return p.Id.Matches(id) &&
				   p.CommentId.EqualsOrdinalIgnoreCase(commentId);
		}
	}
}
