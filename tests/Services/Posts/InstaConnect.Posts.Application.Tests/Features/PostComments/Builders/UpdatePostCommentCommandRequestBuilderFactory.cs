namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Builders;

public class UpdatePostCommentCommandRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<UpdatePostCommentCommandRequest> _objectBuilderFactory = new();

    public UpdatePostCommentCommandRequestBuilder Create(PostComment postComment)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new UpdatePostCommentCommandRequestBuilder(objectBuilder, postComment);

        return requestBuilder;
    }
}
