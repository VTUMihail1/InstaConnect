using InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Events.Features.Posts;

namespace InstaConnect.Posts.Application.Tests.Features.Posts.Assertions;

public static class PostEventAssertions
{
	extension(PostAddedEventRequest r)
	{
		public bool ShouldSatisfy(AddPostCommandRequest request, Post entity)
		{
			return r.Matches(request, entity);
		}
	}

	extension(PostUpdatedEventRequest r)
	{
		public bool ShouldSatisfy(UpdatePostCommandRequest request, Post entity)
		{
			return r.Matches(request, entity);
		}
	}

	extension(PostDeletedEventRequest r)
	{
		public bool ShouldSatisfy(DeletePostCommandRequest request, Post entity)
		{
			return r.Matches(request, entity);
		}
	}
}
