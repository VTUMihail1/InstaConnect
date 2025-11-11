using InstaConnect.Common.Tests.DataAttributes.Base;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Builders;

public class GetPostCommentLikeByIdQueryRequestBuilder
{
    private string _id;
    private string _commentId;
    private string _userId;

    public GetPostCommentLikeByIdQueryRequestBuilder(PostCommentLike postCommentLike)
    {
        _id = postCommentLike.Id;
        _commentId = postCommentLike.CommentId;
        _userId = postCommentLike.UserId;
    }

    public GetPostCommentLikeByIdQueryRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id);

        return this;
    }

    public GetPostCommentLikeByIdQueryRequestBuilder WithCommentId(string commentId, IStringTransformer? transformer = null)
    {
        _commentId = transformer.TryTransform(commentId);

        return this;
    }

    public GetPostCommentLikeByIdQueryRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(userId);

        return this;
    }

    public GetPostCommentLikeByIdQueryRequest Build()
    {
        return new(_id, _commentId, _userId);
    }
}
