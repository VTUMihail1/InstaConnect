namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;

public static class PostCommentMockFactory
{
	public static IPostCommentCommandService CreateCommandService()
	{
		return Mocker.Mock<IPostCommentCommandService>();
	}

	public static IPostCommentQueryService CreateQueryService()
	{
		return Mocker.Mock<IPostCommentQueryService>();
	}
}
