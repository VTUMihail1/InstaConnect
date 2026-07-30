using InstaConnect.Posts.Events.Features.PostCommentLikes;

namespace InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeMatcher
{
	public static PostCommentInclude IsPostCommentInclude(AddPostCommentLikeCommand command, PostCommentInclude include)
	{
		return Matcher.Is<PostCommentInclude>(p => p.Matches(command, include));
	}

	public static PostCommentLikeInclude IsPostCommentLikeInclude(DeletePostCommentLikeCommand command, PostCommentLikeInclude include)
	{
		return Matcher.Is<PostCommentLikeInclude>(p => p.Matches(command, include));
	}

	public static PostCommentLike IsPostCommentLike(AddPostCommentLikeCommand command)
	{
		return Matcher.Is<PostCommentLike>(p => p.Matches(command));
	}

	public static PostCommentLike IsPostCommentLike(DeletePostCommentLikeCommand command)
	{
		return Matcher.Is<PostCommentLike>(p => p.Matches(command));
	}

	public static PostCommentLikeAddedEventRequest IsPostCommentLikeAddedEventRequest(AddPostCommentLikeCommand command, PostCommentLike postCommentLike)
	{
		return Matcher.Is<PostCommentLikeAddedEventRequest>(p => p.Matches(command, postCommentLike));
	}

	public static PostCommentLikeDeletedEventRequest IsPostCommentLikeDeletedEventRequest(DeletePostCommentLikeCommand command, PostCommentLike postCommentLike)
	{
		return Matcher.Is<PostCommentLikeDeletedEventRequest>(p => p.Matches(command, postCommentLike));
	}
}
