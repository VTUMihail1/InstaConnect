namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Builders;

public class GetPostCommentByIdApiRequestBuilder
{
    private readonly ObjectBuilder<GetPostCommentByIdApiRequest> _objectBuilder;

    public GetPostCommentByIdApiRequestBuilder(ObjectBuilder<GetPostCommentByIdApiRequest> objectBuilder, PostComment postComment)
    {
        _objectBuilder = objectBuilder;

        WithId(postComment.Id);
        WithCommentId(postComment.CommentId);
    }

    public GetPostCommentByIdApiRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Id, id, transformer);

        return this;
    }

    public GetPostCommentByIdApiRequestBuilder WithCommentId(string commentId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.CommentId, commentId, transformer);

        return this;
    }

    public GetPostCommentByIdApiRequest Build()
    {
        return _objectBuilder.Build();
    }
}
