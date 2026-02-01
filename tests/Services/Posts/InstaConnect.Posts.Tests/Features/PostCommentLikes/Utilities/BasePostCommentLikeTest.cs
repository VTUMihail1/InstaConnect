using InstaConnect.Posts.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;
public abstract class BasePostCommentLikeTest : BaseTest
{
    protected UserBuilderFactory UserBuilderFactory { get; }
    protected UserBuilder UserBuilder { get; }
    protected User User { get; }
    protected ICollection<User> Users { get; }

    protected PostBuilderFactory PostBuilderFactory { get; }
    protected PostBuilder PostBuilder { get; }
    protected Post Post { get; }

    protected PostLikeBuilderFactory PostLikeBuilderFactory { get; }
    protected PostLikeBuilder PostLikeBuilder { get; }
    protected PostLike PostLike { get; }

    protected PostCommentBuilderFactory PostCommentBuilderFactory { get; }
    protected PostCommentBuilder PostCommentBuilder { get; }
    protected PostComment PostComment { get; }
    protected ICollection<PostComment> PostComments { get; }

    protected PostCommentLikeBuilderFactory PostCommentLikeBuilderFactory { get; }
    protected PostCommentLikeBuilder PostCommentLikeBuilder { get; }
    protected PostCommentLike PostCommentLike { get; }
    protected ICollection<PostCommentLike> PostCommentLikes { get; }

    protected CancellationToken CancellationToken { get; }

    protected BasePostCommentLikeTest()
    {
        UserBuilderFactory = new();
        UserBuilder = UserBuilderFactory.Create();
        User = UserBuilder.Build();
        Users = User.GenerateUsersRange();

        PostBuilderFactory = new();
        PostBuilder = PostBuilderFactory.Create(User);
        Post = PostBuilder.Build();

        PostLikeBuilderFactory = new();
        PostLikeBuilder = PostLikeBuilderFactory.Create(Post, User);
        PostLike = PostLikeBuilder.Build();

        PostCommentBuilderFactory = new();
        PostCommentBuilder = PostCommentBuilderFactory.Create(Post, User);
        PostComment = PostCommentBuilder.Build();
        PostComments = PostComment.GeneratePostCommentsRange(Users);

        PostCommentLikeBuilderFactory = new();
        PostCommentLikeBuilder = PostCommentLikeBuilderFactory.Create(PostComment, User);
        PostCommentLike = PostCommentLikeBuilder.Build();
        PostCommentLikes = PostComments.GeneratePostCommentLikesRange(Users);

        CancellationToken = MockFactory.CreateCancellationToken();
    }
}
