using InstaConnect.Posts.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostComments.Builders;

public class PostCommentBuilder
{
    private string _id;
    private string _commentId;
    private string _content;
    private string _userId;
    private User _user;
    private DateTimeOffset _createdAtUtc;
    private DateTimeOffset _updatedAtUtc;

    public PostCommentBuilder(Post post, User user)
    {
        _id = post.Id.Id;
        _commentId = PostCommentDataFaker.GetId();
        _userId = user.Id.Id;
        _user = user;
        _content = PostCommentDataFaker.GetContent();
        _createdAtUtc = PostCommentDataFaker.GetCreatedAtUtc();
        _updatedAtUtc = PostCommentDataFaker.GetUpdatedAtUtc();
    }

    public PostCommentBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public PostCommentBuilder WithCommentId(IStringTransformer transformer)
    {
        _commentId = transformer.Transform(_commentId);

        return this;
    }

    public PostCommentBuilder WithContent(IStringTransformer transformer)
    {
        _content = transformer.Transform(_content);

        return this;
    }

    public PostCommentBuilder WithUserId(IStringTransformer transformer)
    {
        _userId = transformer.Transform(_userId);

        return this;
    }

    public PostCommentBuilder WithCreatedAtUtc(IDateTimeOffsetTransformer transformer)
    {
        _createdAtUtc = transformer.Transform(_createdAtUtc);

        return this;
    }

    public PostCommentBuilder WithUpdatedAtUtc(IDateTimeOffsetTransformer transformer)
    {
        _updatedAtUtc = transformer.Transform(_updatedAtUtc);

        return this;
    }

    public PostComment Build()
    {
        var postComment = new PostComment(
                new(
                    new(_id),
                    _commentId),
                _content,
                new(_userId),
                _createdAtUtc,
                _updatedAtUtc);

        postComment.AddUser(_user);

        return postComment;
    }
}
