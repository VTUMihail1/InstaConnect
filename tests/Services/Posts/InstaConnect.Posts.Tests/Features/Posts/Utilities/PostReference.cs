namespace InstaConnect.Posts.Tests.Features.Posts.Utilities;

public static class PostReference
{
	extension(Post? post)
	{
		public Post? SetUser()
		{
			post?.User?.AddPost(post);

			return post;
		}
	}
}
