using InstaConnect.Common.Tests.DataAttributes.Base;

namespace InstaConnect.Posts.Application.Tests.Features.Posts.Builders;

public class DeletePostCommandRequestBuilder
{
    private string _id;
    private string _userId;

    public DeletePostCommandRequestBuilder(Post post)
    {
        _id = post.Id;
        _userId = post.UserId;
    }

    public DeletePostCommandRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id);

        return this;
    }

    public DeletePostCommandRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(userId);

        return this;
    }

    public DeletePostCommandRequest Build()
    {
        return new(_id, _userId);
    }
}
