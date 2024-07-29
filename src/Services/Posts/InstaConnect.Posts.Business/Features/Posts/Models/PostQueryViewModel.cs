namespace InstaConnect.Posts.Business.Features.Posts.Models;

public record PostQueryViewModel(string Id, string Title, string Content, string UserId, string UserName, string? UserProfileImage);
