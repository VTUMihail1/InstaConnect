using InstaConnect.Posts.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeReference
{
	extension(PostCommentLike? postCommentLike)
	{
		public PostCommentLike? SetUser()
		{
			postCommentLike?.User?.AddPostCommentLike(postCommentLike);

			return postCommentLike;
		}

		public PostCommentLike? SetPostComment()
		{
			postCommentLike?.PostComment?.AddPostCommentLike(postCommentLike);
			postCommentLike?.PostComment?.SetUser().SetPost();

			return postCommentLike;
		}
	}
}
