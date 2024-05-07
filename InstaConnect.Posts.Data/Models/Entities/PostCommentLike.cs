using InstaConnect.Shared.Data.Models.Base;

namespace InstaConnect.Posts.Data.Models.Entities;

public class PostCommentLike : BaseEntity
{
    public string PostCommentId { get; set; }

    public string UserId { get; set; }

    public PostComment PostComment { get; set; }
}
