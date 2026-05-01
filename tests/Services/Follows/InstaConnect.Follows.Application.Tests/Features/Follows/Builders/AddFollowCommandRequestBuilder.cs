namespace InstaConnect.Follows.Application.Tests.Features.Follows.Builders;

public class AddFollowCommandRequestBuilder
{
	private string _followerId;
	private string _followingId;

	public AddFollowCommandRequestBuilder(User follower, User following)
	{
		_followerId = follower.Id.Id;
		_followingId = following.Id.Id;
	}

	public AddFollowCommandRequestBuilder WithFollowerId(UserId followerId, IStringTransformer? transformer = null)
	{
		_followerId = transformer.TryTransform(followerId.Id);

		return this;
	}

	public AddFollowCommandRequestBuilder WithFollowerId(IStringTransformer transformer)
	{
		_followerId = transformer.Transform(_followerId);

		return this;
	}

	public AddFollowCommandRequestBuilder WithFollowingId(UserId followingId, IStringTransformer? transformer = null)
	{
		_followingId = transformer.TryTransform(followingId.Id);

		return this;
	}

	public AddFollowCommandRequestBuilder WithFollowingId(IStringTransformer transformer)
	{
		_followingId = transformer.Transform(_followingId);

		return this;
	}

	public AddFollowCommandRequest Build()
	{
		return new(_followerId, _followingId);
	}
}
