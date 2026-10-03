using InstaConnect.Posts.Events.Features.PostLikes;

namespace InstaConnect.Posts.Domain.Tests.Features.PostLikes.Utilities;

public static class PostLikeDomainMatcher
{
	extension(AddPostLikeCommand command)
	{
		public PostInclude IsPostInclude(PostInclude include)
		{
			return Matcher.Is<PostInclude>(p => p.Matches(command, include));
		}

		public PostLike IsPostLike()
		{
			return Matcher.Is<PostLike>(p => p.Matches(command));
		}

		public PostLikeAddedEventRequest IsPostLikeAddedEventRequest(PostLike postLike)
		{
			return Matcher.Is<PostLikeAddedEventRequest>(p => p.Matches(command, postLike));
		}
	}

	extension(DeletePostLikeCommand command)
	{
		public PostLikeInclude IsPostLikeInclude(PostLikeInclude include)
		{
			return Matcher.Is<PostLikeInclude>(p => p.Matches(command, include));
		}

		public PostLike IsPostLike()
		{
			return Matcher.Is<PostLike>(p => p.Matches(command));
		}

		public PostLikeDeletedEventRequest IsPostLikeDeletedEventRequest(PostLike postLike)
		{
			return Matcher.Is<PostLikeDeletedEventRequest>(p => p.Matches(command, postLike));
		}
	}
}
