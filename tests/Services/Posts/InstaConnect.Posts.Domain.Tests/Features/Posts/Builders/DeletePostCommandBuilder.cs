namespace InstaConnect.Posts.Domain.Tests.Features.Posts.Builders;

public class DeletePostCommandBuilder
{
	private string _id;
	private string _userId;

	public DeletePostCommandBuilder(Post post)
	{
		_id = post.Id.Id;
		_userId = post.UserId.Id;
	}

	public DeletePostCommandBuilder WithId(PostId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public DeletePostCommandBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public DeletePostCommandBuilder WithUserId(UserId userId, IStringTransformer? transformer = null)
	{
		_userId = transformer.TryTransform(userId.Id);

		return this;
	}

	public DeletePostCommandBuilder WithUserId(IStringTransformer transformer)
	{
		_userId = transformer.Transform(_userId);

		return this;
	}

	public DeletePostCommand Build()
	{
		return new(
			new(_id),
			new(_userId));
	}
}
