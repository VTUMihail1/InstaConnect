using InstaConnect.Posts.Events.Features.PostCommentLikes;

namespace InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeMatcher
{
	public static PostCommentInclude IsPostCommentInclude(AddPostCommentLikeCommand command, PostCommentInclude include)
	{
		return Matcher.Is<PostCommentInclude>(p => p.Matches(include));
	}

	public static PostCommentLikeInclude IsPostCommentLikeInclude(DeletePostCommentLikeCommand command, PostCommentLikeInclude include)
	{
		return Matcher.Is<PostCommentLikeInclude>(p => p.Matches(include));
	}

	public static PostCommentLike IsPostCommentLike(AddPostCommentLikeCommand command)
	{
		return Matcher.Is<PostCommentLike>(p => p.Matches(command));
	}

	public static PostCommentLike IsPostCommentLike(DeletePostCommentLikeCommand command)
	{
		return Matcher.Is<PostCommentLike>(p => p.Matches(command));
	}

	public static PostCommentLikeAddedEventRequest IsPostCommentLikeAddedEventRequest(PostCommentLike postCommentLike)
	{
		return Matcher.Is<PostCommentLikeAddedEventRequest>(p => p.Matches(postCommentLike));
	}

	public static PostCommentLikeDeletedEventRequest IsPostCommentLikeDeletedEventRequest(PostCommentLike postCommentLike)
	{
		return Matcher.Is<PostCommentLikeDeletedEventRequest>(p => p.Matches(postCommentLike));
	}
}
