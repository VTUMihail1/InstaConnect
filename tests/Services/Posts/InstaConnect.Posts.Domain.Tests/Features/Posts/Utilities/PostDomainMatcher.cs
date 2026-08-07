using InstaConnect.Posts.Events.Features.Posts;

namespace InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;

public static class PostDomainMatcher
{
	public static PostInclude IsPostInclude(UpdatePostCommand command, PostInclude include)
	{
		return Matcher.Is<PostInclude>(p => p.Matches(command, include));
	}

	public static PostInclude IsPostInclude(DeletePostCommand command, PostInclude include)
	{
		return Matcher.Is<PostInclude>(p => p.Matches(command, include));
	}

	public static Post IsPost(AddPostCommand command)
	{
		return Matcher.Is<Post>(p => p.Matches(command));
	}

	public static Post IsPost(UpdatePostCommand command)
	{
		return Matcher.Is<Post>(p => p.Matches(command));
	}

	public static Post IsPost(DeletePostCommand command)
	{
		return Matcher.Is<Post>(p => p.Matches(command));
	}

	public static PostAddedEventRequest IsPostAddedEventRequest(AddPostCommand command, Post post)
	{
		return Matcher.Is<PostAddedEventRequest>(p => p.Matches(command, post));
	}

	public static PostUpdatedEventRequest IsPostUpdatedEventRequest(UpdatePostCommand command, Post post)
	{
		return Matcher.Is<PostUpdatedEventRequest>(p => p.Matches(command, post));
	}

	public static PostDeletedEventRequest IsPostDeletedEventRequest(DeletePostCommand command, Post post)
	{
		return Matcher.Is<PostDeletedEventRequest>(p => p.Matches(command, post));
	}
}
