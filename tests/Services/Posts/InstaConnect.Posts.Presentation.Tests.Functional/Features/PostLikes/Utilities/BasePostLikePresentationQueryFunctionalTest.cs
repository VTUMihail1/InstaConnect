using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.PostLikes.Utilities;

public abstract class BasePostLikePresentationQueryFunctionalTest : BasePostLikePresentationFunctionalTest
{
    protected ICollection<User> Users { get; }

    protected ICollection<PostLike> PostLikes { get; }

    protected BasePostLikePresentationQueryFunctionalTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        Users = User.GenerateRange();
        PostLikes = PostLike.GenerateRange(Users);
    }
}
