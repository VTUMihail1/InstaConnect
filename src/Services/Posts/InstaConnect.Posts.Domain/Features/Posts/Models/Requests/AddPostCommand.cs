namespace InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

public record AddPostCommand(string UserId, string Title, string Content);
