namespace InstaConnect.Posts.Application.Tests.Features.Posts.Builders;

public class UpdatePostCommandRequestBuilder
{
    private readonly ObjectBuilder<UpdatePostCommandRequest> _objectBuilder;

    public UpdatePostCommandRequestBuilder(ObjectBuilder<UpdatePostCommandRequest> objectBuilder, Post post)
    {
        _objectBuilder = objectBuilder;

        WithId(post.Id);
        WithUserId(post.UserId);
        WithTitle(PostDataFaker.GetTitle());
        WithContent(PostDataFaker.GetContent());
    }

    public UpdatePostCommandRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Id, id);

        return this;
    }

    public UpdatePostCommandRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.UserId, userId);

        return this;
    }

    public UpdatePostCommandRequestBuilder WithTitle(string title, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Title, title);

        return this;
    }

    public UpdatePostCommandRequestBuilder WithContent(string content, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Content, content);

        return this;
    }

    public UpdatePostCommandRequest Build()
    {
        return _objectBuilder.Build();
    }
}
