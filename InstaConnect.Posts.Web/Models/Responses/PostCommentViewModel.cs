namespace InstaConnect.Posts.Web.Models.Responses
{
    public class PostCommentViewModel
    {
        public string UserId { get; set; }

        public string PostId { get; set; }

        public string Content { get; set; }

        public string? PostCommentId { get; set; }
    }
}
