namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Builders;

public class UpdatePostApiRequestBuilder
{
    private string _id;
    private string _userId;
    private string _title;
    private string _content;

    public UpdatePostApiRequestBuilder(Post post)
    {
        _id = post.Id.Id;
        _userId = post.UserId.Id;
        _title = PostDataFaker.GetTitle();
        _content = PostDataFaker.GetContent();
    }

    public UpdatePostApiRequestBuilder WithId(PostId id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id.Id);

        return this;
    }

    public UpdatePostApiRequestBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public UpdatePostApiRequestBuilder WithUserId(UserId userId, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(userId.Id);

        return this;
    }

    public UpdatePostApiRequestBuilder WithUserId(IStringTransformer transformer)
    {
        _userId = transformer.Transform(_userId);

        return this;
    }

    public UpdatePostApiRequestBuilder WithTitle(IStringTransformer transformer)
    {
        _title = transformer.Transform(_title);

        return this;
    }

    public UpdatePostApiRequestBuilder WithContent(IStringTransformer transformer)
    {
        _content = transformer.Transform(_content);

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
