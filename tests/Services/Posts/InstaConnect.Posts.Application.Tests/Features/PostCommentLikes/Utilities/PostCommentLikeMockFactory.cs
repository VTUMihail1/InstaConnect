namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeMockFactory
{
	public static IPostCommentLikeCommandService CreateCommandService()
	{
		return Mocker.Mock<IPostCommentLikeCommandService>();
	}

	public static IPostCommentLikeQueryService CreateQueryService()
	{
		return Mocker.Mock<IPostCommentLikeQueryService>();
	}
}
