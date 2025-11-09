namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Builders;

public class GetPostCommentLikeByIdQueryRequestBuilder
{
    private readonly ObjectBuilder<GetPostCommentLikeByIdQueryRequest> _objectBuilder;

    public GetPostCommentLikeByIdQueryRequestBuilder(ObjectBuilder<GetPostCommentLikeByIdQueryRequest> objectBuilder, PostCommentLike postCommentLike)
    {
        _objectBuilder = objectBuilder;

        WithId(postCommentLike.Id);
        WithCommentId(postCommentLike.CommentId);
        WithUserId(postCommentLike.UserId);
    }

    public GetPostCommentLikeByIdQueryRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Id, id, transformer);

        return this;
    }

    public GetPostCommentLikeByIdQueryRequestBuilder WithCommentId(string commentId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.CommentId, commentId, transformer);

        return this;
    }

    public GetPostCommentLikeByIdQueryRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.UserId, userId, transformer);

        return this;
    }

    public GetPostCommentLikeByIdQueryRequest Build()
    {
        return _objectBuilder.Build();
    }
}
