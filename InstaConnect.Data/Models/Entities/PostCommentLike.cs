using InstaConnect.Data.Models.Entities.Base;

namespace InstaConnect.Data.Models.Entities
{
    public class PostCommentLike : BaseEntity
    {
        public string PostCommentId { get; set; }

        public string UserId { get; set; }

        public PostComment PostComment { get; set; }

        public User User { get; set; }
    }
}
