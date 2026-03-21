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

    public PostBuilder WithId(string id)
    {
        _id = id;

        return this;
    }

    public PostBuilder WithTitle(string title)
    {
        _title = title;

        return this;
    }

    public PostBuilder WithContent(string content)
    {
        _content = content;

        return this;
    }

    public PostBuilder WithUserId(string userId)
    {
        _userId = userId;

        return this;
    }

    public PostBuilder WithCreatedAtUtc(DateTimeOffset createdAtUtc)
    {
        _createdAtUtc = createdAtUtc;

        return this;
    }

    public PostBuilder WithUpdatedAtUtc(DateTimeOffset updatedAtUtc)
    {
        _updatedAtUtc = updatedAtUtc;

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
