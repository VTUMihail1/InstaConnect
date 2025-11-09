namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;
public abstract class BasePostCommentLikeTest
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

    protected PostCommentLikeBuilderFactory PostCommentLikeBuilderFactory { get; }
    protected PostCommentLikeBuilder PostCommentLikeBuilder { get; }
    protected PostCommentLike PostCommentLike { get; }

    protected CancellationToken CancellationToken { get; }

    protected BasePostCommentLikeTest()
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

        PostCommentLikeBuilderFactory = new();
        PostCommentLikeBuilder = PostCommentLikeBuilderFactory.Create(Post, PostComment, User);
        PostCommentLike = PostCommentLikeBuilder.Build();

        CancellationToken = MockFactory.CreateCancellationToken();
    }
}
