namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Builders;

public class AddPostCommentLikeApiRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<AddPostCommentLikeApiRequest> _objectBuilderFactory = new();

    public AddPostCommentLikeApiRequestBuilder Create(Post post, PostComment postComment, User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new AddPostCommentLikeApiRequestBuilder(objectBuilder, post, postComment, user);

        return requestBuilder;
    }
}
