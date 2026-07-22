using InstaConnect.Posts.Domain.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Events.Features.PostLikes;

namespace InstaConnect.Posts.Domain.Tests.Features.PostLikes.Assertions;

public static class PostLikeEventAssertions
{
	extension(PostLikeAddedEventRequest r)
	{
		public bool ShouldSatisfy(AddPostLikeCommand command, PostLike entity)
		{
			return r.Matches(command, entity);
		}
	}

	extension(PostLikeDeletedEventRequest r)
	{
		public bool ShouldSatisfy(DeletePostLikeCommand command, PostLike entity)
		{
			return r.Matches(command, entity);
		}
	}
}
