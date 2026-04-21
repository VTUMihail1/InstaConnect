namespace InstaConnect.Follows.Presentation.Tests.Features.Follows.Builders;

public class DeleteFollowApiRequestBuilder
{
    private string _followerId;
    private string _followingId;

    public DeleteFollowApiRequestBuilder(Follow follow)
    {
        _followerId = follow.Id.FollowerId.Id;
        _followingId = follow.Id.FollowingId.Id;
    }

    public DeleteFollowApiRequestBuilder WithFollowerId(UserId followerId, IStringTransformer? transformer = null)
    {
        _followerId = transformer.TryTransform(followerId.Id);

        return this;
    }

    public DeleteFollowApiRequestBuilder WithFollowerId(IStringTransformer transformer)
    {
        _followerId = transformer.Transform(_followerId);

        return this;
    }

    public DeleteFollowApiRequestBuilder WithFollowingId(UserId followingId, IStringTransformer? transformer = null)
    {
        _followingId = transformer.TryTransform(followingId.Id);

        return this;
    }

    public DeleteFollowApiRequestBuilder WithFollowingId(IStringTransformer transformer)
    {
        _followingId = transformer.Transform(_followingId);

        return this;
    }

    public DeleteFollowApiRequest Build()
    {
        return new(_followerId, _followingId);
    }
}
