namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Builders;

public class GetAllPostCommentsApiRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<GetAllPostCommentsApiRequest> _objectBuilderFactory = new();

    public GetAllPostCommentsApiRequestBuilder Create(PostComment postComment, User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new GetAllPostCommentsApiRequestBuilder(objectBuilder, postComment, user);

        return requestBuilder;
    }
}
