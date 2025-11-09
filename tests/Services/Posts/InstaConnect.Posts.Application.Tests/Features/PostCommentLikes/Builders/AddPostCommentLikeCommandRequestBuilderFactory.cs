namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Builders;

public class AddPostCommentLikeCommandRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<AddPostCommentLikeCommandRequest> _objectBuilderFactory = new();

    public AddPostCommentLikeCommandRequestBuilder Create(Post post, PostComment postComment, User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var addRequest = new AddPostCommentLikeCommandRequestBuilder(objectBuilder, post, postComment, user);

        return addRequest;
    }
}
