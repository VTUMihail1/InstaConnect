using InstaConnect.Common.Tests.DataAttributes.Base;

namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Builders;

public class GetPostLikeByIdQueryRequestBuilder
{
    private string _id;
    private string _userId;
    private string _currentUserId;

    public GetPostLikeByIdQueryRequestBuilder(PostLike postLike)
    {
        _id = postLike.Id.Id.Id;
        _userId = postLike.Id.UserId.Id;
        _currentUserId = postLike.Id.UserId.Id;
    }

    public GetPostLikeByIdQueryRequestBuilder WithId(Post post, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(post.Id.Id);

        return this;
    }

    public GetPostLikeByIdQueryRequestBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public GetPostLikeByIdQueryRequestBuilder WithUserId(User user, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(user.Id.Id);

        return this;
    }

    public GetPostLikeByIdQueryRequestBuilder WithUserId(IStringTransformer transformer)
    {
        _userId = transformer.Transform(_userId);

        return this;
    }

    public GetPostLikeByIdQueryRequestBuilder WithCurrentUserId(User user, IStringTransformer? transformer = null)
    {
        _currentUserId = transformer.TryTransform(user.Id.Id);

        return this;
    }

    public GetPostLikeByIdQueryRequestBuilder WithCurrentUserId(IStringTransformer transformer)
    {
        _currentUserId = transformer.Transform(_currentUserId);

        return this;
    }

    public GetPostLikeByIdQueryRequest Build()
    {
        return new(_id, _userId, _currentUserId);
    }
}
