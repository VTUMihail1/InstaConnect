using System.Xml.Linq;

using InstaConnect.Common.Extensions;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;

namespace InstaConnect.Posts.Domain.Features.Users.Models.Entities;

public class User : IEntity
{
    private readonly IList<Post> _posts;
    private readonly IList<PostLike> _postLikes;
    private readonly IList<PostComment> _postComments;
    private readonly IList<PostCommentLike> _postCommentLikes;

    private User()
    {
        Id = string.Empty;
        FirstName = string.Empty;
        LastName = string.Empty;
        Email = string.Empty;
        Name = string.Empty;
        _posts = [];
        _postLikes = [];
        _postComments = [];
        _postCommentLikes = [];
    }

    public User(
        string id,
        string firstName,
        string lastName,
        string email,
        string name,
        string? profileImage,
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
        string id,
        string firstName,
        string lastName,
        string email,
        string name,
        string? profileImage,
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

    public string Id { get; }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string Email { get; private set; }

    public string Name { get; private set; }

    public string? ProfileImage { get; private set; }

    public IReadOnlyCollection<Post> Posts => _posts.AsReadOnly();

    public IReadOnlyCollection<PostLike> PostLikes => _postLikes.AsReadOnly();

    public IReadOnlyCollection<PostComment> PostComments => _postComments.AsReadOnly();

    public IReadOnlyCollection<PostCommentLike> PostCommentLikes => _postCommentLikes.AsReadOnly();

    public DateTimeOffset CreatedAt { get; }

    public DateTimeOffset UpdatedAt { get; private set; }

    public void Update(
        string email,
        string firstName,
        string lastName,
        string name,
        string? profileImage,
        DateTimeOffset updatedAt)
    {
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        Name = name;
        ProfileImage = profileImage;
        UpdatedAt = updatedAt;
    }

    public bool HasEmail(string email)
    {
        var hasEmail = Email.EqualsOrdinalIgnoreCase(email);

        return hasEmail;
    }

    public bool DoesNotHaveEmail(string email)
    {
        var hasEmail = !HasEmail(email);

        return hasEmail;
    }

    public bool HasName(string name)
    {
        var hasName = Name.EqualsOrdinalIgnoreCase(name);

        return hasName;
    }

    public bool DoesNotHaveName(string name)
    {
        var hasName = !HasName(name);

        return hasName;
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


