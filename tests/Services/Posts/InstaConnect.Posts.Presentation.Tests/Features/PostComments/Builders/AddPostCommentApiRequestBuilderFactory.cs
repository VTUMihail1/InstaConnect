namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Builders;

public class AddPostCommentApiRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<AddPostCommentApiRequest> _objectBuilderFactory = new();

    public AddPostCommentApiRequestBuilder Create(Post post, User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new AddPostCommentApiRequestBuilder(objectBuilder, post, user);

        return requestBuilder;
    }
}
