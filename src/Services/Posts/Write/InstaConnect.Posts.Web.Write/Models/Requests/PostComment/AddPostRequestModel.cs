namespace InstaConnect.Posts.Web.Models.Requests.PostComment;

public class AddPostCommentRequest
{
    public string PostId { get; set; }

    public string Content { get; set; }
}
