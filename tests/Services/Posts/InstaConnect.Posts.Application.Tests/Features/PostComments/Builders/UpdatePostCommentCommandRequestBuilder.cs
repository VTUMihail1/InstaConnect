using InstaConnect.Common.Tests.DataAttributes.Base;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Builders;

public class UpdatePostCommentCommandRequestBuilder
{
    private string _id;
    private string _commentId;
    private string _userId;
    private string _content;

    public UpdatePostCommentCommandRequestBuilder(PostComment postComment)
    {
        _id = postComment.Id;
        _commentId = postComment.CommentId;
        _userId = postComment.UserId;
        _content = PostCommentDataFaker.GetContent();
    }

    public UpdatePostCommentCommandRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id);

        return this;
    }

    public UpdatePostCommentCommandRequestBuilder WithCommentId(string commentId, IStringTransformer? transformer = null)
    {
        _commentId = transformer.TryTransform(commentId);

        return this;
    }

    public UpdatePostCommentCommandRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(userId);

        return this;
    }

    public UpdatePostCommentCommandRequestBuilder WithContent(string content, IStringTransformer? transformer = null)
    {
        _content = transformer.TryTransform(content);

        return this;
    }

    public UpdatePostCommentCommandRequest Build()
    {
        return new(_id, _commentId, _userId, _content);
    }
}
