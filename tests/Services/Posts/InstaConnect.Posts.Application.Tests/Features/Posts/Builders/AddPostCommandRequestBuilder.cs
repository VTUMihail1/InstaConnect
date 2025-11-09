namespace InstaConnect.Posts.Application.Tests.Features.Posts.Builders;
public class AddPostCommandRequestBuilder
{
    private readonly ObjectBuilder<AddPostCommandRequest> _objectBuilder;

    public AddPostCommandRequestBuilder(ObjectBuilder<AddPostCommandRequest> objectBuilder, User user)
    {
        _objectBuilder = objectBuilder;

        WithUserId(user.Id);
        WithTitle(PostDataFaker.GetTitle());
        WithContent(PostDataFaker.GetContent());
    }

    public AddPostCommandRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.UserId, userId, transformer);

        return this;
    }

    public AddPostCommandRequestBuilder WithTitle(string title, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Title, title, transformer);

        return this;
    }

    public AddPostCommandRequestBuilder WithContent(string content, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Content, content, transformer);

        return this;
    }

    public AddPostCommandRequest Build()
    {
        return _objectBuilder.Build();
    }
}
