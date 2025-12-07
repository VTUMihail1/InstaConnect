namespace InstaConnect.Posts.Domain.Features.Users.Models.Entities;

public class User : IEntity<UserId>
{
    private User()
    {
        Id = new(string.Empty);
        FirstName = string.Empty;
        LastName = string.Empty;
        Email = new(string.Empty);
        Name = new(string.Empty);
        Posts = [];
        PostLikes = [];
        PostComments = [];
        PostCommentLikes = [];
    }

    public User(
        UserId id,
        string firstName,
        string lastName,
        Email email,
        Name name,
        Image? profileImage,
        DateTimeOffset createdAtUtc,
        DateTimeOffset updatedAtUtc)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Name = name;
        ProfileImage = profileImage;
        Posts = [];
        PostLikes = [];
        PostComments = [];
        PostCommentLikes = [];
        CreatedAtUtc = createdAtUtc;
        UpdatedAtUtc = updatedAtUtc;
    }

    public UserId Id { get; }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public Email Email { get; private set; }

    public Name Name { get; private set; }

    public Image? ProfileImage { get; private set; }

    public ICollection<Post> Posts { get; }

    public ICollection<PostLike> PostLikes { get; }

    public ICollection<PostComment> PostComments { get; }

    public ICollection<PostCommentLike> PostCommentLikes { get; }

    public DateTimeOffset CreatedAtUtc { get; }

    public DateTimeOffset UpdatedAtUtc { get; private set; }

    public void Update(
        Email email,
        string firstName,
        string lastName,
        Name name,
        Image? profileImage,
        DateTimeOffset updatedAtUtc)
    {
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        Name = name;
        ProfileImage = profileImage;
        UpdatedAtUtc = updatedAtUtc;
    }

    public void AddPost(Post post)
    {
        Posts.Add(post);
    }

    public void AddPostLike(PostLike postLike)
    {
        PostLikes.Add(postLike);
    }

    public void AddPostComment(PostComment postComment)
    {
        PostComments.Add(postComment);
    }

    public void AddPostCommentLike(PostCommentLike postCommentLike)
    {
        PostCommentLikes.Add(postCommentLike);
    }
}


