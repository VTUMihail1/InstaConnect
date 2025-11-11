using InstaConnect.Common.Tests.DataAttributes.Base;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Builders;

public class DeletePostCommentCommandRequestBuilder
{
    private string _id;
    private string _commentId;
    private string _userId;

    public DeletePostCommentCommandRequestBuilder(PostComment postComment)
    {
        _id = postComment.Id;
        _commentId = postComment.CommentId;
        _userId = postComment.UserId;
    }

    public DeletePostCommentCommandRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id);

        return this;
    }

    public DeletePostCommentCommandRequestBuilder WithCommentId(string commentId, IStringTransformer? transformer = null)
    {
        _commentId = transformer.TryTransform(commentId);

        return this;
    }

    public DeletePostCommentCommandRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(userId);

        return this;
    }

    public DeletePostCommentCommandRequest Build()
    {
        return new(_id, _commentId, _userId);
    }
}
