namespace InstaConnect.Posts.Application.Features.Posts.Models;

public record PostQueryViewModel(string Id, string Title, string Content, string UserId, string UserName, string? UserProfileImage);
