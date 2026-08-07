namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Extensions;

public static class PostCommentLikeCollectionExtensions
{
	extension(ICollection<PostCommentLike> postCommentLikes)
	{
		public ICollection<PostCommentLike> AddUser(User user)
		{
			foreach (var postCommentLike in postCommentLikes)
			{
				postCommentLike.AddUser(user);
			}

			return postCommentLikes;
		}

		public ICollection<PostCommentLike> AddPostComment(PostComment postComment)
		{
			foreach (var postCommentLike in postCommentLikes)
			{
				postCommentLike.AddPostComment(postComment);
			}

			return postCommentLikes;
		}
	}
}
