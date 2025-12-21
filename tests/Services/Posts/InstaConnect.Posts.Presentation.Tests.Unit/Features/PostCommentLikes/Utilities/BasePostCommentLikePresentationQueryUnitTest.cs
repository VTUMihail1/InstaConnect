namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikePresentationQueryUnitTest : BasePostCommentLikePresentationUnitTest
{
    protected ICollection<User> Users { get; }

    protected ICollection<PostCommentLike> PostCommentLikes { get; }

    protected BasePostCommentLikePresentationQueryUnitTest()
    {
        Users = User.GenerateRange();
        PostCommentLikes = PostCommentLike.GenerateRange(Users);
    }
}
