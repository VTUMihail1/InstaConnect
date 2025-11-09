namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Builders;

public class DeletePostCommentCommandRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<DeletePostCommentCommandRequest> _objectBuilderFactory = new();

    public DeletePostCommentCommandRequestBuilder Create(PostComment postComment)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new DeletePostCommentCommandRequestBuilder(objectBuilder, postComment);

        return requestBuilder;
    }
}
