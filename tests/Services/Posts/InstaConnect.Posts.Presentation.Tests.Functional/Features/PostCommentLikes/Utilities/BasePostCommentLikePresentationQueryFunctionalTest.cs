using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikePresentationQueryFunctionalTest : BasePostCommentLikePresentationFunctionalTest
{
    protected ICollection<User> Users { get; }

    protected ICollection<PostCommentLike> PostCommentLikes { get; }

    protected BasePostCommentLikePresentationQueryFunctionalTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        Users = User.GenerateRange();
        PostCommentLikes = PostCommentLike.GenerateRange(Users);
    }
}
