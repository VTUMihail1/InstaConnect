using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.PostComments.Utilities;

public abstract class BasePostCommentPresentationQueryFunctionalTest : BasePostCommentPresentationFunctionalTest
{
    protected ICollection<User> Users { get; }

    protected ICollection<PostComment> PostComments { get; }

    protected BasePostCommentPresentationQueryFunctionalTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        Users = User.GenerateRange();
        PostComments = PostComment.GenerateRange(Users);
    }
}
