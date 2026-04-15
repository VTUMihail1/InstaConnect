using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostLikes.Builders;

public class PostLikeBuilder
{
    private string _id;
    private Post _post;
    private string _userId;
    private User _user;
    private DateTimeOffset _createdAtUtc;

    public PostLikeBuilder(Post post, User user)
    {
        _id = post.Id.Id;
        _post = post;
        _userId = user.Id.Id;
        _user = user;
        _createdAtUtc = PostLikeDataFaker.GetCreatedAtUtc();
    }

    public PostLike Build()
    {
        var postLike = new PostLike(
                new(
                    new(_id),
                    new(_userId)),
                _createdAtUtc);

        _user.AddPostLike(postLike);
        _post.AddPostLike(postLike);
        postLike.AddUser(_user);
        postLike.AddPost(_post);

        return postLike;
    }
}
