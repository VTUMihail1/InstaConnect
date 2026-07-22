using InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Events.Features.PostCommentLikes;

namespace InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeEventAssertions
{
	extension(PostCommentLikeAddedEventRequest r)
	{
		public bool ShouldSatisfy(AddPostCommentLikeCommand command, PostCommentLike entity)
		{
			return r.Matches(command, entity);
		}
	}

	extension(PostCommentLikeDeletedEventRequest r)
	{
		public bool ShouldSatisfy(DeletePostCommentLikeCommand command, PostCommentLike entity)
		{
			return r.Matches(command, entity);
		}
	}
}
