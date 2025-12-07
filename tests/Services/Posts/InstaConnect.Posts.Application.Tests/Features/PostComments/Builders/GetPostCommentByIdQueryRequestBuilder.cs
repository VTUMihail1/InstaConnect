using InstaConnect.Common.Tests.DataAttributes.Base;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Builders;

public class GetPostCommentByIdQueryRequestBuilder
{
    private string _id;
    private string _commentId;

    public GetPostCommentByIdQueryRequestBuilder(PostComment postComment)
    {
        _id = postComment.Id.Id.Id;
        _commentId = postComment.Id.CommentId;
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

    public GetPostCommentByIdQueryRequest Build()
    {
        return new(_id, _commentId);
    }
}
