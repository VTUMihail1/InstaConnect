namespace InstaConnect.Posts.Domain.Tests.Features.Posts.Builders;

public class UpdatePostCommandBuilder
{
	private string _id;
	private string _userId;
	private string _title;
	private string _content;

	public UpdatePostCommandBuilder(Post post)
	{
		_id = post.Id.Id;
		_userId = post.UserId.Id;
		_title = PostDataFaker.GetTitle();
		_content = PostDataFaker.GetContent();
	}

	public UpdatePostCommandBuilder WithId(PostId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public UpdatePostCommandBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public UpdatePostCommandBuilder WithUserId(UserId userId, IStringTransformer? transformer = null)
	{
		_userId = transformer.TryTransform(userId.Id);

		return this;
	}

	public UpdatePostCommandBuilder WithUserId(IStringTransformer transformer)
	{
		_userId = transformer.Transform(_userId);

		return this;
	}

	public UpdatePostCommandBuilder WithTitle(IStringTransformer transformer)
	{
		_title = transformer.Transform(_title);

		return this;
	}

	public UpdatePostCommandBuilder WithContent(IStringTransformer transformer)
	{
		_content = transformer.Transform(_content);

		return this;
	}

	public UpdatePostCommand Build()
	{
		return new(
			new(_id),
			new(_userId),
			_title,
			_content);
	}
}
