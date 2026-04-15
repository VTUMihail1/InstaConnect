namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Builders;

public class AddPostLikeCommandRequestBuilderFactory
{
    public AddPostLikeCommandRequestBuilder Create(Post post, User user)
    {
        return new(post, user);
    }
}
