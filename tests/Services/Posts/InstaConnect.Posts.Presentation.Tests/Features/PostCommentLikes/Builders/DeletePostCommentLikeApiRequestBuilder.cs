namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Builders;

public class DeletePostCommentLikeApiRequestBuilder
{
    private readonly ObjectBuilder<DeletePostCommentLikeApiRequest> _objectBuilder;

    public DeletePostCommentLikeApiRequestBuilder(ObjectBuilder<DeletePostCommentLikeApiRequest> objectBuilder, PostCommentLike postCommentLike)
    {
        _objectBuilder = objectBuilder;

        WithId(postCommentLike.Id);
        WithCommentId(postCommentLike.CommentId);
        WithUserId(postCommentLike.UserId);
    }

    public DeletePostCommentLikeApiRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Id, id, transformer);

        return this;
    }

    public DeletePostCommentLikeApiRequestBuilder WithCommentId(string commentId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.CommentId, commentId, transformer);

        return this;
    }

    public DeletePostCommentLikeApiRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.UserId, userId, transformer);

        return this;
    }

    public DeletePostCommentLikeApiRequest Build()
    {
        return _objectBuilder.Build();
    }
}
