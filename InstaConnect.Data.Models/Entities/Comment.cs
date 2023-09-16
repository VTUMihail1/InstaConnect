using InstaConnect.Data.Models.Entities.Base;

namespace InstaConnect.Data.Models.Entities
{
    public class Comment : BaseEntity
    {
        public Comment()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string UserId { get; set; }

        public string PostId { get; set; }

        public string Content { get; set; }

        public User User { get; set; }

        public Post Post { get; set; }
    }
}
