namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Builders;

public class DeletePostCommentApiRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<DeletePostCommentApiRequest> _objectBuilderFactory = new();

    public DeletePostCommentApiRequestBuilder Create(PostComment postComment)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new DeletePostCommentApiRequestBuilder(objectBuilder, postComment);

        return requestBuilder;
    }
}
