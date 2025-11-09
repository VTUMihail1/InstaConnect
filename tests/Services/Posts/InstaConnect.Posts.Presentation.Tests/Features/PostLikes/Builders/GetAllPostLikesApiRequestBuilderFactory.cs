namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Builders;

public class GetAllPostLikesApiRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<GetAllPostLikesApiRequest> _objectBuilderFactory = new();

    public GetAllPostLikesApiRequestBuilder Create(PostLike postLike, User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new GetAllPostLikesApiRequestBuilder(objectBuilder, postLike, user);

        return requestBuilder;
    }
}
