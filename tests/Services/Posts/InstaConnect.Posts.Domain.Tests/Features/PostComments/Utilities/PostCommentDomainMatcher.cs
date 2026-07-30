using InstaConnect.Posts.Events.Features.PostComments;

namespace InstaConnect.Posts.Domain.Tests.Features.PostComments.Utilities;

public static class PostCommentDomainMatcher
{
	public static PostInclude IsPostInclude(AddPostCommentCommand command, PostInclude include)
	{
		return Matcher.Is<PostInclude>(p => p.Matches(command, include));
	}

	public static PostCommentInclude IsPostCommentInclude(UpdatePostCommentCommand command, PostCommentInclude include)
	{
		return Matcher.Is<PostCommentInclude>(p => p.Matches(command, include));
	}

	public static PostCommentInclude IsPostCommentInclude(DeletePostCommentCommand command, PostCommentInclude include)
	{
		return Matcher.Is<PostCommentInclude>(p => p.Matches(command, include));
	}

	public static PostComment IsPostComment(AddPostCommentCommand command)
	{
		return Matcher.Is<PostComment>(p => p.Matches(command));
	}

	public static PostComment IsPostComment(UpdatePostCommentCommand command)
	{
		return Matcher.Is<PostComment>(p => p.Matches(command));
	}

	public static PostComment IsPostComment(DeletePostCommentCommand command)
	{
		return Matcher.Is<PostComment>(p => p.Matches(command));
	}

	public static PostCommentAddedEventRequest IsPostCommentAddedEventRequest(AddPostCommentCommand command, PostComment postComment)
	{
		return Matcher.Is<PostCommentAddedEventRequest>(p => p.Matches(command, postComment));
	}

	public static PostCommentUpdatedEventRequest IsPostCommentUpdatedEventRequest(UpdatePostCommentCommand command, PostComment postComment)
	{
		return Matcher.Is<PostCommentUpdatedEventRequest>(p => p.Matches(command, postComment));
	}

	public static PostCommentDeletedEventRequest IsPostCommentDeletedEventRequest(DeletePostCommentCommand command, PostComment postComment)
	{
		return Matcher.Is<PostCommentDeletedEventRequest>(p => p.Matches(command, postComment));
	}
}
