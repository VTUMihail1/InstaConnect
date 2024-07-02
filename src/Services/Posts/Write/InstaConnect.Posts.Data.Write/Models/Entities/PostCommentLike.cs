using InstaConnect.Shared.Data.Models.Base;

namespace InstaConnect.Posts.Data.Write.Models.Entities;

public class PostCommentLike : BaseEntity
{
    public string PostCommentId { get; set; } = string.Empty;

    public string UserId { get; set; } = string.Empty;

    public PostComment PostComment { get; set; } = new();
}
