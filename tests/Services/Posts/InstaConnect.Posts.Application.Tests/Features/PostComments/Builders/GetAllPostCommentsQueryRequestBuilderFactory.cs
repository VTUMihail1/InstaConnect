namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Builders;

public class GetAllPostCommentsQueryRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<GetAllPostCommentsQueryRequest> _objectBuilderFactory = new();

    public GetAllPostCommentsQueryRequestBuilder Create(PostComment postComment, User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new GetAllPostCommentsQueryRequestBuilder(objectBuilder, postComment, user);

        return requestBuilder;
    }
}
