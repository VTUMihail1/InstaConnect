namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Builders;

public class DeletePostLikeApiRequestBuilder
{
    private string _id;
    private string _userId;

    public DeletePostLikeApiRequestBuilder(PostLike postLike)
    {
        _id = postLike.Id.Id.Id;
        _userId = postLike.Id.UserId.Id;
    }

    public DeletePostLikeApiRequestBuilder WithId(Post post, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(post.Id.Id);

        return this;
    }

    public DeletePostLikeApiRequestBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public DeletePostLikeApiRequestBuilder WithUserId(User user, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(user.Id.Id);

        return this;
    }

    public DeletePostLikeApiRequestBuilder WithUserId(IStringTransformer transformer)
    {
        _userId = transformer.Transform(_userId);

        return this;
    }

    public DeletePostLikeApiRequest Build()
    {
        return new(_id, _userId);
    }
}
