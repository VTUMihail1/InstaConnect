using InstaConnect.Posts.Data.Features.PostComments.Models.Entitites;
using InstaConnect.Posts.Data.Features.PostLikes.Models.Entitites;
using InstaConnect.Posts.Data.Features.Users.Models.Entitites;
using InstaConnect.Shared.Data.Models.Base;

namespace InstaConnect.Posts.Data.Features.Posts.Models.Entitites;

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
