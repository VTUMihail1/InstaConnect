namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Builders;

public class GetAllPostLikesForUserQueryRequestBuilderFactory
{
    public GetAllPostLikesForUserQueryRequestBuilder Create(PostLike postLike)
    {
        return new(postLike);
    }
}
