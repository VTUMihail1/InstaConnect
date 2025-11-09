using InstaConnect.Posts.Domain.Features.PostCommentLikes.Helpers;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeMockFactory
{
    public static IPostCommentLikeService CreateService()
    {
        return Mocker.Mock<IPostCommentLikeService>();
    }

    public static IPostCommentLikeIncludeQueryBuilderFactory CreateIncludeQueryBuilderFactory()
    {
        return new PostCommentLikeIncludeQueryBuilderFactory();
    }
}
