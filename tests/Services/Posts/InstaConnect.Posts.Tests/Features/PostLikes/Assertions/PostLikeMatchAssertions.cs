using InstaConnect.Posts.Tests.Features.PostLikes.Assertions;
using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.Assertions;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Users.Assertions;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostLikes.Assertions;

public static class PostLikeMatchAssertions
{
	extension(PostLike p)
	{
		public void ShouldSatisfy(PostLike postLike)
		{
			p.ShouldSatisfy(u => u.Matches(postLike));
		}
	}
}
