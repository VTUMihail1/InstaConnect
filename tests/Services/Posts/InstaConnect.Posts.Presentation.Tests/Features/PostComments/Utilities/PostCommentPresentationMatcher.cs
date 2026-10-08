namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;

public static class PostCommentPresentationMatcher
{
	extension(GetAllPostCommentsApiRequest request)
	{
		public GetAllPostCommentsQueryRequest IsGetAllPostCommentsQueryRequest()
		{
			return Matcher.Is<GetAllPostCommentsQueryRequest>(p => p.Matches(request));
		}
	}

	extension(GetAllPostCommentsForUserApiRequest request)
	{
		public GetAllPostCommentsForUserQueryRequest IsGetAllPostCommentsForUserQueryRequest()
		{
			return Matcher.Is<GetAllPostCommentsForUserQueryRequest>(p => p.Matches(request));
		}
	}

	extension(GetPostCommentByIdApiRequest request)
	{
		public GetPostCommentByIdQueryRequest IsGetPostCommentByIdQueryRequest()
		{
			return Matcher.Is<GetPostCommentByIdQueryRequest>(p => p.Matches(request));
		}
	}

	extension(AddPostCommentApiRequest request)
	{
		public AddPostCommentCommandRequest IsAddPostCommentCommandRequest()
		{
			return Matcher.Is<AddPostCommentCommandRequest>(p => p.Matches(request));
		}
	}

	extension(UpdatePostCommentApiRequest request)
	{
		public UpdatePostCommentCommandRequest IsUpdatePostCommentCommandRequest()
		{
			return Matcher.Is<UpdatePostCommentCommandRequest>(p => p.Matches(request));
		}
	}

	extension(DeletePostCommentApiRequest request)
	{
		public DeletePostCommentCommandRequest IsDeletePostCommentCommandRequest()
		{
			return Matcher.Is<DeletePostCommentCommandRequest>(p => p.Matches(request));
		}
	}
}
