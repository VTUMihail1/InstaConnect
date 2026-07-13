using InstaConnect.Posts.Events.Features.PostLikes;

namespace InstaConnect.Posts.Domain.Tests.Features.PostLikes.Utilities;

public static class PostLikeMatcher
{
	public static PostInclude IsPostInclude(AddPostLikeCommand command, PostInclude include)
	{
		return Matcher.Is<PostInclude>(p => p.Matches(command, include));
	}

	public static PostLikeInclude IsPostLikeInclude(DeletePostLikeCommand command, PostLikeInclude include)
	{
		return Matcher.Is<PostLikeInclude>(p => p.Matches(command, include));
	}

	public static PostLike IsPostLike(AddPostLikeCommand command)
	{
		return Matcher.Is<PostLike>(p => p.Matches(command));
	}

	public static PostLike IsPostLike(DeletePostLikeCommand command)
	{
		return Matcher.Is<PostLike>(p => p.Matches(command));
	}

	public static PostLikeAddedEventRequest IsPostLikeAddedEventRequest(AddPostLikeCommand command, PostLike postLike)
	{
		return Matcher.Is<PostLikeAddedEventRequest>(p => p.Matches(command, postLike));
	}

	public static PostLikeDeletedEventRequest IsPostLikeDeletedEventRequest(DeletePostLikeCommand command, PostLike postLike)
	{
		return Matcher.Is<PostLikeDeletedEventRequest>(p => p.Matches(command, postLike));
	}
}
