namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.PostComments.Utilities;

public abstract class BasePostCommentPresentationQueryUnitTest : BasePostCommentPresentationUnitTest
{
    protected ICollection<User> Users { get; }

    protected ICollection<PostComment> PostComments { get; }

    protected BasePostCommentPresentationQueryUnitTest()
    {
        Users = User.GenerateRange();
        PostComments = PostComment.GenerateRange(Users);
    }
}
