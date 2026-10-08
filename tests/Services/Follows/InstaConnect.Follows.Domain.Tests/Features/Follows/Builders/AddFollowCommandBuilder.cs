namespace InstaConnect.Follows.Domain.Tests.Features.Follows.Builders;

public class AddFollowCommandBuilder
{
	private string _followerId;
	private string _followingId;

	public AddFollowCommandBuilder(User follower, User following)
	{
		_followerId = follower.Id.Id;
		_followingId = following.Id.Id;
	}

	public AddFollowCommandBuilder WithFollowerId(UserId followerId, IStringTransformer? transformer = null)
	{
		_followerId = transformer.TryTransform(followerId.Id);

		return this;
	}

	public AddFollowCommandBuilder WithFollowerId(IStringTransformer transformer)
	{
		_followerId = transformer.Transform(_followerId);

		return this;
	}

	public AddFollowCommandBuilder WithFollowingId(UserId followingId, IStringTransformer? transformer = null)
	{
		_followingId = transformer.TryTransform(followingId.Id);

		return this;
	}

	public AddFollowCommandBuilder WithFollowingId(IStringTransformer transformer)
	{
		_followingId = transformer.Transform(_followingId);

		return this;
	}

	public AddFollowCommand Build()
	{
		return new(
			new(_followerId),
			new(_followingId));
	}
}
