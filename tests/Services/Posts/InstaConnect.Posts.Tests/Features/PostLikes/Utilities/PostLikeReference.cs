using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

public static class PostLikeReference
{
	extension(PostLike? postLike)
	{
		public PostLike? SetUser()
		{
			postLike?.User?.AddPostLike(postLike);

			return postLike;
		}

		public PostLike? SetPost()
		{
			postLike?.Post?.AddPostLike(postLike);
			postLike?.Post?.SetUser();

			return postLike;
		}
	}
}
