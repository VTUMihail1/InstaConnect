using InstaConnect.Common.Tests.DataAttributes.Base;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Builders;

public class GetPostCommentByIdQueryRequestBuilder
{
    private string _id;
    private string _commentId;

    public GetPostCommentByIdQueryRequestBuilder(PostComment postComment)
    {
        _id = postComment.Id;
        _commentId = postComment.CommentId;
    }

    public GetPostCommentByIdQueryRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id);

        return this;
    }

    public GetPostCommentByIdQueryRequestBuilder WithCommentId(string commentId, IStringTransformer? transformer = null)
    {
        _commentId = transformer.TryTransform(commentId);

        return this;
    }

    public GetPostCommentByIdQueryRequest Build()
    {
        return new(_id, _commentId);
    }
}
