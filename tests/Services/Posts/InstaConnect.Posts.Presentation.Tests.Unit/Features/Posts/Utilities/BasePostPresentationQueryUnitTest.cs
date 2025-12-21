namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.Posts.Utilities;

public abstract class BasePostPresentationQueryUnitTest : BasePostPresentationUnitTest
{
    protected ICollection<User> Users { get; }

    protected ICollection<Post> Posts { get; }

    protected BasePostPresentationQueryUnitTest()
    {
        Users = User.GenerateRange();
        Posts = Post.GenerateRange(Users);
    }
}
