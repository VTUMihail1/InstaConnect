namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Builders;

public class DeletePostLikeApiRequestBuilderFactory
{
    public DeletePostLikeApiRequestBuilder Create(PostLike postLike)
    {
        return new(postLike);
    }
}
