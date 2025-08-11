using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Common.Tests.Features.Utilities;

namespace InstaConnect.PostComments.Presentation.FunctionalTests.Features.PostComments.Utilities;

public abstract class BasePostCommentPresentationFunctionalTest : BasePostCommentWebTest
{
    protected HttpClient HttpClient { get; }

    protected BasePostCommentPresentationFunctionalTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        HttpClient = webApplicationFactory.CreateClient();
    }
}
