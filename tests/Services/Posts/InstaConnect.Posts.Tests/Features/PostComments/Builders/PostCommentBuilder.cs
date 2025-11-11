using InstaConnect.Common.Tests.DataAttributes.Base;
using InstaConnect.Posts.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostComments.Builders;

public class PostCommentBuilder
{
    private string _id;
    private string _commentId;
    private string _content;
    private string _userId;
    private User? _user;
    private DateTimeOffset _createdAt;
    private DateTimeOffset _updatedAt;

    public PostCommentBuilder(Post post, User user)
    {
        _id = post.Id;
        _commentId = PostCommentDataFaker.GetId();
        _user = user;
        _userId = user.Id;
        _content = PostCommentDataFaker.GetContent();
        _createdAt = PostCommentDataFaker.GetCreatedAt();
        _updatedAt = PostCommentDataFaker.GetUpdatedAt();
    }

    public PostCommentBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id);

        return this;
    }

    public PostCommentBuilder WithCommentId(string commentId, IStringTransformer? transformer = null)
    {
        _commentId = transformer.TryTransform(commentId);

        return this;
    }

    public PostCommentBuilder WithContent(string content, IStringTransformer? transformer = null)
    {
        _content = transformer.TryTransform(content);

        return this;
    }

    public PostCommentBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        if (userId != _user?.Id)
        {
            _user = null;
        }

        _userId = transformer.TryTransform(userId);

        return this;
    }

    public PostCommentBuilder WithUser(User user)
    {
        _user = user;
        _userId = user.Id;

        return this;
    }

    public PostCommentBuilder WithCreatedAt(DateTimeOffset createdAt, IDateTimeOffsetTransformer? transformer = null)
    {
        _createdAt = transformer.TryTransform(createdAt);

        return this;
    }

    public PostCommentBuilder WithUpdatedAt(DateTimeOffset updatedAt, IDateTimeOffsetTransformer? transformer = null)
    {
        _updatedAt = transformer.TryTransform(updatedAt);

        return this;
    }

    public PostComment Build()
    {
        if (_user == null)
        {
            return new(_id, _commentId, _content, _userId, _createdAt, _updatedAt);
        }

        return new(_id, _commentId, _content, _user, _createdAt, _updatedAt);
    }
}
