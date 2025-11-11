namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Builders;

public class GetPostLikeByIdApiRequestBuilder
{
    private string _id;
    private string _userId;

    public GetPostLikeByIdApiRequestBuilder(PostLike postLike)
    {
        _id = postLike.Id;
        _userId = postLike.UserId;
    }

    public GetPostLikeByIdApiRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id);

        return this;
    }

    public GetPostLikeByIdApiRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(userId);

        return this;
    }

    public GetPostLikeByIdApiRequest Build()
    {
        return new(_id, _userId);
    }
}
