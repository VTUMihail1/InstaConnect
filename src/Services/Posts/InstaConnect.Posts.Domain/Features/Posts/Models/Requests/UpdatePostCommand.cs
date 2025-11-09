namespace InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

public record UpdatePostCommand(
    string Id,
    string UserId,
    string Title,
    string Content);
