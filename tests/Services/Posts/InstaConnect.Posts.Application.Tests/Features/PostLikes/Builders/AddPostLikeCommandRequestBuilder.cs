using InstaConnect.Common.Tests.DataAttributes.Base;

namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Builders;

public class AddPostLikeCommandRequestBuilder
{
    private string _id;
    private string _userId;

    public AddPostLikeCommandRequestBuilder(Post post, User user)
    {
        _id = post.Id.Id;
        _userId = user.Id.Id;
    }

    public AddPostLikeCommandRequestBuilder WithId(Post post, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(post.Id.Id);

        return this;
    }

    public AddPostLikeCommandRequestBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public AddPostLikeCommandRequestBuilder WithUserId(User user, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(user.Id.Id);

        return this;
    }

    public AddPostLikeCommandRequestBuilder WithUserId(IStringTransformer transformer)
    {
        _userId = transformer.Transform(_userId);

        return this;
    }

    public AddPostLikeCommandRequest Build()
    {
        return new(_id, _userId);
    }
}
