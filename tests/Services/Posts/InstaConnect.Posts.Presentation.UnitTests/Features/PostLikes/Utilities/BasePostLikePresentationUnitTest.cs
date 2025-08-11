using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Application.Abstractions;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Presentation.Extensions;

namespace InstaConnect.PostLikes.Presentation.UnitTests.Features.PostLikes.Utilities;

public abstract class BasePostLikePresentationUnitTest : BasePostLikeTest
{
    protected IApplicationSender ApplicationSender { get; }

    protected IApplicationMapper ApplicationMapper { get; }

    protected BasePostLikePresentationUnitTest()
    {
        ApplicationSender = MockFactory.CreateApplicationSender();
        ApplicationMapper = MockFactory.CreateApplicationMapper(PostPresentationReference.Assembly);
    }
}
