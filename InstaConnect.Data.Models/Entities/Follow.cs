using InstaConnect.Data.Models.Entities.Base;

namespace InstaConnect.Data.Models.Entities
{
    public class Follow : BaseEntity
    {
        public string FollowingId { get; set; }

        public string FollowerId { get; set; }

        public User Following { get; set; }

        public User Follower { get; set; }
    }
}
