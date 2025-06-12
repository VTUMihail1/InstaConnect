namespace InstaConnect.Posts.Application.Features.Posts.Models;

public record PostQueryResponse(string Id, string Title, string Content, PostUserQueryResponse User);
