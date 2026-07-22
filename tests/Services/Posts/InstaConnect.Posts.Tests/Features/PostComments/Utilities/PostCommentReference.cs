using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostComments.Utilities;

public static class PostCommentReference
{
	extension(PostComment? postComment)
	{
		public PostComment? SetUser()
		{
			postComment?.User?.AddPostComment(postComment);

			return postComment;
		}

		public PostComment? SetPost()
		{
			postComment?.Post?.AddPostComment(postComment);
			postComment?.Post?.SetUser();

			return postComment;
		}
	}
}
