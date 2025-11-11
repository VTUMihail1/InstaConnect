namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Builders;

public class DeletePostLikeApiRequestBuilder
{
    private string _id;
    private string _userId;

    public DeletePostLikeApiRequestBuilder(PostLike postLike)
    {
        _id = postLike.Id;
        _userId = postLike.UserId;
    }

    public DeletePostLikeApiRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id);

        return this;
    }

    public DeletePostLikeApiRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(userId);

        return this;
    }

    public DeletePostLikeApiRequest Build()
    {
        return new(_id, _userId);
    }
}
