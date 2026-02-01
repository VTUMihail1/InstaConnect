using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.Posts.Utilities;
public abstract class BasePostTest : BaseTest
{
    protected UserBuilderFactory UserBuilderFactory { get; }
    protected UserBuilder UserBuilder { get; }
    protected User User { get; }
    protected ICollection<User> Users { get; }

    protected PostBuilderFactory PostBuilderFactory { get; }
    protected PostBuilder PostBuilder { get; }
    protected Post Post { get; }
    protected ICollection<Post> Posts { get; }

    protected PostLikeBuilderFactory PostLikeBuilderFactory { get; }
    protected PostLikeBuilder PostLikeBuilder { get; }
    protected PostLike PostLike { get; }
    protected ICollection<PostLike> PostLikes { get; }

    protected CancellationToken CancellationToken { get; }

    protected BasePostTest()
    {
        UserBuilderFactory = new();
        UserBuilder = UserBuilderFactory.Create();
        User = UserBuilder.Build();
        Users = User.GenerateUsersRange();

        PostBuilderFactory = new();
        PostBuilder = PostBuilderFactory.Create(User);
        Post = PostBuilder.Build();
        Posts = Post.GeneratePostsRange(Users);

        PostLikeBuilderFactory = new();
        PostLikeBuilder = PostLikeBuilderFactory.Create(Post, User);
        PostLike = PostLikeBuilder.Build();
        PostLikes = [.. Posts.SelectMany(x => x.PostLikes)];

        CancellationToken = MockFactory.CreateCancellationToken();
    }
}
