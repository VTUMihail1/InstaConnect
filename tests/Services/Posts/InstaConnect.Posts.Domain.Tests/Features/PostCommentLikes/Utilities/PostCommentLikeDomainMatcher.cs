using InstaConnect.Posts.Events.Features.PostCommentLikes;

namespace InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeDomainMatcher
{
	extension(AddPostCommentLikeCommand command)
	{
		public PostCommentInclude IsPostCommentInclude(PostCommentInclude include)
		{
			return Matcher.Is<PostCommentInclude>(p => p.Matches(command, include));
		}

		public PostCommentLike IsPostCommentLike()
		{
			return Matcher.Is<PostCommentLike>(p => p.Matches(command));
		}

		public PostCommentLikeAddedEventRequest IsPostCommentLikeAddedEventRequest(PostCommentLike postCommentLike)
		{
			return Matcher.Is<PostCommentLikeAddedEventRequest>(p => p.Matches(command, postCommentLike));
		}
	}

	extension(DeletePostCommentLikeCommand command)
	{
		public PostCommentLikeInclude IsPostCommentLikeInclude(PostCommentLikeInclude include)
		{
			return Matcher.Is<PostCommentLikeInclude>(p => p.Matches(command, include));
		}

		public PostCommentLike IsPostCommentLike()
		{
			return Matcher.Is<PostCommentLike>(p => p.Matches(command));
		}

		public PostCommentLikeDeletedEventRequest IsPostCommentLikeDeletedEventRequest(PostCommentLike postCommentLike)
		{
			return Matcher.Is<PostCommentLikeDeletedEventRequest>(p => p.Matches(command, postCommentLike));
		}
	}
}
