using InstaConnect.Posts.Events.Features.PostLikes;
using InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Assertions;

public static class PostLikeEventAssertions
{
	extension(PostLikeAddedEventRequest r)
	{
		public bool ShouldSatisfy(AddPostLikeApiRequest request, PostLike entity)
		{
			return r.Matches(request, entity);
		}
	}

	extension(PostLikeDeletedEventRequest r)
	{
		public bool ShouldSatisfy(DeletePostLikeApiRequest request, PostLike entity)
		{
			return r.Matches(request, entity);
		}
	}
}
