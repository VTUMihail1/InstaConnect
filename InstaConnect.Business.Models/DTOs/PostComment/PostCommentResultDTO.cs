namespace InstaConnect.Business.Models.DTOs.PostComment
{
    public class PostCommentResultDTO
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public string PostId { get; set; }

        public string? PostCommentId { get; set; }

        public string Content { get; set; }
    }
}
