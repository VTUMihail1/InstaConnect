namespace InstaConnect.Posts.Application.Tests.Features.Posts.Builders;

public class DeletePostCommandRequestBuilder
{
    private readonly ObjectBuilder<DeletePostCommandRequest> _objectBuilder;

    public DeletePostCommandRequestBuilder(ObjectBuilder<DeletePostCommandRequest> objectBuilder, Post post)
    {
        _objectBuilder = objectBuilder;

        WithId(post.Id);
        WithUserId(post.UserId);
    }

    public DeletePostCommandRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Id, id, transformer);

        return this;
    }

    public DeletePostCommandRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.UserId, userId, transformer);

        return this;
    }

    public DeletePostCommandRequest Build()
    {
        return _objectBuilder.Build();
    }
}
