using InstaConnect.Shared.Data.Models.Base;

namespace InstaConnect.Posts.Read.Data.Models.Entities;

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


