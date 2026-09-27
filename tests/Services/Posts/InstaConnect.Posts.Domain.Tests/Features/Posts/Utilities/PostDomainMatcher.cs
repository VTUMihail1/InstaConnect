using InstaConnect.Posts.Events.Features.Posts;

namespace InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;

public static class PostDomainMatcher
{
	extension(UpdatePostCommand command)
	{
		public PostInclude IsPostInclude(PostInclude include)
		{
			return Matcher.Is<PostInclude>(p => p.Matches(command, include));
		}

		public Post IsPost()
		{
			return Matcher.Is<Post>(p => p.Matches(command));
		}

		public PostUpdatedEventRequest IsPostUpdatedEventRequest(Post post)
		{
			return Matcher.Is<PostUpdatedEventRequest>(p => p.Matches(command, post));
		}
	}

	extension(DeletePostCommand command)
	{
		public PostInclude IsPostInclude(PostInclude include)
		{
			return Matcher.Is<PostInclude>(p => p.Matches(command, include));
		}

		public Post IsPost()
		{
			return Matcher.Is<Post>(p => p.Matches(command));
		}

		public PostDeletedEventRequest IsPostDeletedEventRequest(Post post)
		{
			return Matcher.Is<PostDeletedEventRequest>(p => p.Matches(command, post));
		}
	}

	extension(AddPostCommand command)
	{
		public Post IsPost()
		{
			return Matcher.Is<Post>(p => p.Matches(command));
		}

		public PostAddedEventRequest IsPostAddedEventRequest(Post post)
		{
			return Matcher.Is<PostAddedEventRequest>(p => p.Matches(command, post));
		}
	}
}
