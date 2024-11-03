namespace InstaConnect.Posts.Web.Features.Posts.Models.Responses;

public record PostQueryResponse(string Id, string Title, string Content, string UserId, string UserName, string? UserProfileImage);
