using InstaConnect.Posts.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostComments.Builders;

public class PostCommentBuilder
{
    private readonly ObjectBuilder<PostComment> _objectBuilder;

    public PostCommentBuilder(ObjectBuilder<PostComment> objectBuilder, Post post, User user)
    {
        _objectBuilder = objectBuilder;

        WithId(post.Id);
        WithCommentId(PostCommentDataFaker.GetId());
        WithUser(user);
        WithContent(PostCommentDataFaker.GetContent());
        WithCreatedAt(PostCommentDataFaker.GetCreatedAt());
        WithUpdatedAt(PostCommentDataFaker.GetUpdatedAt());
    }

    public PostCommentBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Id, id, transformer);

        return this;
    }

    public PostCommentBuilder WithCommentId(string commentId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.CommentId, commentId, transformer);

        return this;
    }

    public PostCommentBuilder WithContent(string content, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Content, content, transformer);

        return this;
    }

    public PostCommentBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.UserId, userId, transformer);

        return this;
    }

    public PostCommentBuilder WithUser(User user)
    {
        _objectBuilder.With(p => p.UserId, user.Id);
        _objectBuilder.With(p => p.User, user);

        return this;
    }

    public PostCommentBuilder WithCreatedAt(DateTimeOffset createdAt, IDateTimeOffsetTransformer? transformer = null)
    {
        _objectBuilder.WithDateTimeOffset(p => p.CreatedAt, createdAt, transformer);

        return this;
    }

    public PostCommentBuilder WithUpdatedAt(DateTimeOffset updatedAt, IDateTimeOffsetTransformer? transformer = null)
    {
        _objectBuilder.WithDateTimeOffset(p => p.UpdatedAt, updatedAt, transformer);

        return this;
    }

    public PostComment Build()
    {
        return _objectBuilder.Build();
    }
}
