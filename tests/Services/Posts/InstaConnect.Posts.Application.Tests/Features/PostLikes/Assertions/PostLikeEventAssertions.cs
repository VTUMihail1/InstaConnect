using InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Events.Features.PostLikes;

namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Assertions;

public static class PostLikeEventAssertions
{
	extension(PostLikeAddedEventRequest r)
	{
		public bool ShouldSatisfy(AddPostLikeCommandRequest request, PostLike entity)
		{
			return r.Matches(request, entity);
		}
	}

	extension(PostLikeDeletedEventRequest r)
	{
		public bool ShouldSatisfy(DeletePostLikeCommandRequest request, PostLike entity)
		{
			return r.Matches(request, entity);
		}
	}
}
