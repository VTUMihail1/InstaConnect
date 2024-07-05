namespace InstaConnect.Posts.Read.Business.Models;

public class PostCommentLikeViewModel
{
    public string Id { get; set; } = string.Empty;

    public string PostCommentId { get; set; } = string.Empty;

    public string UserId { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;

    public string? UserProfileImage { get; set; } = string.Empty;
}
