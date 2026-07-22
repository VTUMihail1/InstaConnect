using InstaConnect.Posts.Domain.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Events.Features.PostComments;

namespace InstaConnect.Posts.Domain.Tests.Features.PostComments.Assertions;

public static class PostCommentEventAssertions
{
	extension(PostCommentAddedEventRequest r)
	{
		public bool ShouldSatisfy(AddPostCommentCommand command, PostComment entity)
		{
			return r.Matches(command, entity);
		}
	}

	extension(PostCommentUpdatedEventRequest r)
	{
		public bool ShouldSatisfy(UpdatePostCommentCommand command, PostComment entity)
		{
			return r.Matches(command, entity);
		}
	}

	extension(PostCommentDeletedEventRequest r)
	{
		public bool ShouldSatisfy(DeletePostCommentCommand command, PostComment entity)
		{
			return r.Matches(command, entity);
		}
	}
}
