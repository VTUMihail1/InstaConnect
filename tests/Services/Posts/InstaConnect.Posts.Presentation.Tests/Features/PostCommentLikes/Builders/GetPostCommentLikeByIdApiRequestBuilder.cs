namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Builders;

public class GetPostCommentLikeByIdApiRequestBuilder
{
    private readonly ObjectBuilder<GetPostCommentLikeByIdApiRequest> _objectBuilder;

    public GetPostCommentLikeByIdApiRequestBuilder(ObjectBuilder<GetPostCommentLikeByIdApiRequest> objectBuilder, PostCommentLike postCommentLike)
    {
        _objectBuilder = objectBuilder;

        WithId(postCommentLike.Id);
        WithCommentId(postCommentLike.CommentId);
        WithUserId(postCommentLike.UserId);
    }

    public GetPostCommentLikeByIdApiRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Id, id, transformer);

        return this;
    }

    public GetPostCommentLikeByIdApiRequestBuilder WithCommentId(string commentId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.CommentId, commentId, transformer);

        return this;
    }

    public GetPostCommentLikeByIdApiRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.UserId, userId, transformer);

        return this;
    }

    public GetPostCommentLikeByIdApiRequest Build()
    {
        return _objectBuilder.Build();
    }
}
