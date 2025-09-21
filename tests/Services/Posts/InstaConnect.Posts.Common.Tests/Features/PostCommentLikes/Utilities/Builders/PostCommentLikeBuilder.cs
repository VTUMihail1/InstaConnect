using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Common.Tests.Utilities.DataAttributes.DateTimeOffsets.Base;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;

namespace InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Builders.AddApiRequest;

public class PostCommentLikeBuilder
{
    private readonly ObjectBuilder<PostCommentLike> _objectBuilder;

    public PostCommentLikeBuilder(ObjectBuilder<PostCommentLike> objectBuilder, Post post, PostComment postComment, User user)
    {
        _objectBuilder = objectBuilder;

        WithId(post.Id);
        WithCommentId(postComment.Id);
        WithUser(user);
        WithCreatedAt(PostCommentLikeDataFaker.GetCreatedAt());
        WithUpdatedAt(PostCommentLikeDataFaker.GetUpdatedAt());
    }

    public PostCommentLikeBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Id, id, transformer);

        return this;
    }

    public PostCommentLikeBuilder WithCommentId(string commentId, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.CommentId, commentId, transformer);

        return this;
    }

    public PostCommentLikeBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.UserId, userId, transformer);

        return this;
    }

    public PostCommentLikeBuilder WithUser(User user)
    {
        _objectBuilder.With(p => p.UserId, user.Id);
        _objectBuilder.With(p => p.User, user);

        return this;
    }

    public PostCommentLikeBuilder WithCreatedAt(DateTimeOffset createdAt, IDateTimeOffsetTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.CreatedAt, createdAt, transformer);

        return this;
    }

    public PostCommentLikeBuilder WithUpdatedAt(DateTimeOffset updatedAt, IDateTimeOffsetTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.UpdatedAt, updatedAt, transformer);

        return this;
    }

    public PostCommentLike Build()
    {
        return _objectBuilder.Build();
    }
}
