namespace InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;

public static class PostMatcher
{
	public static GetAllPostsQuery IsGetAllPostsQuery(GetAllPostsQueryRequest request)
	{
		return Matcher.Is<GetAllPostsQuery>(p => p.Matches(request));
	}

	public static GetAllPostsForUserQuery IsGetAllPostsForUserQuery(GetAllPostsForUserQueryRequest request)
	{
		return Matcher.Is<GetAllPostsForUserQuery>(p => p.Matches(request));
	}

	public static GetPostByIdQuery IsGetPostByIdQuery(GetPostByIdQueryRequest request)
	{
		return Matcher.Is<GetPostByIdQuery>(p => p.Matches(request));
	}

	public static AddPostCommand IsAddPostCommand(AddPostCommandRequest request)
	{
		return Matcher.Is<AddPostCommand>(p => p.Matches(request));
	}

	public static UpdatePostCommand IsUpdatePostCommand(UpdatePostCommandRequest request)
	{
		return Matcher.Is<UpdatePostCommand>(p => p.Matches(request));
	}

	public static DeletePostCommand IsDeletePostCommand(DeletePostCommandRequest request)
	{
		return Matcher.Is<DeletePostCommand>(p => p.Matches(request));
	}
}
