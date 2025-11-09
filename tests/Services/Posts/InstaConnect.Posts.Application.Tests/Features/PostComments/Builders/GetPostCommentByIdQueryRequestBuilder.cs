namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Builders;

public class GetPostCommentByIdQueryRequestBuilder
{
    private readonly ObjectBuilder<GetPostCommentByIdQueryRequest> _objectBuilder;

    public GetPostCommentByIdQueryRequestBuilder(ObjectBuilder<GetPostCommentByIdQueryRequest> objectBuilder, PostComment postComment)
    {
        _objectBuilder = objectBuilder;

        WithId(postComment.Id);
        WithCommentId(postComment.CommentId);
    }

    public GetPostCommentByIdQueryRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Id, id, transformer);

        return this;
    }

    public GetPostCommentByIdQueryRequestBuilder WithCommentId(string commentId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.CommentId, commentId, transformer);

        return this;
    }

    public GetPostCommentByIdQueryRequest Build()
    {
        return _objectBuilder.Build();
    }
}
