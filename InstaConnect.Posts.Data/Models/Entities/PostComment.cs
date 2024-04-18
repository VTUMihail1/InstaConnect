using InstaConnect.Shared.Data.Models.Base;

namespace InstaConnect.Posts.Data.Models.Entities
{
    public class PostComment : BaseEntity
    {
        public string UserId { get; set; }

        public string PostId { get; set; }

        public string Content { get; set; }

        public string? PostCommentId { get; set; }

        public Post Post { get; set; }

        public ICollection<PostCommentLike> CommentLikes { get; set; } = new List<PostCommentLike>();

        public ICollection<PostComment> PostComments { get; set; } = new List<PostComment>();
    }
}
