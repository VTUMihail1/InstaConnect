namespace InstaConnect.Posts.Tests.Features.Posts.Utilities;

public static class PostReference
{
	extension(ICollection<Post> posts)
	{
		public ICollection<Post> SetUser()
		{
			foreach (var post in posts)
			{
				post.SetUser();
			}

			return posts;
		}
	}

	extension(Post? post)
	{
		public Post? SetUser()
		{
			post?.User?.AddPost(post);

			return post;
		}
	}
}
