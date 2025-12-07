using InstaConnect.Common.Tests.DataAttributes.Base;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Builders;

public class GetPostCommentLikeByIdQueryRequestBuilder
{
    private string _id;
    private string _commentId;
    private string _userId;

    public GetPostCommentLikeByIdQueryRequestBuilder(PostCommentLike postCommentLike)
    {
        _id = postCommentLike.Id.CommentId.Id.Id;
        _commentId = postCommentLike.Id.CommentId.CommentId;
        _userId = postCommentLike.Id.UserId.Id;
    }

    public GetPostCommentLikeByIdQueryRequestBuilder WithId(Post post, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(post.Id.Id);

        return this;
    }

    public GetPostCommentLikeByIdQueryRequestBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public GetPostCommentLikeByIdQueryRequestBuilder WithCommentId(PostComment postComment, IStringTransformer? transformer = null)
    {
        _commentId = transformer.TryTransform(postComment.Id.CommentId);

        return this;
    }

    public GetPostCommentLikeByIdQueryRequestBuilder WithCommentId(IStringTransformer transformer)
    {
        _commentId = transformer.Transform(_commentId);

        return this;
    }

    public GetPostCommentLikeByIdQueryRequestBuilder WithUserId(User user, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(user.Id.Id);

        return this;
    }

    public GetPostCommentLikeByIdQueryRequestBuilder WithUserId(IStringTransformer transformer)
    {
        _userId = transformer.Transform(_userId);

        return this;
    }

    public GetPostCommentLikeByIdQueryRequest Build()
    {
        return new(_id, _commentId, _userId);
    }
}
