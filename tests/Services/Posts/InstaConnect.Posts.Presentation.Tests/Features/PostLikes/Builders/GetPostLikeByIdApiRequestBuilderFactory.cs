namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Builders;

public class GetPostLikeByIdApiRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<GetPostLikeByIdApiRequest> _objectBuilderFactory = new();

    public GetPostLikeByIdApiRequestBuilder Create(PostLike postLike)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new GetPostLikeByIdApiRequestBuilder(objectBuilder, postLike);

        return requestBuilder;
    }
}
