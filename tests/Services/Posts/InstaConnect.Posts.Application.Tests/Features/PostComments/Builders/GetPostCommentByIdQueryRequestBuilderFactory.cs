namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Builders;

public class GetPostCommentByIdQueryRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<GetPostCommentByIdQueryRequest> _objectBuilderFactory = new();

    public GetPostCommentByIdQueryRequestBuilder Create(PostComment postComment)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new GetPostCommentByIdQueryRequestBuilder(objectBuilder, postComment);

        return requestBuilder;
    }
}
