namespace InstaConnect.Posts.Web.Read.Models.Responses;

public class PostCommentResponse
{
    public string Id { get; set; } = string.Empty;

    public string UserId { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;

    public string PostId { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;
}
