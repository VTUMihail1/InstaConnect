using InstaConnect.Shared.Data.Models.Base;

namespace InstaConnect.Posts.Data.Models.Entities;

public class Post : BaseEntity
{
    public string Title { get; set; }

    public string Content { get; set; }

    public string UserId { get; set; }

    public ICollection<PostLike> PostLikes { get; set; } = new List<PostLike>();

    public ICollection<PostComment> PostComments { get; set; } = new List<PostComment>();
}
