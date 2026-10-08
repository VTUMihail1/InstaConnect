namespace InstaConnect.Posts.Domain.Features.PostComments.Extensions;

public static class PostCommentCollectionExtensions
{
	extension(ICollection<PostComment> postComments)
	{
		public ICollection<PostComment> AddUser(User user)
		{
			foreach (var postComment in postComments)
			{
				postComment.AddUser(user);
			}

			return postComments;
		}

		public ICollection<PostComment> AddPost(Post post)
		{
			foreach (var postComment in postComments)
			{
				postComment.AddPost(post);
			}

			return postComments;
		}
	}
}
