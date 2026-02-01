using InstaConnect.Common.Tests.DataAttributes.Base;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Builders;

public class GetPostCommentByIdQueryRequestBuilder
{
    private string _id;
    private string _commentId;
    private string _currentUserId;

    public GetPostCommentByIdQueryRequestBuilder(PostComment postComment)
    {
        _id = postComment.Id.Id.Id;
        _commentId = postComment.Id.CommentId;
        _currentUserId = DataFaker.GetPrefixString(postComment.UserId.Id);
    }

    public GetPostCommentByIdQueryRequestBuilder WithId(Post post, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(post.Id.Id);

        return this;
    }

    public GetPostCommentByIdQueryRequestBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public GetPostCommentByIdQueryRequestBuilder WithCommentId(PostComment postComment, IStringTransformer? transformer = null)
    {
        _commentId = transformer.TryTransform(postComment.Id.CommentId);

        return this;
    }

    public GetPostCommentByIdQueryRequestBuilder WithCommentId(IStringTransformer transformer)
    {
        _commentId = transformer.Transform(_commentId);

        return this;
    }

    public GetPostCommentByIdQueryRequestBuilder WithCurrentUserId(User user, IStringTransformer? transformer = null)
    {
        _currentUserId = transformer.TryTransform(user.Id.Id);

        return this;
    }

    public GetPostCommentByIdQueryRequestBuilder WithCurrentUserId(IStringTransformer transformer)
    {
        _currentUserId = transformer.Transform(_currentUserId);

        return this;
    }

    public GetPostCommentByIdQueryRequest Build()
    {
        return new(_id, _commentId, _currentUserId);
    }
}
