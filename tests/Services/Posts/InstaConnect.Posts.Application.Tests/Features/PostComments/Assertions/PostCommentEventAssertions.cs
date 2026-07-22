using InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Events.Features.PostComments;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Assertions;

public static class PostCommentEventAssertions
{
	extension(PostCommentAddedEventRequest r)
	{
		public bool ShouldSatisfy(AddPostCommentCommandRequest request, PostComment entity)
		{
			return r.Matches(request, entity);
		}
	}

	extension(PostCommentUpdatedEventRequest r)
	{
		public bool ShouldSatisfy(UpdatePostCommentCommandRequest request, PostComment entity)
		{
			return r.Matches(request, entity);
		}
	}

	extension(PostCommentDeletedEventRequest r)
	{
		public bool ShouldSatisfy(DeletePostCommentCommandRequest request, PostComment entity)
		{
			return r.Matches(request, entity);
		}
	}
}
