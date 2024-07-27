namespace InstaConnect.Posts.Web.Models.Responses.Posts;

public record PostQueryResponse(string Id, string Title, string Content, string UserId, string UserName, string? UserProfileImage);
