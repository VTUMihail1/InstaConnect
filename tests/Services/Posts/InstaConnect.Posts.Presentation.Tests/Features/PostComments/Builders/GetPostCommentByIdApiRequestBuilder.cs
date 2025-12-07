namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Builders;

public class GetPostCommentByIdApiRequestBuilder
{
    private string _id;
    private string _commentId;

    public GetPostCommentByIdApiRequestBuilder(PostComment postComment)
    {
        _id = postComment.Id.Id.Id;
        _commentId = postComment.Id.CommentId;
    }

    public GetPostCommentByIdApiRequestBuilder WithId(Post post, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(post.Id.Id);

        return this;
    }

    public GetPostCommentByIdApiRequestBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public GetPostCommentByIdApiRequestBuilder WithCommentId(PostComment postComment, IStringTransformer? transformer = null)
    {
        _commentId = transformer.TryTransform(postComment.Id.CommentId);

        return this;
    }

    public GetPostCommentByIdApiRequestBuilder WithCommentId(IStringTransformer transformer)
    {
        _commentId = transformer.Transform(_commentId);

        return this;
    }

    public GetPostCommentByIdApiRequest Build()
    {
        return new(_id, _commentId);
    }
}
