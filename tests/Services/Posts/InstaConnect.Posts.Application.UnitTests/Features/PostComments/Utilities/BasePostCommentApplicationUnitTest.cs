using InstaConnect.Common.Abstractions;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities;
using InstaConnect.PostComments.Domain.Features.PostComments.Abstractions;
using InstaConnect.Posts.Application.Extensions;

namespace InstaConnect.PostComments.Application.UnitTests.Features.PostComments.Utilities;

public abstract class BasePostCommentApplicationUnitTest : BasePostCommentTest
{
    protected IApplicationMapper ApplicationMapper { get; }

    protected IPostCommentService PostCommentService { get; }

    protected BasePostCommentApplicationUnitTest()
    {
        ApplicationMapper = MockFactory.CreateApplicationMapper(PostApplicationReference.Assembly);
        PostCommentService = PostCommentMockFactory.CreateService();
    }
}
