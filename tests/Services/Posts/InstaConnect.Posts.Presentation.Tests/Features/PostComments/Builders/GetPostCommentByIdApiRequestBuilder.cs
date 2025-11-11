namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Builders;

public class GetPostCommentByIdApiRequestBuilder
{
    private string _id;
    private string _commentId;

    public GetPostCommentByIdApiRequestBuilder(PostComment postComment)
    {
        _id = postComment.Id;
        _commentId = postComment.CommentId;
    }

    public GetPostCommentByIdApiRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id);

        return this;
    }

    public GetPostCommentByIdApiRequestBuilder WithCommentId(string commentId, IStringTransformer? transformer = null)
    {
        _commentId = transformer.TryTransform(commentId);

        return this;
    }

    public GetPostCommentByIdApiRequest Build()
    {
        return new(_id, _commentId);
    }
}
