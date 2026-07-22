using InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Events.Features.PostCommentLikes;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeEventAssertions
{
	extension(PostCommentLikeAddedEventRequest r)
	{
		public bool ShouldSatisfy(AddPostCommentLikeCommandRequest request, PostCommentLike entity)
		{
			return r.Matches(request, entity);
		}
	}

	extension(PostCommentLikeDeletedEventRequest r)
	{
		public bool ShouldSatisfy(DeletePostCommentLikeCommandRequest request, PostCommentLike entity)
		{
			return r.Matches(request, entity);
		}
	}
}
