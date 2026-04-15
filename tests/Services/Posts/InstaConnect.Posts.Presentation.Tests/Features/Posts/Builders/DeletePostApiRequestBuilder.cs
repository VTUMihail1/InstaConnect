namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Builders;

public class DeletePostApiRequestBuilder
{
    private string _id;
    private string _userId;

    public DeletePostApiRequestBuilder(Post post)
    {
        _id = post.Id.Id;
        _userId = post.UserId.Id;
    }

    public DeletePostApiRequestBuilder WithId(PostId id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id.Id);

        return this;
    }

    public DeletePostApiRequestBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public DeletePostApiRequestBuilder WithUserId(UserId userId, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(userId.Id);

        return this;
    }

    public DeletePostApiRequestBuilder WithUserId(IStringTransformer transformer)
    {
        _userId = transformer.Transform(_userId);

        return this;
    }

    public DeletePostApiRequest Build()
    {
        return new(_id, _userId);
    }
}
