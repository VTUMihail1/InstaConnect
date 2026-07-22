using InstaConnect.Posts.Events.Features.Posts;
using InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Assertions;

public static class PostEventAssertions
{
	extension(PostAddedEventRequest r)
	{
		public bool ShouldSatisfy(AddPostApiRequest request, Post entity)
		{
			return r.Matches(request, entity);
		}
	}

	extension(PostUpdatedEventRequest r)
	{
		public bool ShouldSatisfy(UpdatePostApiRequest request, Post entity)
		{
			return r.Matches(request, entity);
		}
	}

	extension(PostDeletedEventRequest r)
	{
		public bool ShouldSatisfy(DeletePostApiRequest request, Post entity)
		{
			return r.Matches(request, entity);
		}
	}
}
