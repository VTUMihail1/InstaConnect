using InstaConnect.Common.Domain.Models;
using InstaConnect.Posts.Domain.Features.PostComments.Helpers;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;

namespace InstaConnect.Posts.Application.Tests.Integration.Features.PostComments.Utilities;

public abstract class BasePostCommentApplicationQueryIntegrationTest : BasePostCommentApplicationIntegrationTest
{
    protected PostCommentIncludeQueryBuilderFactory IncludeBuilderFactory { get; }
    protected PostCommentIncludeQueryBuilder IncludeBuilder { get; }
    protected CommonIncludeQuery<PostCommentIncludeProperty> Include { get; }

    protected ICollection<User> Users { get; }

    protected ICollection<PostComment> PostComments { get; }

    protected BasePostCommentApplicationQueryIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        IncludeBuilderFactory = new();
        IncludeBuilder = IncludeBuilderFactory.Create();
        Include = IncludeBuilder.WithUser().Build();

        Users = User.GenerateRange();
        PostComments = PostComment.GenerateRange(Users);
    }
}
