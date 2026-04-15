using InstaConnect.Common.Tests.DataAttributes.Base;

namespace InstaConnect.Follows.Application.Tests.Features.Follows.Builders;

public class DeleteFollowCommandRequestBuilder
{
    private string _followerId;
    private string _followingId;

    public DeleteFollowCommandRequestBuilder(Follow follow)
    {
        _followerId = follow.Id.FollowerId.Id;
        _followingId = follow.Id.FollowingId.Id;
    }

    public DeleteFollowCommandRequestBuilder WithFollowerId(UserId followerId, IStringTransformer? transformer = null)
    {
        _followerId = transformer.TryTransform(followerId.Id);

        return this;
    }

    public DeleteFollowCommandRequestBuilder WithFollowerId(IStringTransformer transformer)
    {
        _followerId = transformer.Transform(_followerId);

        return this;
    }

    public DeleteFollowCommandRequestBuilder WithFollowingId(UserId followingId, IStringTransformer? transformer = null)
    {
        _followingId = transformer.TryTransform(followingId.Id);

        return this;
    }

    public DeleteFollowCommandRequestBuilder WithFollowingId(IStringTransformer transformer)
    {
        _followingId = transformer.Transform(_followingId);

        return this;
    }

    public DeleteFollowCommandRequest Build()
    {
        return new(_followerId, _followingId);
    }
}
