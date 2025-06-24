namespace InstaConnect.Posts.Application.Features.Posts.Models;

public record PostApiResponse(string Id, string Title, string Content, PostUserApiResponse User);
