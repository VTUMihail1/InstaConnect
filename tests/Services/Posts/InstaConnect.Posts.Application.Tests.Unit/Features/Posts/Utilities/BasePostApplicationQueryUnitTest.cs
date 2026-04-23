using InstaConnect.Posts.Application.Features.Common.Extensions;

namespace InstaConnect.Posts.Application.Tests.Unit.Features.Posts.Utilities;

public abstract class BasePostApplicationQueryUnitTest : BasePostTest
{
    protected IApplicationMapper Mapper { get; }

    protected IPostQueryService Service { get; }

    protected BasePostApplicationQueryUnitTest()
    {
        Mapper = MockFactory.CreateMapper(PostsApplicationReference.Assembly);
        Service = PostMockFactory.CreateQueryService();
    }
}
