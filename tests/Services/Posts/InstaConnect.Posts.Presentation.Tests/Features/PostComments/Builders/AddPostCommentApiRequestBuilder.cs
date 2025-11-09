namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Builders;

public class AddPostCommentApiRequestBuilder
{
    private readonly ObjectBuilder<AddPostCommentApiRequest> _objectBuilder;

    public AddPostCommentApiRequestBuilder(ObjectBuilder<AddPostCommentApiRequest> objectBuilder, Post post, User user)
    {
        _objectBuilder = objectBuilder;

        WithId(post.Id);
        WithUserId(user.Id);
        WithContent(PostCommentDataFaker.GetContent());
    }

    public AddPostCommentApiRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Id, id, transformer);

        return this;
    }

    public AddPostCommentApiRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.UserId, userId, transformer);

        return this;
    }

    public AddPostCommentApiRequestBuilder WithContent(string content, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Body.Content, content, transformer);

        return this;
    }

    public AddPostCommentApiRequest Build()
    {
        return _objectBuilder.Build();
    }
}
