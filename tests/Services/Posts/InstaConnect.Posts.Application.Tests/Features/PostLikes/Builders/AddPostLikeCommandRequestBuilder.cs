using InstaConnect.Common.Tests.DataAttributes.Base;

namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Builders;
public class AddPostLikeCommandRequestBuilder
{
    private string _id;
    private string _userId;

    public AddPostLikeCommandRequestBuilder(Post post, User user)
    {
        _id = post.Id;
        _userId = user.Id;
    }

    public AddPostLikeCommandRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id);

        return this;
    }

    public AddPostLikeCommandRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(userId);

        return this;
    }

    public AddPostLikeCommandRequest Build()
    {
        return new(_id, _userId);
    }
}
