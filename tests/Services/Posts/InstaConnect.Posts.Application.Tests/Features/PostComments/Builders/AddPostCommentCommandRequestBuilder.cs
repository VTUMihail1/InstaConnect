namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Builders;
public class AddPostCommentCommandRequestBuilder
{
    private readonly ObjectBuilder<AddPostCommentCommandRequest> _objectBuilder;

    public AddPostCommentCommandRequestBuilder(ObjectBuilder<AddPostCommentCommandRequest> objectBuilder, Post post, User user)
    {
        _objectBuilder = objectBuilder;

        WithId(post.Id);
        WithUserId(user.Id);
        WithContent(PostCommentDataFaker.GetContent());
    }

    public AddPostCommentCommandRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Id, id, transformer);

        return this;
    }

    public AddPostCommentCommandRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.UserId, userId, transformer);

        return this;
    }

    public AddPostCommentCommandRequestBuilder WithContent(string content, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Content, content, transformer);

        return this;
    }

    public AddPostCommentCommandRequest Build()
    {
        return _objectBuilder.Build();
    }
}
