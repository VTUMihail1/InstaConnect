namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Builders;

public class GetPostCommentByIdApiRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<GetPostCommentByIdApiRequest> _objectBuilderFactory = new();

    public GetPostCommentByIdApiRequestBuilder Create(PostComment postComment)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new GetPostCommentByIdApiRequestBuilder(objectBuilder, postComment);

        return requestBuilder;
    }
}
