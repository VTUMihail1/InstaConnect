using InstaConnect.Common.Tests.DataAttributes.Base;

namespace InstaConnect.Follows.Presentation.Tests.Features.Follows.Builders;

public class AddFollowApiRequestBuilder
{
    private string _followerId;
    private string _followingId;

    public AddFollowApiRequestBuilder(User follower, User following)
    {
        _followerId = follower.Id.Id;
        _followingId = following.Id.Id;
    }

    public AddFollowApiRequestBuilder WithFollowerId(UserId followerId, IStringTransformer? transformer = null)
    {
        _followerId = transformer.TryTransform(followerId.Id);

        return this;
    }

    public AddFollowApiRequestBuilder WithFollowerId(IStringTransformer transformer)
    {
        _followerId = transformer.Transform(_followerId);

        return this;
    }

    public AddFollowApiRequestBuilder WithFollowingId(UserId followingId, IStringTransformer? transformer = null)
    {
        _followingId = transformer.TryTransform(followingId.Id);

        return this;
    }

    public AddFollowApiRequestBuilder WithFollowingId(IStringTransformer transformer)
    {
        _followingId = transformer.Transform(_followingId);

        return this;
    }

    public AddFollowApiRequest Build()
    {
        return new(_followerId, new(_followingId));
    }
}
