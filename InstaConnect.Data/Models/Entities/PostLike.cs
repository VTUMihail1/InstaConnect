using InstaConnect.Data.Models.Entities.Base;

namespace InstaConnect.Data.Models.Entities
{
    public class PostLike : BaseEntity
    {
        public string PostId { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public Post Post { get; set; }
    }
}
