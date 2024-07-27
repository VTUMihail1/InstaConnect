using InstaConnect.Shared.Data.Models.Base;

namespace InstaConnect.Posts.Read.Data.Models.Entities;

public class Post : BaseEntity
{
    public Post(
        string title, 
        string content,
        string userId)
    {
        Title = title;
        Content = content;
        UserId = userId;
    }

    public string Title { get; set; }

    public string Content { get; set; }

    public string UserId { get; }

    public User? User { get; set; }

    public ICollection<PostLike> PostLikes { get; set; } = [];

    public ICollection<PostComment> PostComments { get; set; } = [];
}
