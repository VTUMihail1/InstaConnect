namespace InstaConnect.Posts.Domain.Tests.Features.Posts.Builders;

public class AddPostCommandBuilder
{
	private string _userId;
	private string _title;
	private string _content;

	public AddPostCommandBuilder(User user)
	{
		_userId = user.Id.Id;
		_title = PostDataFaker.GetTitle();
		_content = PostDataFaker.GetContent();
	}

	public AddPostCommandBuilder WithUserId(UserId userId, IStringTransformer? transformer = null)
	{
		_userId = transformer.TryTransform(userId.Id);

		return this;
	}

	public AddPostCommandBuilder WithUserId(IStringTransformer transformer)
	{
		_userId = transformer.Transform(_userId);

		return this;
	}

	public AddPostCommandBuilder WithTitle(IStringTransformer transformer)
	{
		_title = transformer.Transform(_title);

		return this;
	}

	public AddPostCommandBuilder WithContent(IStringTransformer transformer)
	{
		_content = transformer.Transform(_content);

		return this;
	}

	public AddPostCommand Build()
	{
		return new(
			new(_userId),
			_title,
			_content);
	}
}
