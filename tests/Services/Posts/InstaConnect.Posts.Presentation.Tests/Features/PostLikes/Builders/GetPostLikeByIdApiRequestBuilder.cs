namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Builders;

public class GetPostLikeByIdApiRequestBuilder
{
    private string _id;
    private string _userId;
    private string _currentUserId;

    public GetPostLikeByIdApiRequestBuilder(PostLike postLike)
    {
        _id = postLike.Id.Id.Id;
        _userId = postLike.Id.UserId.Id;
        _currentUserId = postLike.Id.UserId.Id;
    }

    public GetPostLikeByIdApiRequestBuilder WithId(Post post, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(post.Id.Id);

        return this;
    }

    public GetPostLikeByIdApiRequestBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public GetPostLikeByIdApiRequestBuilder WithUserId(User user, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(user.Id.Id);

        return this;
    }

    public GetPostLikeByIdApiRequestBuilder WithUserId(IStringTransformer transformer)
    {
        _userId = transformer.Transform(_userId);

        return this;
    }

    public GetPostLikeByIdApiRequestBuilder WithCurrentUserId(User user, IStringTransformer? transformer = null)
    {
        _currentUserId = transformer.TryTransform(user.Id.Id);

        return this;
    }

    public GetPostLikeByIdApiRequestBuilder WithCurrentUserId(IStringTransformer transformer)
    {
        _currentUserId = transformer.Transform(_currentUserId);

        return this;
    }

    public GetPostLikeByIdApiRequest Build()
    {
        return new(_id, _userId, _currentUserId);
    }
}
