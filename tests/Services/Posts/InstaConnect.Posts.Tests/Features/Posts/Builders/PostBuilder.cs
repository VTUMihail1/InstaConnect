using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Tests.Features.Posts.Builders;

public class PostBuilder
{
    private string _id;
    private string _title;
    private string _content;
    private string _userId;
    private User _user;
    private DateTimeOffset _createdAtUtc;
    private DateTimeOffset _updatedAtUtc;

    public PostBuilder(User user)
    {
        _id = PostDataFaker.GetId();
        _userId = user.Id.Id;
        _user = user;
        _title = PostDataFaker.GetTitle();
        _content = PostDataFaker.GetContent();
        _createdAtUtc = PostDataFaker.GetCreatedAtUtc();
        _updatedAtUtc = PostDataFaker.GetUpdatedAtUtc();
    }

    public PostBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public PostBuilder WithTitle(IStringTransformer transformer)
    {
        _title = transformer.Transform(_title);

        return this;
    }

    public PostBuilder WithContent(IStringTransformer transformer)
    {
        _content = transformer.Transform(_content);

        return this;
    }

    public PostBuilder WithUserId(IStringTransformer transformer)
    {
        _userId = transformer.Transform(_userId);

        return this;
    }

    public PostBuilder WithCreatedAtUtc(IDateTimeOffsetTransformer transformer)
    {
        _createdAtUtc = transformer.Transform(_createdAtUtc);

        return this;
    }

    public PostBuilder WithUpdatedAtUtc(IDateTimeOffsetTransformer transformer)
    {
        _updatedAtUtc = transformer.Transform(_updatedAtUtc);

        return this;
    }

    public Post Build()
    {
        var post = new Post(
                new(_id),
                _title,
                _content,
                new(_userId),
                _createdAtUtc,
                _updatedAtUtc);

        post.AddUser(_user);
        _user.AddPost(post);

        return post;
    }
}
