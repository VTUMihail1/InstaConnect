namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;

public static class PostLikeApplicationMatcher
{
	extension(GetAllPostLikesQueryRequest request)
	{
		public GetAllPostLikesQuery IsGetAllPostLikesQuery()
		{
			return Matcher.Is<GetAllPostLikesQuery>(p => p.Matches(request));
		}
	}

	extension(GetAllPostLikesForUserQueryRequest request)
	{
		public GetAllPostLikesForUserQuery IsGetAllPostLikesForUserQuery()
		{
			return Matcher.Is<GetAllPostLikesForUserQuery>(p => p.Matches(request));
		}
	}

	extension(GetPostLikeByIdQueryRequest request)
	{
		public GetPostLikeByIdQuery IsGetPostLikeByIdQuery()
		{
			return Matcher.Is<GetPostLikeByIdQuery>(p => p.Matches(request));
		}
	}

	extension(AddPostLikeCommandRequest request)
	{
		public AddPostLikeCommand IsAddPostLikeCommand()
		{
			return Matcher.Is<AddPostLikeCommand>(p => p.Matches(request));
		}
	}

	extension(DeletePostLikeCommandRequest request)
	{
		public DeletePostLikeCommand IsDeletePostLikeCommand()
		{
			return Matcher.Is<DeletePostLikeCommand>(p => p.Matches(request));
		}
	}
}
