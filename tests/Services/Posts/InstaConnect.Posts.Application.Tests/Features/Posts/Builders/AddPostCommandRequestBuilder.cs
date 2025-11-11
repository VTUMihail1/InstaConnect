using InstaConnect.Common.Tests.DataAttributes.Base;

namespace InstaConnect.Posts.Application.Tests.Features.Posts.Builders;
public class AddPostCommandRequestBuilder
{
    private string _userId;
    private string _title;
    private string _content;

    public AddPostCommandRequestBuilder(User user)
    {
        _userId = user.Id;
        _title = PostDataFaker.GetTitle();
        _content = PostDataFaker.GetContent();
    }

    public AddPostCommandRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(userId);

        return this;
    }

    public AddPostCommandRequestBuilder WithTitle(string title, IStringTransformer? transformer = null)
    {
        _title = transformer.TryTransform(title);

        return this;
    }

    public AddPostCommandRequestBuilder WithContent(string content, IStringTransformer? transformer = null)
    {
        _content = transformer.TryTransform(content);

        return this;
    }

    public AddPostCommandRequest Build()
    {
        return new(_userId, _title, _content);
    }
}
