using InstaConnect.Posts.Domain.Features.Posts.Models.ValueObjects;

namespace InstaConnect.Posts.Tests.Features.Posts.Utilities;

public static class PostMapper
{
	extension(Post post)
	{
		public PostId ToId()
		{
			return post.Id;
		}
	}
}
