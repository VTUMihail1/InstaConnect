namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Builders;

public class AddPostApiRequestBuilder
{
    private string _userId;
    private string _title;
    private string _content;

    public AddPostApiRequestBuilder(User user)
    {
        _userId = user.Id;
        _title = PostDataFaker.GetTitle();
        _content = PostDataFaker.GetContent();
    }

    public AddPostApiRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(userId);

        return this;
    }

    public AddPostApiRequestBuilder WithTitle(string title, IStringTransformer? transformer = null)
    {
        _title = transformer.TryTransform(title);

        return this;
    }

    public AddPostApiRequestBuilder WithContent(string content, IStringTransformer? transformer = null)
    {
        _content = transformer.TryTransform(content);

        return this;
    }

    public AddPostApiRequest Build()
    {
        return new(_userId, new(_title, _content));
    }
}
