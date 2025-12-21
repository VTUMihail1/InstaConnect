namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.PostLikes.Utilities;

public abstract class BasePostLikePresentationQueryUnitTest : BasePostLikePresentationUnitTest
{
    protected ICollection<User> Users { get; }

    protected ICollection<PostLike> PostLikes { get; }

    protected BasePostLikePresentationQueryUnitTest()
    {
        Users = User.GenerateRange();
        PostLikes = PostLike.GenerateRange(Users);
    }
}
