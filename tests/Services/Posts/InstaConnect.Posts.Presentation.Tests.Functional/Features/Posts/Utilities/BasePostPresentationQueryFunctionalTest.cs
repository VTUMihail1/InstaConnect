using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.Posts.Utilities;

public abstract class BasePostPresentationQueryFunctionalTest : BasePostPresentationFunctionalTest
{
    protected ICollection<User> Users { get; }

    protected ICollection<Post> Posts { get; }

    protected BasePostPresentationQueryFunctionalTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        Users = User.GenerateRange();
        Posts = Post.GenerateRange(Users);
    }
}
