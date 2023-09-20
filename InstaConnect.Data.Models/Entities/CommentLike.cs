using InstaConnect.Data.Models.Entities.Base;

namespace InstaConnect.Data.Models.Entities
{
    public class CommentLike : BaseEntity
    {
        public string CommentId { get; set; }

        public string UserId { get; set; }

        public Comment Comment { get; set; }

        public User User { get; set; }
    }
}
