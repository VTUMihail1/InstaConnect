namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Builders;

public class DeletePostApiRequestBuilder
{
    private readonly ObjectBuilder<DeletePostApiRequest> _objectBuilder;

    public DeletePostApiRequestBuilder(ObjectBuilder<DeletePostApiRequest> objectBuilder, Post post)
    {
        _objectBuilder = objectBuilder;

        WithId(post.Id);
        WithUserId(post.UserId);
    }

    public DeletePostApiRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Id, id, transformer);

        return this;
    }

    public DeletePostApiRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.UserId, userId, transformer);

        return this;
    }

    public DeletePostApiRequest Build()
    {
        return _objectBuilder.Build();
    }
}
