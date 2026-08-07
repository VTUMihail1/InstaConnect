namespace InstaConnect.Posts.Domain.Features.PostLikes.Extensions;

public static class PostLikeCollectionExtensions
{
	extension(ICollection<PostLike> postLikes)
	{
		public ICollection<PostLike> AddUser(User user)
		{
			foreach (var postLike in postLikes)
			{
				postLike.AddUser(user);
			}

			return postLikes;
		}

		public ICollection<PostLike> AddPost(Post post)
		{
			foreach (var postLike in postLikes)
			{
				postLike.AddPost(post);
			}

			return postLikes;
		}
	}
}
