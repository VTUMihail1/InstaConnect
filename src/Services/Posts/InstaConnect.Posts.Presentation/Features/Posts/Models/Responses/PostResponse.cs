namespace InstaConnect.Posts.Application.Features.Posts.Models;

public record PostResponse(string Id, string Title, string Content, PostUserResponse User);
