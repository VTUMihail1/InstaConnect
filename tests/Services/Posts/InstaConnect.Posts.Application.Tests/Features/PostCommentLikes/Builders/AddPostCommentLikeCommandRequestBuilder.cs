using InstaConnect.Common.Tests.DataAttributes.Base;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Builders;
public class AddPostCommentLikeCommandRequestBuilder
{
    private string _id;
    private string _commentId;
    private string _userId;

    public AddPostCommentLikeCommandRequestBuilder(Post post, PostComment postComment, User user)
    {
        _id = post.Id;
        _commentId = postComment.Id;
        _userId = user.Id;
    }

    public AddPostCommentLikeCommandRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id);

        return this;
    }

    public AddPostCommentLikeCommandRequestBuilder WithCommentId(string commentId, IStringTransformer? transformer = null)
    {
        _commentId = transformer.TryTransform(commentId);

        return this;
    }

    public AddPostCommentLikeCommandRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _userId = transformer.TryTransform(userId);

        return this;
    }

    public AddPostCommentLikeCommandRequest Build()
    {
        return new(_id, _commentId, _userId);
    }
}
