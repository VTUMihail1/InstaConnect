namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Builders;

public class UpdatePostApiRequestBuilder
{
    private readonly ObjectBuilder<UpdatePostApiRequest> _objectBuilder;

    public UpdatePostApiRequestBuilder(ObjectBuilder<UpdatePostApiRequest> objectBuilder, Post post)
    {
        _objectBuilder = objectBuilder;

        WithId(post.Id);
        WithUserId(post.UserId);
        WithTitle(PostDataFaker.GetTitle());
        WithContent(PostDataFaker.GetContent());
    }

    public UpdatePostApiRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Id, id, transformer);

        return this;
    }

    public UpdatePostApiRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.UserId, userId, transformer);

        return this;
    }

    public UpdatePostApiRequestBuilder WithTitle(string title, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Body.Title, title, transformer);

        return this;
    }

    public UpdatePostApiRequestBuilder WithContent(string content, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Body.Content, content, transformer);

        return this;
    }

    public UpdatePostApiRequest Build()
    {
        return _objectBuilder.Build();
    }
}
