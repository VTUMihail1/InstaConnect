using InstaConnect.Common.Domain.Models;
using InstaConnect.Posts.Domain.Features.Posts.Helpers;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Application.Tests.Integration.Features.Posts.Utilities;

public abstract class BasePostApplicationQueryIntegrationTest : BasePostApplicationIntegrationTest
{
    protected PostIncludeQueryBuilderFactory IncludeBuilderFactory { get; }
    protected PostIncludeQueryBuilder IncludeBuilder { get; }
    protected CommonIncludeQuery<PostIncludeProperty> Include { get; }

    protected ICollection<User> Users { get; }

    protected ICollection<Post> Posts { get; }

    protected BasePostApplicationQueryIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        IncludeBuilderFactory = new();
        IncludeBuilder = IncludeBuilderFactory.Create();
        Include = IncludeBuilder.WithUser().Build();

        Users = User.GenerateRange();
        Posts = Post.GenerateRange(Users);
    }
}
