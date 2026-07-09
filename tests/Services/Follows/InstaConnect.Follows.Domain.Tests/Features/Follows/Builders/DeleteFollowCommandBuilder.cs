namespace InstaConnect.Follows.Domain.Tests.Features.Follows.Builders;

public class DeleteFollowCommandBuilder
{
	private string _followerId;
	private string _followingId;

	public DeleteFollowCommandBuilder(Follow follow)
	{
		_followerId = follow.Id.FollowerId.Id;
		_followingId = follow.Id.FollowingId.Id;
	}

	public DeleteFollowCommandBuilder WithFollowerId(UserId followerId, IStringTransformer? transformer = null)
	{
		_followerId = transformer.TryTransform(followerId.Id);

		return this;
	}

	public DeleteFollowCommandBuilder WithFollowerId(IStringTransformer transformer)
	{
		_followerId = transformer.Transform(_followerId);

		return this;
	}

	public DeleteFollowCommandBuilder WithFollowingId(UserId followingId, IStringTransformer? transformer = null)
	{
		_followingId = transformer.TryTransform(followingId.Id);

		return this;
	}

	public DeleteFollowCommandBuilder WithFollowingId(IStringTransformer transformer)
	{
		_followingId = transformer.Transform(_followingId);

		return this;
	}

	public DeleteFollowCommand Build()
	{
		return new(
			new(
				new(_followerId),
				new(_followingId)));
	}
}
