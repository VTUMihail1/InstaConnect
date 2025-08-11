using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Common.Tests.Features.Utilities;

namespace InstaConnect.PostLikes.Presentation.FunctionalTests.Features.PostLikes.Utilities;

public abstract class BasePostLikePresentationFunctionalTest : BasePostLikeWebTest
{
    protected HttpClient HttpClient { get; }

    protected BasePostLikePresentationFunctionalTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        HttpClient = webApplicationFactory.CreateClient();
    }
}
