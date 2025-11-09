using InstaConnect.Posts.Application.Extensions;

namespace InstaConnect.Posts.Application.Tests.Unit.Features.Posts.Utilities;

public abstract class BasePostApplicationUnitTest : BasePostTest
{
    protected IApplicationMapper ApplicationMapper { get; }

    protected IPostService PostService { get; }

    protected IPostIncludeQueryBuilderFactory PostIncludeQueryBuilderFactory { get; }

    protected BasePostApplicationUnitTest()
    {
        ApplicationMapper = MockFactory.CreateApplicationMapper(PostApplicationReference.Assembly);
        PostService = PostMockFactory.CreateService();
        PostIncludeQueryBuilderFactory = PostMockFactory.CreateIncludeQueryBuilderFactory();
    }
}
