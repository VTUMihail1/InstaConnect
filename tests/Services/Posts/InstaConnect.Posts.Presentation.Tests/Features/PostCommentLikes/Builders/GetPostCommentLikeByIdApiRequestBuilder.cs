namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Builders;

public class GetPostCommentLikeByIdApiRequestBuilder
{
    private string _id;
    private string _commentId;
    private string _userId;

    public GetPostCommentLikeByIdApiRequestBuilder(PostCommentLike postCommentLike)
    {
        _id = postCommentLike.Id;
        _commentId = postCommentLike.CommentId;
        _userId = postCommentLike.UserId;
    }

    public GetPostCommentLikeByIdApiRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id);

        return this;
    }

    public GetPostCommentLikeByIdApiRequestBuilder WithCommentId(string commentId, IStringTransformer? transformer = null)
    {
        _commentId = transformer.TryTransform(commentId);

        return this;
    }

    public GetPostCommentLikeByIdApiRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(userId);

        return this;
    }

    public GetPostCommentLikeByIdApiRequest Build()
    {
        return new(_id, _commentId, _userId);
    }
}
