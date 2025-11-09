using InstaConnect.Posts.Domain.Features.PostComments.Helpers;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;

public static class PostCommentMockFactory
{
    public static IPostCommentService CreateService()
    {
        return Mocker.Mock<IPostCommentService>();
    }

    public static IPostCommentIncludeQueryBuilderFactory CreateIncludeQueryBuilderFactory()
    {
        return new PostCommentIncludeQueryBuilderFactory();
    }
}
