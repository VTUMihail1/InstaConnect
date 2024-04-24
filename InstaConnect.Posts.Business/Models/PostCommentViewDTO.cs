namespace InstaConnect.Posts.Business.Models
{
    public class PostCommentViewDTO
    {
        public string UserId { get; set; }

        public string PostId { get; set; }

        public string Content { get; set; }

        public string? PostCommentId { get; set; }
    }
}
