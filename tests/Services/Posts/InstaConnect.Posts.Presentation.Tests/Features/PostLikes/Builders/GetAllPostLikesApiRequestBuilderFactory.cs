namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Builders;

public class GetAllPostLikesApiRequestBuilderFactory
{
    public GetAllPostLikesApiRequestBuilder Create(PostLike postLike)
    {
        return new(postLike);
    }
}
