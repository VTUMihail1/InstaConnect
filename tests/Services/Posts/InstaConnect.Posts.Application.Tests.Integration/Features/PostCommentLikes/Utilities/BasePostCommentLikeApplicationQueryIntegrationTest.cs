using InstaConnect.Common.Domain.Models;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Helpers;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;

namespace InstaConnect.Posts.Application.Tests.Integration.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikeApplicationQueryIntegrationTest : BasePostCommentLikeApplicationIntegrationTest
{
    protected PostCommentLikeIncludeQueryBuilderFactory IncludeBuilderFactory { get; }
    protected PostCommentLikeIncludeQueryBuilder IncludeBuilder { get; }
    protected CommonIncludeQuery<PostCommentLikeIncludeProperty> Include { get; }

    protected ICollection<User> Users { get; }

    protected ICollection<PostCommentLike> PostCommentLikes { get; }

    protected BasePostCommentLikeApplicationQueryIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        IncludeBuilderFactory = new();
        IncludeBuilder = IncludeBuilderFactory.Create();
        Include = IncludeBuilder.WithUser().Build();

        Users = User.GenerateRange();
        PostCommentLikes = PostCommentLike.GenerateRange(Users);
    }
}
