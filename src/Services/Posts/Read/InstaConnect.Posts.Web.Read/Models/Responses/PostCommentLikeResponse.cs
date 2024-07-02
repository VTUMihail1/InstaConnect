namespace InstaConnect.Posts.Web.Read.Models.Responses;

public class PostCommentLikeResponse
{
    public string Id { get; set; } = string.Empty;

    public string PostCommentId { get; set; } = string.Empty;

    public string UserId { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;
}
