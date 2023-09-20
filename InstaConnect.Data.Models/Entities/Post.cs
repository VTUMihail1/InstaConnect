using InstaConnect.Data.Models.Entities.Base;

namespace InstaConnect.Data.Models.Entities
{
    public class Post : BaseEntity
    {
        public Post()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public ICollection<PostLike> PostLikes { get; set; } = new List<PostLike>();

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
