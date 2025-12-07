namespace InstaConnect.Posts.Tests.Features.PostLikes.Utilities;
public abstract class BasePostLikeTest : BaseTest
{
    protected UserBuilderFactory UserBuilderFactory { get; }
    protected UserBuilder UserBuilder { get; }
    protected User User { get; }

    protected PostBuilderFactory PostBuilderFactory { get; }
    protected PostBuilder PostBuilder { get; }
    protected Post Post { get; }

    protected PostLikeBuilderFactory PostLikeBuilderFactory { get; }
    protected PostLikeBuilder PostLikeBuilder { get; }
    protected PostLike PostLike { get; }

    protected CancellationToken CancellationToken { get; }

    protected BasePostLikeTest()
    {
        UserBuilderFactory = new();
        UserBuilder = UserBuilderFactory.Create();
        User = UserBuilder.Build();

        PostBuilderFactory = new();
        PostBuilder = PostBuilderFactory.Create(User);
        Post = PostBuilder.Build();

        PostLikeBuilderFactory = new();
        PostLikeBuilder = PostLikeBuilderFactory.Create(Post, User);
        PostLike = PostLikeBuilder.Build();

        CancellationToken = MockFactory.CreateCancellationToken();
    }
}
