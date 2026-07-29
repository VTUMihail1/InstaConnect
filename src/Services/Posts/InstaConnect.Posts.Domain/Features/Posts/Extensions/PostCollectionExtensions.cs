namespace InstaConnect.Posts.Domain.Features.Posts.Extensions;

public static class PostCollectionExtensions
{
	extension(ICollection<Post> posts)
	{
		public ICollection<Post> AddUser(User user)
		{
			foreach (var post in posts)
			{
				post.AddUser(user);
			}

			return posts;
		}
	}
}
