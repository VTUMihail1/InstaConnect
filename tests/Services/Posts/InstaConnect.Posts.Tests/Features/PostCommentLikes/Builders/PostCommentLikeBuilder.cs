using InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Builders;

public class PostCommentLikeBuilder
{
    private string _id;
    private string _commentId;
    private string _userId;
    private User _user;
    private DateTimeOffset _createdAtUtc;

    public PostCommentLikeBuilder(PostComment postComment, User user)
    {
        _id = postComment.Id.Id.Id;
        _commentId = postComment.Id.CommentId;
        _userId = user.Id.Id;
        _user = user;
        _createdAtUtc = PostCommentLikeDataFaker.GetCreatedAtUtc();
    }

    public PostCommentLikeBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public PostCommentLikeBuilder WithCommentId(IStringTransformer transformer)
    {
        _commentId = transformer.Transform(_commentId);

        return this;
    }

    public PostCommentLikeBuilder WithUserId(IStringTransformer transformer)
    {
        _userId = transformer.Transform(_userId);

        return this;
    }

    public PostCommentLikeBuilder WithCreatedAtUtc(IDateTimeOffsetTransformer transformer)
    {
        _createdAtUtc = transformer.Transform(_createdAtUtc);

        return this;
    }

    public PostCommentLike Build()
    {
        var postCommentLike = new PostCommentLike(
                new(
                    new(
                        new(_id),
                        _commentId),
                    new(_userId)),
                _createdAtUtc);

        postCommentLike.AddUser(_user);

        return postCommentLike;
    }
}
