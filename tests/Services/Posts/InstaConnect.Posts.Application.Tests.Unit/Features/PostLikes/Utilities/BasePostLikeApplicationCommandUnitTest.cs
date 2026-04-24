using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Posts.Application.Features.Common.Extensions;

namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostLikes.Utilities;

public abstract class BasePostLikeApplicationCommandUnitTest : BasePostLikeTest
{
    protected IApplicationMapper Mapper { get; }

    protected IPostLikeCommandService LikeService { get; }

    protected BasePostLikeApplicationCommandUnitTest()
    {
        Mapper = MockFactory.CreateMapper(PostsApplicationReference.Assembly);
        LikeService = PostLikeMockFactory.CreateCommandService();
    }
}
