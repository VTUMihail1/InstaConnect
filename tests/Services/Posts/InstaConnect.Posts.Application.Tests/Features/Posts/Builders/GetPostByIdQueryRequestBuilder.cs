using InstaConnect.Common.Tests.DataAttributes.Base;

namespace InstaConnect.Posts.Application.Tests.Features.Posts.Builders;

public class GetPostByIdQueryRequestBuilder
{
    private string _id;
    private string _currentUserId;

    public GetPostByIdQueryRequestBuilder(Post post)
    {
        _id = post.Id.Id;
        _currentUserId = post.UserId.Id;
    }

    public GetPostByIdQueryRequestBuilder WithId(Post post, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(post.Id.Id);

        return this;
    }

    public GetPostByIdQueryRequestBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public GetPostByIdQueryRequestBuilder WithCurrentUserId(User user, IStringTransformer? transformer = null)
    {
        _currentUserId = transformer.TryTransform(user.Id.Id);

        return this;
    }

    public GetPostByIdQueryRequestBuilder WithCurrentUserId(IStringTransformer transformer)
    {
        _currentUserId = transformer.Transform(_currentUserId);

        return this;
    }

    public GetPostByIdQueryRequest Build()
    {
        return new(_id, _currentUserId);
    }
}
