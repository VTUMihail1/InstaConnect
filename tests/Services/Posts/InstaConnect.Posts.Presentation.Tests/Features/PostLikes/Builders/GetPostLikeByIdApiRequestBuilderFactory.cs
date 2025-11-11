namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Builders;

public class GetPostLikeByIdApiRequestBuilderFactory
{
    public GetPostLikeByIdApiRequestBuilder Create(PostLike postLike)
    {
        return new(postLike);
    }
}
