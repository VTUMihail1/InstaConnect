namespace InstaConnect.Posts.Domain.Tests.Features.PostLikes.Builders;

public class DeletePostLikeCommandBuilder
{
	private string _id;
	private string _userId;

	public DeletePostLikeCommandBuilder(PostLike postLike)
	{
		_id = postLike.Id.Id.Id;
		_userId = postLike.Id.UserId.Id;
	}

	public DeletePostLikeCommandBuilder WithId(PostId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public DeletePostLikeCommandBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public DeletePostLikeCommandBuilder WithUserId(UserId userId, IStringTransformer? transformer = null)
	{
		_userId = transformer.TryTransform(userId.Id);

		return this;
	}

	public DeletePostLikeCommandBuilder WithUserId(IStringTransformer transformer)
	{
		_userId = transformer.Transform(_userId);

		return this;
	}

	public DeletePostLikeCommand Build()
	{
		return new(
			new(
				new(_id),
				new(_userId)));
	}
}
