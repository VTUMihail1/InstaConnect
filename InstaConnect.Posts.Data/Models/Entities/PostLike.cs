using InstaConnect.Shared.Data.Models.Base;

namespace InstaConnect.Posts.Data.Models.Entities;

public class PostLike : BaseEntity
{
    public string PostId { get; set; }

    public string UserId { get; set; }

    public Post Post { get; set; }
}
