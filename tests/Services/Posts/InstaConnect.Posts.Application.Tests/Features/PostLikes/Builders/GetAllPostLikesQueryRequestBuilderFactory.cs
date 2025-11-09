namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Builders;

public class GetAllPostLikesQueryRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<GetAllPostLikesQueryRequest> _objectBuilderFactory = new();

    public GetAllPostLikesQueryRequestBuilder Create(PostLike postLike, User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new GetAllPostLikesQueryRequestBuilder(objectBuilder, postLike, user);

        return requestBuilder;
    }
}
