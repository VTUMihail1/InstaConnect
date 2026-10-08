using InstaConnect.Posts.Events.Features.PostComments;

namespace InstaConnect.Posts.Domain.Tests.Features.PostComments.Utilities;

public static class PostCommentDomainMatcher
{
	extension(AddPostCommentCommand command)
	{
		public PostComment IsPostComment()
		{
			return Matcher.Is<PostComment>(p => p.Matches(command));
		}

		public PostCommentAddedEventRequest IsPostCommentAddedEventRequest(PostComment postComment)
		{
			return Matcher.Is<PostCommentAddedEventRequest>(p => p.Matches(command, postComment));
		}
	}

	extension(UpdatePostCommentCommand command)
	{
		public PostComment IsPostComment()
		{
			return Matcher.Is<PostComment>(p => p.Matches(command));
		}

		public PostCommentUpdatedEventRequest IsPostCommentUpdatedEventRequest(PostComment postComment)
		{
			return Matcher.Is<PostCommentUpdatedEventRequest>(p => p.Matches(command, postComment));
		}
	}

	extension(DeletePostCommentCommand command)
	{
		public PostComment IsPostComment()
		{
			return Matcher.Is<PostComment>(p => p.Matches(command));
		}

		public PostCommentDeletedEventRequest IsPostCommentDeletedEventRequest(PostComment postComment)
		{
			return Matcher.Is<PostCommentDeletedEventRequest>(p => p.Matches(command, postComment));
		}
	}
}
