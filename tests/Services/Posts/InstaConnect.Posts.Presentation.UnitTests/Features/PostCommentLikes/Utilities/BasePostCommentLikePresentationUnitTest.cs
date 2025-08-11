using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Application.Abstractions;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Presentation.Extensions;

namespace InstaConnect.PostCommentLikes.Presentation.UnitTests.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikePresentationUnitTest : BasePostCommentLikeTest
{
    protected IApplicationSender ApplicationSender { get; }

    protected IApplicationMapper ApplicationMapper { get; }

    protected BasePostCommentLikePresentationUnitTest()
    {
        ApplicationSender = MockFactory.CreateApplicationSender();
        ApplicationMapper = MockFactory.CreateApplicationMapper(PostPresentationReference.Assembly);
    }
}
