using InstaConnect.Posts.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostComments.Builders;

public class PostCommentBuilder
{
    private string _id;
    private Post _post;
    private string _content;
    private string _commentId;
    private string _userId;
    private User _user;
    private DateTimeOffset _createdAtUtc;
    private DateTimeOffset _updatedAtUtc;

    public PostCommentBuilder(Post post, User user)
    {
        _id = post.Id.Id;
        _post = post;
        _commentId = PostCommentDataFaker.GetId();
        _userId = user.Id.Id;
        _user = user;
        _content = PostCommentDataFaker.GetContent();
        _createdAtUtc = PostCommentDataFaker.GetCreatedAtUtc();
        _updatedAtUtc = PostCommentDataFaker.GetUpdatedAtUtc();
    }

    public PostComment Build()
    {
        var postComment = new PostComment(
                new(
                    new(_id),
                    _commentId),
                _content,
                new(_userId),
                _createdAtUtc,
                _updatedAtUtc);

        _user.AddPostComment(postComment);
        _post.AddPostComment(postComment);
        postComment.AddUser(_user);
        postComment.AddPost(_post);

        return postComment;
    }
}
