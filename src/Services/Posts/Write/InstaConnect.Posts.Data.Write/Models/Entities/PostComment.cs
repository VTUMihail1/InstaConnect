using InstaConnect.Shared.Data.Models.Base;

namespace InstaConnect.Posts.Data.Write.Models.Entities;

public class PostComment : BaseEntity
{
    public string UserId { get; set; } = string.Empty;

    public string PostId { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public Post Post { get; set; } = new();

    public ICollection<PostCommentLike> CommentLikes { get; set; } = new List<PostCommentLike>();
}
