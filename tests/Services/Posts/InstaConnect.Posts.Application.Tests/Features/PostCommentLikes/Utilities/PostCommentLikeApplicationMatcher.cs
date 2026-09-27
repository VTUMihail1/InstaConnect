namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeApplicationMatcher
{
	extension(GetAllPostCommentLikesQueryRequest request)
	{
		public GetAllPostCommentLikesQuery IsGetAllPostCommentLikesQuery()
		{
			return Matcher.Is<GetAllPostCommentLikesQuery>(p => p.Matches(request));
		}
	}

	extension(GetAllPostCommentLikesForUserQueryRequest request)
	{
		public GetAllPostCommentLikesForUserQuery IsGetAllPostCommentLikesForUserQuery()
		{
			return Matcher.Is<GetAllPostCommentLikesForUserQuery>(p => p.Matches(request));
		}
	}

	extension(GetPostCommentLikeByIdQueryRequest request)
	{
		public GetPostCommentLikeByIdQuery IsGetPostCommentLikeByIdQuery()
		{
			return Matcher.Is<GetPostCommentLikeByIdQuery>(p => p.Matches(request));
		}
	}

	extension(AddPostCommentLikeCommandRequest request)
	{
		public AddPostCommentLikeCommand IsAddPostCommentLikeCommand()
		{
			return Matcher.Is<AddPostCommentLikeCommand>(p => p.Matches(request));
		}
	}

	extension(DeletePostCommentLikeCommandRequest request)
	{
		public DeletePostCommentLikeCommand IsDeletePostCommentLikeCommand()
		{
			return Matcher.Is<DeletePostCommentLikeCommand>(p => p.Matches(request));
		}
	}
}
