using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Common.Tests.Utilities.DataAttributes.DateTimeOffsets.Base;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.AddApiRequest;

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
        _objectBuilder.With(p => p.Id, id, transformer);

        return this;
    }

    public PostCommentBuilder WithCommentId(string commentId, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.CommentId, commentId, transformer);

        return this;
    }

    public PostCommentBuilder WithContent(string content, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Content, content, transformer);

        return this;
    }

    public PostCommentBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.UserId, userId, transformer);

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
        _objectBuilder.With(p => p.CreatedAt, createdAt, transformer);

        return this;
    }

    public PostCommentBuilder WithUpdatedAt(DateTimeOffset updatedAt, IDateTimeOffsetTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.UpdatedAt, updatedAt, transformer);

        return this;
    }

    public PostComment Create()
    {
        return _objectBuilder.Create();
    }
}
