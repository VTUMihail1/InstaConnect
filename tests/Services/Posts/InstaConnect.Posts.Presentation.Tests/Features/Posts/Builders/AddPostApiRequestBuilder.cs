namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Builders;

public class AddPostApiRequestBuilder
{
    private readonly ObjectBuilder<AddPostApiRequest> _objectBuilder;

    public AddPostApiRequestBuilder(ObjectBuilder<AddPostApiRequest> objectBuilder, User user)
    {
        _objectBuilder = objectBuilder;

        WithUserId(user.Id);
        WithTitle(PostDataFaker.GetTitle());
        WithContent(PostDataFaker.GetContent());
    }

    public AddPostApiRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.UserId, userId, transformer);

        return this;
    }

    public AddPostApiRequestBuilder WithTitle(string title, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Body.Title, title, transformer);

        return this;
    }

    public AddPostApiRequestBuilder WithContent(string content, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Body.Content, content, transformer);

        return this;
    }

    public AddPostApiRequest Build()
    {
        return _objectBuilder.Build();
    }
}
