using InstaConnect.Common.Domain.Models;
using InstaConnect.Posts.Domain.Features.PostLikes.Helpers;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;

namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostLikes.Utilities;

public abstract class BasePostLikeApplicationQueryUnitTest : BasePostLikeApplicationUnitTest
{
    protected PostLikeIncludeQueryBuilderFactory IncludeBuilderFactory { get; }
    protected PostLikeIncludeQueryBuilder IncludeBuilder { get; }
    protected CommonIncludeQuery<PostLikeIncludeProperty> Include { get; }

    protected ICollection<User> Users { get; }

    protected ICollection<PostLike> PostLikes { get; }

    protected BasePostLikeApplicationQueryUnitTest()
    {
        IncludeBuilderFactory = new();
        IncludeBuilder = IncludeBuilderFactory.Create();
        Include = IncludeBuilder.WithUser().Build();

        Users = User.GenerateRange();
        PostLikes = PostLike.GenerateRange(Users);
    }
}
