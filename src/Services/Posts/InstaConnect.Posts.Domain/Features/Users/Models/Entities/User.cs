namespace InstaConnect.Posts.Domain.Features.Users.Models.Entities;

public class User : IEntity<UserId>
{
    private readonly IList<Post> _posts;
    private readonly IList<PostLike> _postLikes;
    private readonly IList<PostComment> _postComments;
    private readonly IList<PostCommentLike> _postCommentLikes;

    private User()
    {
        Id = new(string.Empty);
        FirstName = string.Empty;
        LastName = string.Empty;
        Email = new(string.Empty);
        Name = new(string.Empty);
        _posts = [];
        _postLikes = [];
        _postComments = [];
        _postCommentLikes = [];
    }

    public User(
        UserId id,
        string firstName,
        string lastName,
        Email email,
        Name name,
        Image? profileImage,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Name = name;
        ProfileImage = profileImage;
        _posts = [];
        _postLikes = [];
        _postComments = [];
        _postCommentLikes = [];
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public User(
        UserId id,
        string firstName,
        string lastName,
        Email email,
        Name name,
        Image? profileImage,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt,
        IList<Post> posts,
        IList<PostLike> postLikes,
        IList<PostComment> postComments,
        IList<PostCommentLike> postCommentLikes)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Name = name;
        ProfileImage = profileImage;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        _posts = posts;
        _postLikes = postLikes;
        _postComments = postComments;
        _postCommentLikes = postCommentLikes;
    }

    public UserId Id { get; }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public Email Email { get; private set; }

    public Name Name { get; private set; }

    public Image? ProfileImage { get; private set; }

    public IReadOnlyCollection<Post> Posts => _posts.AsReadOnly();

    public IReadOnlyCollection<PostLike> PostLikes => _postLikes.AsReadOnly();

    public IReadOnlyCollection<PostComment> PostComments => _postComments.AsReadOnly();

    public IReadOnlyCollection<PostCommentLike> PostCommentLikes => _postCommentLikes.AsReadOnly();

    public DateTimeOffset CreatedAt { get; }

    public DateTimeOffset UpdatedAt { get; private set; }

    public void Update(
        Email email,
        string firstName,
        string lastName,
        Name name,
        Image? profileImage,
        DateTimeOffset updatedAt)
    {
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        Name = name;
        ProfileImage = profileImage;
        UpdatedAt = updatedAt;
    }

    public void AddPost(Post post)
    {
        _posts.Add(post);
    }

    public void AddPostLike(PostLike postLike)
    {
        _postLikes.Add(postLike);
    }

    public void AddPostComment(PostComment postComment)
    {
        _postComments.Add(postComment);
    }

    public void AddPostCommentLike(PostCommentLike postCommentLike)
    {
        _postCommentLikes.Add(postCommentLike);
    }
}


