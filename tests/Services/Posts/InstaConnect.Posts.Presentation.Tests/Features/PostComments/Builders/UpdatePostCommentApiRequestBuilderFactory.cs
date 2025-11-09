namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Builders;

public class UpdatePostCommentApiRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<UpdatePostCommentApiRequest> _objectBuilderFactory = new();

    public UpdatePostCommentApiRequestBuilder Create(PostComment postComment)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new UpdatePostCommentApiRequestBuilder(objectBuilder, postComment);

        return requestBuilder;
    }
}
