namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;

public static class PostCommentApplicationMatcher
{
	extension(GetAllPostCommentsQueryRequest request)
	{
		public GetAllPostCommentsQuery IsGetAllPostCommentsQuery()
		{
			return Matcher.Is<GetAllPostCommentsQuery>(p => p.Matches(request));
		}
	}

	extension(GetAllPostCommentsForUserQueryRequest request)
	{
		public GetAllPostCommentsForUserQuery IsGetAllPostCommentsForUserQuery()
		{
			return Matcher.Is<GetAllPostCommentsForUserQuery>(p => p.Matches(request));
		}
	}

	extension(GetPostCommentByIdQueryRequest request)
	{
		public GetPostCommentByIdQuery IsGetPostCommentByIdQuery()
		{
			return Matcher.Is<GetPostCommentByIdQuery>(p => p.Matches(request));
		}
	}

	extension(AddPostCommentCommandRequest request)
	{
		public AddPostCommentCommand IsAddPostCommentCommand()
		{
			return Matcher.Is<AddPostCommentCommand>(p => p.Matches(request));
		}
	}

	extension(UpdatePostCommentCommandRequest request)
	{
		public UpdatePostCommentCommand IsUpdatePostCommentCommand()
		{
			return Matcher.Is<UpdatePostCommentCommand>(p => p.Matches(request));
		}
	}

	extension(DeletePostCommentCommandRequest request)
	{
		public DeletePostCommentCommand IsDeletePostCommentCommand()
		{
			return Matcher.Is<DeletePostCommentCommand>(p => p.Matches(request));
		}
	}
}
