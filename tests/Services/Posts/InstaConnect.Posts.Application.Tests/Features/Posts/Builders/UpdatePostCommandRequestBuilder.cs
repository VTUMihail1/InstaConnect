using InstaConnect.Common.Tests.DataAttributes.Base;

namespace InstaConnect.Posts.Application.Tests.Features.Posts.Builders;

public class UpdatePostCommandRequestBuilder
{
    private string _id;
    private string _userId;
    private string _title;
    private string _content;

    public UpdatePostCommandRequestBuilder(Post post)
    {
        _id = post.Id;
        _userId = post.UserId;
        _title = PostDataFaker.GetTitle();
        _content = PostDataFaker.GetContent();
    }

    public UpdatePostCommandRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id);

        return this;
    }

    public UpdatePostCommandRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(userId);

        return this;
    }

    public UpdatePostCommandRequestBuilder WithTitle(string title, IStringTransformer? transformer = null)
    {
        _title = transformer.TryTransform(title);

        return this;
    }

    public UpdatePostCommandRequestBuilder WithContent(string content, IStringTransformer? transformer = null)
    {
        _content = transformer.TryTransform(content);

        return this;
    }

    public UpdatePostCommandRequest Build()
    {
        return new(_id, _userId, _title, _content);
    }
}
