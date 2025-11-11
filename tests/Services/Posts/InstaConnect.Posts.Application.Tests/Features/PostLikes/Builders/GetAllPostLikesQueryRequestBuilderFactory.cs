namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Builders;

public class GetAllPostLikesQueryRequestBuilderFactory
{
    public GetAllPostLikesQueryRequestBuilder Create(PostLike postLike, User user)
    {
        return new(postLike, user);
    }
}
