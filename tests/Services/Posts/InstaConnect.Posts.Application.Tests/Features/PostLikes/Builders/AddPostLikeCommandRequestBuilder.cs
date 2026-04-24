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

    public AddPostLikeCommandRequestBuilder WithId(PostId id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id.Id);

        return this;
    }

    public AddPostLikeCommandRequestBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public AddPostLikeCommandRequestBuilder WithUserId(UserId userId, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(userId.Id);

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
