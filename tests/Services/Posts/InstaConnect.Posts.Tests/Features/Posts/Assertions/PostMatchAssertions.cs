using InstaConnect.Posts.Tests.Features.Posts.Assertions;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Users.Assertions;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.Posts.Assertions;

public static class PostMatchAssertions
{
	extension(Post p)
	{
		public void ShouldSatisfy(Post post)
		{
			p.ShouldSatisfy(u => u.Matches(post));
		}
	}
}
