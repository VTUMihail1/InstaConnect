namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Builders;

public class GetPostLikeByIdQueryRequestBuilderFactory
{
    public GetPostLikeByIdQueryRequestBuilder Create(PostLike postLike)
    {
        return new(postLike);
    }
}
