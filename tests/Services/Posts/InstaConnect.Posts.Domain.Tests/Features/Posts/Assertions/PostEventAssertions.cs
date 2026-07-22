using InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Events.Features.Posts;

namespace InstaConnect.Posts.Domain.Tests.Features.Posts.Assertions;

public static class PostEventAssertions
{
	extension(PostAddedEventRequest r)
	{
		public bool ShouldSatisfy(AddPostCommand command, Post entity)
		{
			return r.Matches(command, entity);
		}
	}

	extension(PostUpdatedEventRequest r)
	{
		public bool ShouldSatisfy(UpdatePostCommand command, Post entity)
		{
			return r.Matches(command, entity);
		}
	}

	extension(PostDeletedEventRequest r)
	{
		public bool ShouldSatisfy(DeletePostCommand command, Post entity)
		{
			return r.Matches(command, entity);
		}
	}
}
