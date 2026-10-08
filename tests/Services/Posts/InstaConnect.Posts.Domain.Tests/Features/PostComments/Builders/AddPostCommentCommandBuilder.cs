namespace InstaConnect.Posts.Domain.Tests.Features.PostComments.Builders;

public class AddPostCommentCommandBuilder
{
	private string _id;
	private string _content;
	private string _userId;

	public AddPostCommentCommandBuilder(Post post, User user)
	{
		_id = post.Id.Id;
		_content = PostCommentDataFaker.GetContent();
		_userId = user.Id.Id;
	}

	public AddPostCommentCommandBuilder WithId(PostId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public AddPostCommentCommandBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public AddPostCommentCommandBuilder WithContent(IStringTransformer transformer)
	{
		_content = transformer.Transform(_content);

		return this;
	}

	public AddPostCommentCommandBuilder WithUserId(UserId userId, IStringTransformer? transformer = null)
	{
		_userId = transformer.TryTransform(userId.Id);

		return this;
	}

	public AddPostCommentCommandBuilder WithUserId(IStringTransformer transformer)
	{
		_userId = transformer.Transform(_userId);

		return this;
	}

	public AddPostCommentCommand Build()
	{
		return new(
			new(_id),
			_content,
			new(_userId));
	}
}
