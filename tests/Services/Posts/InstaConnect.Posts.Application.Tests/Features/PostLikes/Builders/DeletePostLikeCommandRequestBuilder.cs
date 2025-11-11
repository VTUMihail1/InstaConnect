using InstaConnect.Common.Tests.DataAttributes.Base;

namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Builders;

public class DeletePostLikeCommandRequestBuilder
{
    private string _id;
    private string _userId;

    public DeletePostLikeCommandRequestBuilder(PostLike postLike)
    {
        _id = postLike.Id;
        _userId = postLike.UserId;
    }

    public DeletePostLikeCommandRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id);

        return this;
    }

    public DeletePostLikeCommandRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(userId);

        return this;
    }

    public DeletePostLikeCommandRequest Build()
    {
        return new(_id, _userId);
    }
}
