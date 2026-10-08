namespace InstaConnect.Posts.Domain.Tests.Features.PostLikes.Builders;

public class AddPostLikeCommandBuilder
{
	private string _id;
	private string _userId;

	public AddPostLikeCommandBuilder(Post post, User user)
	{
		_id = post.Id.Id;
		_userId = user.Id.Id;
	}

	public AddPostLikeCommandBuilder WithId(PostId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public AddPostLikeCommandBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public AddPostLikeCommandBuilder WithUserId(UserId userId, IStringTransformer? transformer = null)
	{
		_userId = transformer.TryTransform(userId.Id);

		return this;
	}

	public AddPostLikeCommandBuilder WithUserId(IStringTransformer transformer)
	{
		_userId = transformer.Transform(_userId);

		return this;
	}

	public AddPostLikeCommand Build()
	{
		return new(
			new(_id),
			new(_userId));
	}
}
