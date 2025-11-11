using InstaConnect.Common.Tests.DataAttributes.Base;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Builders;

public class PostCommentLikeBuilder
{
    private string _id;
    private string _commentId;
    private string _userId;
    private User? _user;
    private DateTimeOffset _createdAt;
    private DateTimeOffset _updatedAt;

    public PostCommentLikeBuilder(Post post, PostComment postComment, User user)
    {
        _id = post.Id;
        _commentId = postComment.Id;
        _user = user;
        _userId = user.Id;
        _createdAt = PostCommentLikeDataFaker.GetCreatedAt();
        _updatedAt = PostCommentLikeDataFaker.GetUpdatedAt();
    }

    public PostCommentLikeBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id);

        return this;
    }

    public PostCommentLikeBuilder WithCommentId(string commentId, IStringTransformer? transformer = null)
    {
        _commentId = transformer.TryTransform(commentId);

        return this;
    }

    public PostCommentLikeBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        if (userId != _user?.Id)
        {
            _user = null;
        }

        _userId = transformer.TryTransform(userId);

        return this;
    }

    public PostCommentLikeBuilder WithUser(User user)
    {
        _user = user;
        _userId = user.Id;

        return this;
    }

    public PostCommentLikeBuilder WithCreatedAt(DateTimeOffset createdAt, IDateTimeOffsetTransformer? transformer = null)
    {
        _createdAt = transformer.TryTransform(createdAt);

        return this;
    }

    public PostCommentLikeBuilder WithUpdatedAt(DateTimeOffset updatedAt, IDateTimeOffsetTransformer? transformer = null)
    {
        _updatedAt = transformer.TryTransform(updatedAt);

        return this;
    }

    public PostCommentLike Build()
    {
        if (_user == null)
        {
            return new(_id, _commentId, _userId, _createdAt, _updatedAt);
        }

        return new(_id, _commentId, _user, _createdAt, _updatedAt);
    }
}
