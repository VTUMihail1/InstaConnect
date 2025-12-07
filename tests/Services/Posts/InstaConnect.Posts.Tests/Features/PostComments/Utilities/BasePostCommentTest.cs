namespace InstaConnect.Posts.Tests.Features.PostComments.Utilities;
public abstract class BasePostCommentTest : BaseTest
{
    protected UserBuilderFactory UserBuilderFactory { get; }
    protected UserBuilder UserBuilder { get; }
    protected User User { get; }

    protected PostBuilderFactory PostBuilderFactory { get; }
    protected PostBuilder PostBuilder { get; }
    protected Post Post { get; }

    protected PostCommentBuilderFactory PostCommentBuilderFactory { get; }
    protected PostCommentBuilder PostCommentBuilder { get; }
    protected PostComment PostComment { get; }

    protected CancellationToken CancellationToken { get; }

    protected BasePostCommentTest()
    {
        UserBuilderFactory = new();
        UserBuilder = UserBuilderFactory.Create();
        User = UserBuilder.Build();

        PostBuilderFactory = new();
        PostBuilder = PostBuilderFactory.Create(User);
        Post = PostBuilder.Build();

        PostCommentBuilderFactory = new();
        PostCommentBuilder = PostCommentBuilderFactory.Create(Post, User);
        PostComment = PostCommentBuilder.Build();

        CancellationToken = MockFactory.CreateCancellationToken();
    }
}
