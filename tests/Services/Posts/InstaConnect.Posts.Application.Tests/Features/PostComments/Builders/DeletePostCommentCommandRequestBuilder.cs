using InstaConnect.Common.Tests.DataAttributes.Base;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Builders;

public class DeletePostCommentCommandRequestBuilder
{
    private string _id;
    private string _commentId;
    private string _userId;

    public DeletePostCommentCommandRequestBuilder(PostComment postComment)
    {
        _id = postComment.Id.Id.Id;
        _commentId = postComment.Id.CommentId;
        _userId = postComment.UserId.Id;
    }

    public DeletePostCommentCommandRequestBuilder WithId(Post post, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(post.Id.Id);

        return this;
    }

    public DeletePostCommentCommandRequestBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public DeletePostCommentCommandRequestBuilder WithCommentId(PostComment postComment, IStringTransformer? transformer = null)
    {
        _commentId = transformer.TryTransform(postComment.Id.CommentId);

        return this;
    }

    public DeletePostCommentCommandRequestBuilder WithCommentId(IStringTransformer transformer)
    {
        _commentId = transformer.Transform(_commentId);

        return this;
    }

    public DeletePostCommentCommandRequestBuilder WithUserId(User user, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(user.Id.Id);

        return this;
    }

    public DeletePostCommentCommandRequestBuilder WithUserId(IStringTransformer transformer)
    {
        _userId = transformer.Transform(_userId);

        return this;
    }

    public DeletePostCommentCommandRequest Build()
    {
        return new(_id, _commentId, _userId);
    }
}
