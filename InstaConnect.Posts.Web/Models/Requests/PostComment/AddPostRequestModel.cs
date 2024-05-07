namespace InstaConnect.Posts.Web.Models.Requests.PostComment;

public class AddPostCommentRequestModel
{
    public string PostId { get; set; }

    public string? PostCommentId { get; set; }

    public string Content { get; set; }
}
