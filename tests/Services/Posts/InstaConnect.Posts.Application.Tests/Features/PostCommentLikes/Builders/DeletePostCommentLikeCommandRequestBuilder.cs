using InstaConnect.Common.Tests.DataAttributes.Base;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Builders;

public class DeletePostCommentLikeCommandRequestBuilder
{
    private string _id;
    private string _commentId;
    private string _userId;

    public DeletePostCommentLikeCommandRequestBuilder(PostCommentLike postCommentLike)
    {
        _id = postCommentLike.Id.CommentId.Id.Id;
        _commentId = postCommentLike.Id.CommentId.CommentId;
        _userId = postCommentLike.Id.UserId.Id;
    }

    public DeletePostCommentLikeCommandRequestBuilder WithId(Post post, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(post.Id.Id);

        return this;
    }

    public DeletePostCommentLikeCommandRequestBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public DeletePostCommentLikeCommandRequestBuilder WithCommentId(PostComment postComment, IStringTransformer? transformer = null)
    {
        _commentId = transformer.TryTransform(postComment.Id.CommentId);

        return this;
    }

    public DeletePostCommentLikeCommandRequestBuilder WithCommentId(IStringTransformer transformer)
    {
        _commentId = transformer.Transform(_commentId);

        return this;
    }

    public DeletePostCommentLikeCommandRequestBuilder WithUserId(User user, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(user.Id.Id);

        return this;
    }

    public DeletePostCommentLikeCommandRequestBuilder WithUserId(IStringTransformer transformer)
    {
        _userId = transformer.Transform(_userId);

        return this;
    }

    public DeletePostCommentLikeCommandRequest Build()
    {
        return new(_id, _commentId, _userId);
    }
}
