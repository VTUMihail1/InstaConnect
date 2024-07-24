namespace InstaConnect.Posts.Read.Web.Models.Responses;

public class PostQueryResponse
{
    public string Id { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public string UserId { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;

    public string? UserProfileImage { get; set; } = string.Empty;
}
