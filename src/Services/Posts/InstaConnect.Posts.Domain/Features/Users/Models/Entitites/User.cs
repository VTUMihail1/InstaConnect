using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Entitites;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Entitites;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Entitites;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entitites;
using InstaConnect.Shared.Domain.Models.Base;

namespace InstaConnect.Posts.Domain.Features.Users.Models.Entitites;

public class User : BaseEntity
{
    public User(
        string firstName,
        string lastName,
        string email,
        string userName,
        string? profileImage)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        UserName = userName;
        ProfileImage = profileImage;
    }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string UserName { get; set; }

    public string? ProfileImage { get; set; }

    public ICollection<Post> Posts { get; set; } = [];

    public ICollection<PostLike> PostLikes { get; set; } = [];

    public ICollection<PostComment> PostComments { get; set; } = [];

    public ICollection<PostCommentLike> PostCommentLikes { get; set; } = [];
}


