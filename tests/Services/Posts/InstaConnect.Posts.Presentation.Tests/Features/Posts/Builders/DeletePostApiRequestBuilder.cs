namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Builders;

public class DeletePostApiRequestBuilder
{
    private string _id;
    private string _userId;

    public DeletePostApiRequestBuilder(Post post)
    {
        _id = post.Id;
        _userId = post.UserId;
    }

    public DeletePostApiRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id);

        return this;
    }

    public DeletePostApiRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(userId);

        return this;
    }

    public DeletePostApiRequest Build()
    {
        return new(_id, _userId);
    }
}
