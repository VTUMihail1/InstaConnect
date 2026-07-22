using InstaConnect.Posts.Events.Features.PostComments;
using InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Assertions;

public static class PostCommentEventAssertions
{
	extension(PostCommentAddedEventRequest r)
	{
		public bool ShouldSatisfy(AddPostCommentApiRequest request, PostComment entity)
		{
			return r.Matches(request, entity);
		}
	}

	extension(PostCommentUpdatedEventRequest r)
	{
		public bool ShouldSatisfy(UpdatePostCommentApiRequest request, PostComment entity)
		{
			return r.Matches(request, entity);
		}
	}

	extension(PostCommentDeletedEventRequest r)
	{
		public bool ShouldSatisfy(DeletePostCommentApiRequest request, PostComment entity)
		{
			return r.Matches(request, entity);
		}
	}
}
