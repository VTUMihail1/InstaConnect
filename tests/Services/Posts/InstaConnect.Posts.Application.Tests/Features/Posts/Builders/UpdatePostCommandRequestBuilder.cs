namespace InstaConnect.Posts.Application.Tests.Features.Posts.Builders;

public class UpdatePostCommandRequestBuilder
{
	private string _id;
	private string _userId;
	private string _title;
	private string _content;

	public UpdatePostCommandRequestBuilder(Post post)
	{
		_id = post.Id.Id;
		_userId = post.UserId.Id;
		_title = PostDataFaker.GetTitle();
		_content = PostDataFaker.GetContent();
	}

	public UpdatePostCommandRequestBuilder WithId(PostId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public UpdatePostCommandRequestBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public UpdatePostCommandRequestBuilder WithUserId(UserId userId, IStringTransformer? transformer = null)
	{
		_userId = transformer.TryTransform(userId.Id);

		return this;
	}

	public UpdatePostCommandRequestBuilder WithUserId(IStringTransformer transformer)
	{
		_userId = transformer.Transform(_userId);

		return this;
	}

	public UpdatePostCommandRequestBuilder WithTitle(IStringTransformer transformer)
	{
		_title = transformer.Transform(_title);

		return this;
	}

	public UpdatePostCommandRequestBuilder WithContent(IStringTransformer transformer)
	{
		_content = transformer.Transform(_content);

		return this;
	}

	public UpdatePostCommandRequest Build()
	{
		return new(_id, _userId, _title, _content);
	}
}
