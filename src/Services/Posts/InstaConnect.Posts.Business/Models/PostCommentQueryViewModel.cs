namespace InstaConnect.Posts.Read.Business.Models;

public class PostCommentQueryViewModel
{
    public string Id { get; set; } = string.Empty;

    public string UserId { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;

    public string? UserProfileImage { get; set; } = string.Empty;

    public string PostId { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;
}
