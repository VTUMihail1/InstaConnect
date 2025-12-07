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

    public DeletePostApiRequestBuilder WithId(Post post, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(post.Id.Id);

        return this;
    }

    public DeletePostApiRequestBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public DeletePostApiRequestBuilder WithUserId(User user, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(user.Id.Id);

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
