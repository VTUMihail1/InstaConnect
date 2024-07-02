using InstaConnect.Messages.Data.Read.Models.Entities;
using InstaConnect.Shared.Data.Models.Base;

namespace InstaConnect.Posts.Data.Read.Models.Entities;

public class PostCommentLike : BaseEntity
{
    public string PostCommentId { get; set; } = string.Empty;

    public string UserId { get; set; } = string.Empty;

    public PostComment PostComment { get; set; } = new();

    public User User { get; set; } = new();
}
