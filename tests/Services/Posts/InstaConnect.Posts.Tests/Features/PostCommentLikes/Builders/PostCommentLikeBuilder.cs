using InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Builders;

public class PostCommentLikeBuilder
{
    private string _id;
    private string _commentId;
    private PostComment _postComment;
    private string _userId;
    private User _user;
    private DateTimeOffset _createdAtUtc;

    public PostCommentLikeBuilder(PostComment postComment, User user)
    {
        _id = postComment.Id.Id.Id;
        _commentId = postComment.Id.CommentId;
        _postComment = postComment;
        _userId = user.Id.Id;
        _user = user;
        _createdAtUtc = PostCommentLikeDataFaker.GetCreatedAtUtc();
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

        _user.AddPostCommentLike(postCommentLike);
        _postComment.AddPostCommentLike(postCommentLike);
        postCommentLike.AddUser(_user);
        postCommentLike.AddPostComment(_postComment);

        return postCommentLike;
    }
}
