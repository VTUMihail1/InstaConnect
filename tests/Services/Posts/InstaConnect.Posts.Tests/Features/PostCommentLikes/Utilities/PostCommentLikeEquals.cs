using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.ValueObjects;
using InstaConnect.Posts.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeEquals
{
	extension(PostCommentLike entity)
	{
		public bool Matches(PostCommentLike postCommentLike)
		{
			return entity.Id.Matches(postCommentLike.Id) &&
				   entity.CreatedAtUtc == postCommentLike.CreatedAtUtc;
		}
	}

	extension(PostCommentLikeId p)
	{
		public bool Matches(PostCommentLikeId id)
		{
			return p.Matches(id.CommentId.Id.Id, id.CommentId.CommentId, id.UserId.Id);
		}
		public bool Matches(string id, string commentId, string userId)
		{
			return p.CommentId.Matches(id, commentId) &&
				   p.UserId.Matches(userId);
		}
	}
}
