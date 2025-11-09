namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Builders;

public class AddPostCommentCommandRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<AddPostCommentCommandRequest> _objectBuilderFactory = new();

    public AddPostCommentCommandRequestBuilder Create(Post post, User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var addRequest = new AddPostCommentCommandRequestBuilder(objectBuilder, post, user);

        return addRequest;
    }
}
