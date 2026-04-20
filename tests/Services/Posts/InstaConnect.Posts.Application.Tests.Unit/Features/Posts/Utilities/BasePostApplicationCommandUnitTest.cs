using InstaConnect.Posts.Application.Extensions;

namespace InstaConnect.Posts.Application.Tests.Unit.Features.Posts.Utilities;

public abstract class BasePostApplicationCommandUnitTest : BasePostTest
{
    protected IApplicationMapper Mapper { get; }

    protected IPostCommandService Service { get; }

    protected BasePostApplicationCommandUnitTest()
    {
        Mapper = MockFactory.CreateMapper(PostsApplicationReference.Assembly);
        Service = PostMockFactory.CreateCommandService();
    }
}
