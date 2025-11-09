namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Builders;

public class GetPostLikeByIdQueryRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<GetPostLikeByIdQueryRequest> _objectBuilderFactory = new();

    public GetPostLikeByIdQueryRequestBuilder Create(PostLike postLike)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new GetPostLikeByIdQueryRequestBuilder(objectBuilder, postLike);

        return requestBuilder;
    }
}
