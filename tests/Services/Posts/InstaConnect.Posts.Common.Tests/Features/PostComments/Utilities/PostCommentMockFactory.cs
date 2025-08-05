using InstaConnect.Common.Tests.Utilities;
using InstaConnect.PostComments.Domain.Features.PostComments.Abstractions;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities;

public static class PostCommentMockFactory
{
    public static IPostCommentService CreateService()
    {
        return Mocker.Mock<IPostCommentService>();
    }
}
