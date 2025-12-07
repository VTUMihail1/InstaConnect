using InstaConnect.Common.Tests.DataAttributes.Base;

namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Builders;

public class DeletePostLikeCommandRequestBuilder
{
    private string _id;
    private string _userId;

    public DeletePostLikeCommandRequestBuilder(PostLike postLike)
    {
        _id = postLike.Id.Id.Id;
        _userId = postLike.Id.UserId.Id;
    }

    public DeletePostLikeCommandRequestBuilder WithId(Post post, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(post.Id.Id);

        return this;
    }

    public DeletePostLikeCommandRequestBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public DeletePostLikeCommandRequestBuilder WithUserId(User user, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(user.Id.Id);

        return this;
    }

    public DeletePostLikeCommandRequestBuilder WithUserId(IStringTransformer transformer)
    {
        _userId = transformer.Transform(_userId);

        return this;
    }

    public DeletePostLikeCommandRequest Build()
    {
        return new(_id, _userId);
    }
}
