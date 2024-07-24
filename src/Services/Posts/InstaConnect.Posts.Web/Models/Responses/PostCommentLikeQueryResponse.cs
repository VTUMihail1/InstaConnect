namespace InstaConnect.Posts.Read.Web.Models.Responses;

public class PostCommentLikeQueryResponse
{
    public string Id { get; set; } = string.Empty;

    public string PostCommentId { get; set; } = string.Empty;

    public string UserId { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;

    public string? UserProfileImage { get; set; } = string.Empty;
}
