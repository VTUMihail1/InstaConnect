namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Builders;

public class UpdatePostApiRequestBuilder
{
    private string _id;
    private string _userId;
    private string _title;
    private string _content;

    public UpdatePostApiRequestBuilder(Post post)
    {
        _id = post.Id;
        _userId = post.UserId;
        _title = PostDataFaker.GetTitle();
        _content = PostDataFaker.GetContent();
    }

    public UpdatePostApiRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id);

        return this;
    }

    public UpdatePostApiRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(userId);

        return this;
    }

    public UpdatePostApiRequestBuilder WithTitle(string title, IStringTransformer? transformer = null)
    {
        _title = transformer.TryTransform(title);

        return this;
    }

    public UpdatePostApiRequestBuilder WithContent(string content, IStringTransformer? transformer = null)
    {
        _content = transformer.TryTransform(content);

        return this;
    }

    public UpdatePostApiRequest Build()
    {
        return new(
            _id,
            _userId,
            new(_title, _content)
        );
    }
}
