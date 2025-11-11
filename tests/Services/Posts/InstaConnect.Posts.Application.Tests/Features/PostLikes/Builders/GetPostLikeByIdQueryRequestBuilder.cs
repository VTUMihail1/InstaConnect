using InstaConnect.Common.Tests.DataAttributes.Base;

namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Builders;

public class GetPostLikeByIdQueryRequestBuilder
{
    private string _id;
    private string _userId;

    public GetPostLikeByIdQueryRequestBuilder(PostLike postLike)
    {
        _id = postLike.Id;
        _userId = postLike.UserId;
    }

    public GetPostLikeByIdQueryRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id);

        return this;
    }

    public GetPostLikeByIdQueryRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(userId);

        return this;
    }

    public GetPostLikeByIdQueryRequest Build()
    {
        return new(_id, _userId);
    }
}
