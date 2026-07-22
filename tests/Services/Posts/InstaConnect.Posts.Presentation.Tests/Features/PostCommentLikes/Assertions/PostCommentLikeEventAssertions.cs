using InstaConnect.Posts.Events.Features.PostCommentLikes;
using InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeEventAssertions
{
	extension(PostCommentLikeAddedEventRequest r)
	{
		public bool ShouldSatisfy(AddPostCommentLikeApiRequest request, PostCommentLike entity)
		{
			return r.Matches(request, entity);
		}
	}

	extension(PostCommentLikeDeletedEventRequest r)
	{
		public bool ShouldSatisfy(DeletePostCommentLikeApiRequest request, PostCommentLike entity)
		{
			return r.Matches(request, entity);
		}
	}
}
